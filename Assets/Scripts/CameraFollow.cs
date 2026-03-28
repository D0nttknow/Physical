using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Car")]
    public Transform target;

    [Header("Car Rigidbody")]
    public Rigidbody targetRb;

    [Header("Camera Settings")]
    public Vector3 baseOffset = new Vector3(0f, 5f, -10f); // ระยะห่างปกติของ กล้องจากรถ

    [Header("Speed Camera Setting")]
    public float pullbackMultiplier = 0.1f; // ยิ่งเยอะ กล้องยิ่งถอยไกลตอนรถวิ่งเร็ว
    public float maxPullback = 5f;          // กล้องถอยหลังได้มากสุดแค่ไหน

    void LateUpdate()
    {
        if (target == null) return;

        float currentSpeed = 0f;
        if (targetRb != null)
        {
            currentSpeed = targetRb.linearVelocity.magnitude;
        }

        float pullbackDistance = Mathf.Clamp(currentSpeed * pullbackMultiplier, 0f, maxPullback);

        Vector3 dynamicOffset = baseOffset + new Vector3(0f, 0f, -pullbackDistance);

        transform.position = target.position + dynamicOffset;

        transform.LookAt(target);
    }
}