using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishManager : MonoBehaviour
{
    [Header("ลาก FinishPanel มาใส่ช่องนี้")]
    public GameObject finishPanel;

    void Start()
    {
        // เริ่มเกมมา ซ่อนหน้าต่างจบเกมไว้ก่อน
        if (finishPanel != null)
        {
            finishPanel.SetActive(false);
        }
    }

    // เมื่อรถวิ่งมาเข้าเส้นชัย
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // เปิดหน้าต่างจบเกม
            if (finishPanel != null)
            {
                finishPanel.SetActive(true);
            }

            // หยุดเวลาให้รถเบรกกึกทันที
            Time.timeScale = 0f;
        }
    }

    // ฟังก์ชันนี้เอาไว้ใส่ที่ปุ่ม "View Credits"
    public void GoToCredits()
    {
        // ต้องสั่งให้เวลาเดินกลับเป็นปกติก่อนโหลดหน้าใหม่ ไม่งั้นหน้าต่อไปจะค้าง
        Time.timeScale = 1f;

        // โหลดไปหน้าเครดิต (พิมพ์ชื่อ Scene ให้ตรงกับที่คุณเซฟไว้นะครับ)
        SceneManager.LoadScene("Credit");
    }
}