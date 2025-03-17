using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gm;
    private void OnTriggerEnter()
    {
        gm.CompleteLevel();

    }
}
