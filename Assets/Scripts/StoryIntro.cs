using UnityEngine;

public class StoryIntro : MonoBehaviour
{
    [Header("ลาก StoryPanel มาใส่ช่องนี้")]
    public GameObject storyPanel;

    void Start()
    {
        // พอเริ่มฉากนี้ปุ๊บ ให้หยุดเวลาเกมทันที รถจะได้ยังไม่วิ่ง
        Time.timeScale = 0f;

        // เปิดหน้าต่างเนื้อเรื่องโชว์ขึ้นมา
        if (storyPanel != null)
        {
            storyPanel.SetActive(true);
        }
    }

    // ฟังก์ชันนี้เอาไว้ผูกกับปุ่ม "เหยียบมิดไมล์!"
    public void StartRush()
    {
        // ปิดหน้าต่างเนื้อเรื่อง
        if (storyPanel != null)
        {
            storyPanel.SetActive(false);
        }

        // สั่งให้เวลาเดินตามปกติ รถก็จะพุ่งไปข้างหน้าทันที!
        Time.timeScale = 1f;
    }
}