using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public void BackToMenu()
    {
        // โหลดกลับไปที่หน้า MainMenu
        SceneManager.LoadScene("MainMenu");
    }
}