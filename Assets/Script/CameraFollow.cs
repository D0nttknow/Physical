using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("ใส่โมเดลรถ (Target)")]
    public Transform target;

    [Header("ใส่ Rigidbody ของรถ (เพื่อเช็คความเร็ว)")]
    public Rigidbody targetRb;

    [Header("ตั้งค่ามุมกล้อง")]
    public Vector3 baseOffset = new Vector3(0f, 5f, -10f); // ระยะห่างปกติ

    [Header("เอฟเฟกต์ตอนซิ่ง")]
    public float pullbackMultiplier = 0.1f; // ยิ่งเยอะ กล้องยิ่งถอยไกลตอนรถวิ่งเร็ว
    public float maxPullback = 5f;          // ลิมิตว่าให้กล้องถอยหลังได้มากสุดแค่ไหน

    void LateUpdate()
    {
        if (target == null) return;

        // 1. อ่านค่าความเร็วปัจจุบันของรถจาก Rigidbody
        float currentSpeed = 0f;
        if (targetRb != null)
        {
            currentSpeed = targetRb.linearVelocity.magnitude;
        }

        // 2. คำนวณระยะถอยหลัง (เอาความเร็วมาคูณอัตราส่วน และล็อกไม่ให้เกินค่า max)
        float pullbackDistance = Mathf.Clamp(currentSpeed * pullbackMultiplier, 0f, maxPullback);

        // 3. ปรับระยะ Offset โดยดันกล้องถอยไปข้างหลัง (แกน Z ลบ)
        Vector3 dynamicOffset = baseOffset + new Vector3(0f, 0f, -pullbackDistance);

        // 4. ล็อกตำแหน่งกล้องแบบ 100% (ไม่มี Lerp แล้ว กล้องจะไม่แลคตามไม่ทันแน่นอน)
        transform.position = target.position + dynamicOffset;

        // 5. บังคับให้กล้องหันไปมองรถตลอดเวลา
        transform.LookAt(target);
    }
}