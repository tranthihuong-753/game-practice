using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int attackHash = Animator.StringToHash("Attack");

    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("Vui lòng gắn Animator vào GameObject trước khi chạy script!");
        }
    }

    void Update()
    {
        HandleMove();
        HandleAttack();
    }

    private void HandleMove()
    {
        float moveInput = Input.GetAxis("Horizontal");
        anim.SetFloat(speedHash, Mathf.Abs(moveInput));

        if (moveInput > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(attackHash);
        }
    }
}