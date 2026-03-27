using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public void BackToMenu()
    {
        // โหลดกลับไปที่หน้า MainMenu (ที่อยู่เบอร์ 0)
        SceneManager.LoadScene("MainMenu");
    }
}