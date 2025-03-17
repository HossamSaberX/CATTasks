using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Transform player;
    void Update()
    {
        Text.text = ((player.position.z)-9).ToString("0");
        
    }
}
