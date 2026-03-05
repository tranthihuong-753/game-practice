using System.Collections;
using UnityEngine;

public class MiniProjectController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector3 bulletOffset = new Vector3(0.5f, 0, 0);
    [SerializeField] private float attackDelay = 1.5f; // Thời gian chờ 1.5s

    private int speedHash;
    private int attackHash;
    private float lastSpeed;
    private bool isAttacking = false; // Biến kiểm tra để tránh spam bắn đạn

    void Awake()
    {
        speedHash = Animator.StringToHash("Speed");
        attackHash = Animator.StringToHash("Attack");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();

        // Chỉ cho phép bấm Attack khi không trong trạng thái chờ bắn
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float targetSpeed = Mathf.Abs(moveInput);

        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        if (!Mathf.Approximately(lastSpeed, targetSpeed))
        {
            anim.SetFloat(speedHash, targetSpeed);
            lastSpeed = targetSpeed;
        }

        if (moveInput > 0.1f) transform.localScale = Vector3.one;
        else if (moveInput < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }

    // Coroutine xử lý việc delay bắn đạn
    private IEnumerator AttackRoutine()
    {
        isAttacking = true;

        // 1. Kích hoạt hoạt ảnh Attack ngay lập tức
        anim.SetTrigger(attackHash);

        // 2. Tạm dừng code tại đây trong 1.5 giây (nhưng game vẫn chạy)
        yield return new WaitForSeconds(attackDelay);

        // 3. Thực hiện bắn đạn sau khi chờ
        SpawnBullet();

        isAttacking = false;
    }

    private void SpawnBullet()
    {
        float direction = transform.localScale.x;
        Vector3 spawnPosition = transform.position + new Vector3(bulletOffset.x * direction, bulletOffset.y, bulletOffset.z);

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

        if (direction < 0)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}