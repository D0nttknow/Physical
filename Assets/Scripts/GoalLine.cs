using UnityEngine;
using UnityEngine.SceneManagement; // ต้องมีคำสั่งนี้เพื่อจัดการ Scene

public class GoalLine : MonoBehaviour
{
    [Header("พิมพ์ชื่อ Scene ที่ต้องการให้โหลดต่อไป")]
    public string nextSceneName = "MainGame";

    void OnTriggerEnter(Collider other)
    {
        // ถ้ารถ (Player) ขับมาเข้าเส้นชัย
        if (other.CompareTag("Player"))
        {
            Debug.Log("🎉 เข้าเส้นชัยด่านสอนเล่น! กำลังโหลดด่านจริง...");

            // โหลด Scene ตามชื่อที่ตั้งไว้
            SceneManager.LoadScene(nextSceneName);
        }
    }
}