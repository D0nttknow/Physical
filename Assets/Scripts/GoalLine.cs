using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLine : MonoBehaviour
{
    [Header("Main Scene")]
    public string nextSceneName = "MainGame";

    void OnTriggerEnter(Collider other)
    {
        // ถ้ารถ Player ขับมาเข้าเส้นชัย
        if (other.CompareTag("Player"))
        {
            Debug.Log("เขาเข้าเส้นชัย");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}