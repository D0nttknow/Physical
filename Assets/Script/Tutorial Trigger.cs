using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [Header("ลากหน้าต่าง Tutorial Panel มาใส่ช่องนี้")]
    public GameObject tutorialPanel;

    void Start()
    {
        // เริ่มเกมมา ให้ซ่อนหน้าต่างนี้ไว้ก่อน
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }
    }

    // ทำงานเมื่อรถวิ่งมาชนกำแพงล่องหน
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(true); // 1. เปิดหน้าต่าง Panel ดำๆ ขึ้นมา
                Time.timeScale = 0f;           // 2. 🚨 สั่งหยุดเวลาในเกม! (รถจะเบรกหัวทิ่มทันที)
            }
        }
    }

    // ฟังก์ชันนี้เราจะเอาไปผูกกับ "ปุ่มกด" ในหน้าจอ
    public void ResumeGame()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false); // 1. ซ่อนหน้าต่างสอนเล่น
        }

        Time.timeScale = 1f; // 2. 🚨 สั่งให้เวลาเดินตามปกติ! (รถวิ่งต่อ)

        // 3. ทำลายกำแพงล่องหนนี้ทิ้ง จะได้ไม่โดนซ้ำ
        Destroy(gameObject);
    }
}