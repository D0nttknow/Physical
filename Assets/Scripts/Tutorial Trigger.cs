using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [Header("ลากหน้าต่าง Tutorial Panel มาใส่ช่องนี้")]
    public GameObject tutorialPanel;

    void Start()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }
    }

    // ทำงานเมื่อรถวิ่งมาชนกำแพง
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(true); 
                Time.timeScale = 0f;           
            }
        }
    }

    // ฟังก์ชันนี้เอาไปผูกกับ ปุ่มกด
    public void ResumeGame()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }

        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}