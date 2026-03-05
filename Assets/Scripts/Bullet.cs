using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifeTime = 2f; // T? phát n? sau 2 giây

    void Start()
    {
        // T? ??ng xóa object sau 2 giây
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // ??n bay v? phía tr??c (theo h??ng c?a nó)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        // Th?c hi?n hi?u ?ng n? t?i ?ây n?u có
        Debug.Log("Viên ??n ?ã phát n?!");
    }
}