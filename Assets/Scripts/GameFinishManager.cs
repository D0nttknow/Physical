using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishManager : MonoBehaviour
{
    [Header("ลาก FinishPanel มาใส่ช่องนี้")]
    public GameObject finishPanel;

    void Start()
    {
        // ซ่อนหน้าต่างจบเกมตอนเริ่ม
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

            // หยุดเวลาให้รถเบรกทันที
            Time.timeScale = 0f;
        }
    }

    public void GoToCredits()
    {
        // ต้องสั่งให้เวลาเดินกลับเป็นปกติก่อนโหลดหน้าใหม่ ไม่งั้นหน้าต่อไปจะค้าง อ่านด้วยอีเวง
        Time.timeScale = 1f;

        // โหลดไปหน้าเครดิต
        SceneManager.LoadScene("Credit");
    }
}