using UnityEngine;

// Yêu cầu Unity tự động thêm component LineRenderer nếu chưa có
[RequireComponent(typeof(LineRenderer))]
public class AutoTurret : MonoBehaviour
{
    [Header("Cài đặt mục tiêu")]
    public Transform target;
    public float attackRange = 15f;
    public float rotationSpeed = 10f; // Tăng tốc lên chút cho nguy hiểm

    [Header("Cài đặt súng")]
    public float fireRate = 0.2f;      // Bắn nhanh hơn (0.2s)
    public int damage = 5;
    public Transform muzzlePoint;      // Vị trí đầu nòng súng (để phát tia laser)
    private float nextFireTime = 0f;
    
    private PlayerHealthEvent targetHealth;
    private LineRenderer laserLine;    // Component vẽ tia laser
    public GameObject bulletPrefab; // Kéo Prefab viên đạn vào đây

    void Start()
    {
        if (target != null)
            targetHealth = target.GetComponent<PlayerHealthEvent>();

        // Setup tia Laser
        laserLine = GetComponent<LineRenderer>();
        laserLine.positionCount = 2; // Điểm đầu và điểm cuối
        laserLine.startWidth = 0.05f; // Tia mảnh thôi mới đẹp
        laserLine.endWidth = 0.05f;
        // Chỉnh màu đỏ cho nguy hiểm (Cần assign Material cho LineRenderer để thấy màu)
        laserLine.material = new Material(Shader.Find("Sprites/Default")); 
        laserLine.startColor = Color.red;
        laserLine.endColor = Color.red;
    }

    void Update()
    {
        if (target == null) 
        {
            laserLine.enabled = false; // Tắt laser nếu ko có mục tiêu
            return;
        }

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            laserLine.enabled = true; // Bật laser
            
            // 1. Xoay nòng súng (Full 3D rotation)
            RotateTowardsTarget();

            // 2. Vẽ tia Laser
            DrawLaser();

            // 3. Logic bắn (Góc lệch nhỏ hơn 15 độ thì bắn)
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < 15f)
            {
                Shoot();
            }
        }
        else
        {
            laserLine.enabled = false; // Player chạy xa quá thì tắt laser
        }
    }

    void RotateTowardsTarget()
    {
        // Tính hướng đến điểm giữa thân Player (cộng thêm Vector3.up để ko bắn vào chân)
        Vector3 targetPoint = target.position; 

        Vector3 direction = targetPoint - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void DrawLaser()
    {
        // Nếu chưa gán đầu nòng súng thì lấy tạm vị trí của Turret
        Vector3 startPos = (muzzlePoint != null) ? muzzlePoint.position : transform.position;
        
        // Điểm đầu: Nòng súng
        laserLine.SetPosition(0, startPos);
        
        // Điểm cuối: Player (bắn vào người cho chuẩn)
        laserLine.SetPosition(1, target.position);
    }

    void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            // Thay vì gọi targetHealth.TakeDamage...
            // Ta sinh ra viên đạn tại đầu nòng súng
            if (bulletPrefab != null && muzzlePoint != null)
            {
                Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            }

            nextFireTime = Time.time + fireRate;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}