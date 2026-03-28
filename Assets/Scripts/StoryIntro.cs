using UnityEngine;

public class StoryIntro : MonoBehaviour
{
    [Header("ลาก StoryPanel มาใส่ช่องนี้")]
    public GameObject storyPanel;

    void Start()
    {
        // พอเริ่มเกมนีให้หยุดเวลาเกมทันที เพื่อเปิดหน้าต่างเนื้อเรื่อง
        Time.timeScale = 0f;

        if (storyPanel != null)
        {
            storyPanel.SetActive(true);
        }
    }

    public void StartRush()
    {
        // ปิดหน้าต่างเนื้อเรื่อง
        if (storyPanel != null)
        {
            storyPanel.SetActive(false);
        }

        // สั่งให้เวลาเดินตามปกติ
        Time.timeScale = 1f;
    }
}