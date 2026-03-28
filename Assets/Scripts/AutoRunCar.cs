using UnityEngine;
using UnityEngine.UI;

public class AutoRunCar : MonoBehaviour
{
    private Rigidbody rb;

    [Header("UI Car")]
    public Slider speedBar;
    public Image speedBarFill;
    public Gradient speedColors;
    public Slider cooldownBar;

    [Header("Speed Setting")]
    public float baseSpeed = 1000f;
    public float boostSpeed = 500f;
    public float brakePower = 600f;
    public float minSpeed = 300f;
    public float strafeSpeed = 800f;

    [Header("Shooting System")]
    public GameObject bumperPrefab;
    public Transform shootPoint;
    public float fireRate = 10f;
    private float nextFireTime = 0f;

    [Header("Dead Setting")]
    public float fallThreshold = -5f; // ถ้ารถร่วงไปต่ำกว่าแกน Y ที่ตั้งไว้จะให้วาร์ปกลับ
    private Vector3 startPos;         // ตำแหน่งเกิด
    private Quaternion startRot;      // การหันหน้าของรถตอนเกิด

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //จุดเริ่มของตำแหน่งและทิศทางรถตอนเริ่มเกม
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
        // ถ้าตำแหน่ง Y ของรถต่ำกว่าที่ตั้งไว้ เรียกฟังก์ชัน Respawn
        if (transform.position.y < fallThreshold)
        {
            RespawnCar();
        }

        // ระบบยิงและ UI
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

    // ฟังก์ชันวาร์ปกลับจุดเกิดเมื่อรถตกถนน
    void RespawnCar()
    {
        transform.position = startPos;
        transform.rotation = startRot;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        Debug.Log("ตกถนน กลับจุดเกิด");
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