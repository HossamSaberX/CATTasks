using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondChancePanel : MonoBehaviour
{
    public static bool chanceUsed = false;
    private Collision playerCollision;

    private void Awake()
    {
        playerCollision = FindFirstObjectByType<Collision>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnYesClicked()
    {
        if (chanceUsed) return;
        chanceUsed = true;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        if (playerCollision != null && playerCollision.Movement != null)
            playerCollision.Movement.enabled = true;
    }

    public void OnNoClicked()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
