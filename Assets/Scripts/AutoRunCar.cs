using UnityEngine;
using UnityEngine.UI;

public class AutoRunCar : MonoBehaviour
{
    private Rigidbody rb;

    [Header("UI หลอดสถานะ")]
    public Slider speedBar;
    public Image speedBarFill;
    public Gradient speedColors;
    public Slider cooldownBar;

    [Header("ตั้งค่าความเร็ว")]
    public float baseSpeed = 1000f;
    public float boostSpeed = 500f;
    public float brakePower = 600f;
    public float minSpeed = 300f;
    public float strafeSpeed = 800f;

    [Header("ระบบยิงกันชน")]
    public GameObject bumperPrefab;
    public Transform shootPoint;
    public float fireRate = 10f;
    private float nextFireTime = 0f;

    [Header("ระบบตกถนน (ใหม่!)")]
    public float fallThreshold = -5f; // ถ้ารถหล่นไปต่ำกว่าแกน Y ที่ -5 จะให้วาร์ปกลับ
    private Vector3 startPos;         // ตัวแปรจำตำแหน่งเกิด
    private Quaternion startRot;      // ตัวแปรจำองศาการหันหน้าตอนเกิด

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 1. ให้จำตำแหน่งและทิศทางของรถตอนเริ่มเกมไว้ทันที
        startPos = transform.position;
        startRot = transform.rotation;

        if (cooldownBar != null)
        {
            cooldownBar.maxValue = fireRate;
            cooldownBar.value = fireRate;
        }
    }

    void Update()
    {
        // เช็คระบบตกถนน: ถ้าตำแหน่ง Y ของรถต่ำกว่าที่กำหนด ให้เรียกฟังก์ชัน Respawn
        if (transform.position.y < fallThreshold)
        {
            RespawnCar();
        }

        // --- (โค้ดระบบยิงและ UI เหมือนเดิมทุกอย่าง) ---
        if (Input.GetButtonDown("Jump") && Time.time >= nextFireTime)
        {
            ShootBumper();
            nextFireTime = Time.time + fireRate;
            if (cooldownBar != null) { cooldownBar.value = 0f; }
        }

        if (cooldownBar != null && cooldownBar.value < fireRate)
        {
            cooldownBar.value += Time.deltaTime;
        }

        if (speedBar != null && speedBarFill != null)
        {
            speedBar.value = rb.linearVelocity.magnitude;
            speedBarFill.color = speedColors.Evaluate(speedBar.normalizedValue);
        }
    }

    // ฟังก์ชันวาร์ปกลับจุดเกิด (โชว์การจัดการ Rigidbody)
    void RespawnCar()
    {
        // 1. จับวางที่ตำแหน่งและองศาเดิม
        transform.position = startPos;
        transform.rotation = startRot;

        // 2. ล้างแรงฟิสิกส์ทั้งหมดที่สะสมมา ไม่งั้นวาร์ปมาปุ๊บรถจะปลิวต่อ
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log("ตกถนน! วาร์ปกลับจุดเกิดเรียบร้อย");
    }

    void ShootBumper()
    {
        Instantiate(bumperPrefab, shootPoint.position, shootPoint.rotation);
    }

    void FixedUpdate()
    {
        float currentForce = baseSpeed;
        if (Input.GetKey(KeyCode.W)) { currentForce += boostSpeed; }
        else if (Input.GetKey(KeyCode.S)) { currentForce -= brakePower; currentForce = Mathf.Max(currentForce, minSpeed); }

        rb.AddRelativeForce(Vector3.forward * currentForce * Time.fixedDeltaTime, ForceMode.Force);

        float turnInput = Input.GetAxis("Horizontal");
        if (turnInput != 0) { rb.AddRelativeForce(Vector3.right * turnInput * strafeSpeed * Time.fixedDeltaTime, ForceMode.Force); }
    }
}