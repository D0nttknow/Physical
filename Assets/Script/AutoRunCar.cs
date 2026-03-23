using UnityEngine;

public class AutoRunCar : MonoBehaviour
{
    private Rigidbody rb;

    [Header("ตั้งค่าความเร็ว")]
    public float baseSpeed = 1000f;  // แรงขับปกติ (รถวิ่งเองตลอดเวลา)
    public float boostSpeed = 1500f; // แรงเสริมตอนกด W
    public float turnSpeed = 100f;   // ความไวในการเลี้ยว (A/D)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 1. กำหนดแรงขับตั้งต้น (วิ่งเองตลอด)
        float currentForce = baseSpeed;

        // 2. ถ้ากด W ค้างไว้ ให้บวกแรงพุ่งเข้าไปอีก (เหยียบคันเร่งมิด)
        if (Input.GetKey(KeyCode.W))
        {
            currentForce += boostSpeed;
        }

        // โชว์ฟิสิกส์: ใส่แรงผลักไปด้านหน้าของตัวรถ (Vector3.forward)
        rb.AddRelativeForce(Vector3.forward * currentForce * Time.fixedDeltaTime, ForceMode.Force);

        // 3. รับค่าการกด A / D เพื่อเลี้ยวซ้าย-ขวา
        float turnInput = Input.GetAxis("Horizontal"); // จะได้ค่า -1 ถึง 1

        if (turnInput != 0)
        {
            // โชว์ฟิสิกส์: การหมุนตัวรถรอบแกน Y
            Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}