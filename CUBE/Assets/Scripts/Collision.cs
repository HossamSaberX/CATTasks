using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Collision : MonoBehaviour
{
    public PlayerMovement Movement;
    public GameObject secondChancePanel;
    public float delayTime = 0.5f;
    private bool collidedOnce = false;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "Endless")
            {
                if (SecondChancePanel.chanceUsed)
                {
                    FindFirstObjectByType<GameManager>().Restart();
                }
                else if (!collidedOnce)
                {
                    collidedOnce = true;
                    Movement.enabled = false;
                    Time.timeScale = 0f;
                    StartCoroutine(ActivatePanelWithDelay());
                }
            }
            else
            {
                FindFirstObjectByType<GameManager>().GameOver();
            }
        }
    }

    private IEnumerator ActivatePanelWithDelay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        if (secondChancePanel != null)
            secondChancePanel.SetActive(true);
    }

}
