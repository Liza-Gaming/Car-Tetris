using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
