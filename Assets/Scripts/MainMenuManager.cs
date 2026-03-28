using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // ปุ่ม เริ่มเกม
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // ปุ่ม เครดิต
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credit");
    }

    // ปุ่ม ออกเกม
    public void QuitGame()
    {
        Debug.Log("ออกเกม");
        Application.Quit();
    }
}