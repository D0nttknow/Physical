using UnityEngine;

public class BumperProjectile : MonoBehaviour
{
    [Header("Bullet Setting")]
    public float speed = 2000f;      // ความเร็วของกระสุน
    public float lifeTime = 3f;      // ตัวกำหนดเวลาที่จะทำลายตัวเองถ้าไม่ชนอะไร

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        Destroy(gameObject, lifeTime);
    }

    // เช็คว่าชนกับวัตถุที่มี Tag ว่า "Crate" รึปาว
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crate"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}