using UnityEngine;

public class BumperProjectile : MonoBehaviour
{
    [Header("ตั้งค่ากระสุน")]
    public float speed = 2000f;      // ความเร็วพุ่ง
    public float lifeTime = 3f;      // วินาทีที่จะทำลายตัวเองถ้าไม่ชนอะไร

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // โชว์ฟิสิกส์: ใส่แรงพุ่งตูมเดียว (Impulse) ไปข้างหน้าทันทีที่เกิด
        rb.AddRelativeForce(Vector3.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        // ทำลายตัวเองอัตโนมัติเมื่อครบเวลา
        Destroy(gameObject, lifeTime);
    }

    // ฟังก์ชันตรวจสอบการชน
    void OnCollisionEnter(Collision collision)
    {
        // ถ้าชนวัตถุที่มี Tag ว่า "Crate" (เราจะไปตั้งชื่อ Tag นี้ทีหลัง)
        if (collision.gameObject.CompareTag("Crate"))
        {
            // ทำลายกล่องที่ชน
            Destroy(collision.gameObject);

            // และทำลายตัวกันชนเองด้วย (ให้เหมือนระเบิดไปพร้อมกัน)
            Destroy(gameObject);
        }
    }
}