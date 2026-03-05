using UnityEngine;

public class PlayerController_Lab8_Fixed : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;

    // 1. Bonus: Dùng Animator.StringToHash (Đã đáp ứng)
    private int speedHash;
    private int attackHash;

    // Biến phụ để kiểm tra trạng thái cũ (Tối ưu hóa)
    private float lastSpeed;

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
        HandleAttack();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float targetSpeed = Mathf.Abs(moveInput);

        // Di chuyển nhân vật
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        // 2. Tối ưu: Tránh set liên tục nếu giá trị không đổi (Yêu cầu quan trọng)
        // Chỉ gọi Animator.SetFloat khi giá trị chênh lệch đáng kể so với lần set cuối cùng
        if (!Mathf.Approximately(lastSpeed, targetSpeed))
        {
            anim.SetFloat(speedHash, targetSpeed);
            lastSpeed = targetSpeed;
        }

        // Lật mặt Sprite
        if (moveInput > 0.1f) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < -0.1f) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleAttack()
    {
        // 3. Dùng SetTrigger (Đã đáp ứng)
        // Trigger mặc định đã được Unity tối ưu (tự reset sau khi dùng), 
        // nhưng chỉ gọi khi thực sự nhấn phím.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(attackHash);
        }
    }
}