using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1;
    public GameObject levelCompleteUI;
    public void GameOver()
    {
        //Debug.Log("ENNDDD");
        Invoke("Restart", restartDelay);
    }

    public void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}