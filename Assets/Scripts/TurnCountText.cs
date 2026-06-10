using UnityEngine;
using TMPro;

public class TurnCountText : MonoBehaviour
{
    
    TextMeshProUGUI turnCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        turnCountText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        turnCountText.text = "Turn: " + GameManager.currentTurn;
    }
}
