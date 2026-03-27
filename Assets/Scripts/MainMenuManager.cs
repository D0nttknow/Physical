using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // 1. ฟังก์ชันสำหรับปุ่ม "เริ่มเกม"
    public void PlayGame()
    {
        // ใส่ชื่อ Scene ด่านแรกของคุณ (เช่น "TutorialScene")
        SceneManager.LoadScene("Tutorial");
    }

    // 2. ฟังก์ชันสำหรับปุ่ม "เครดิต"
    public void GoToCredits()
    {
        // ใส่ชื่อ Scene เครดิต (เราจะสร้างกันหลังจากนี้)
        SceneManager.LoadScene("Credit");
    }

    // 3. ฟังก์ชันสำหรับปุ่ม "ออกเกม"
    public void QuitGame()
    {
        // 🚨 หมายเหตุ: คำสั่ง Application.Quit() จะทำงานตอน Build เป็นไฟล์ .exe 
        // แต่มันจะ "ไม่ทำงาน" บนเว็บบราวเซอร์ (WebGL) ครับ เป็นเรื่องปกติของ Unity!
        Debug.Log("ผู้เล่นกดออกเกมแล้ว!");
        Application.Quit();
    }
}