using UnityEngine;
using TMPro;

public class TeamUpText : MonoBehaviour
{
   TextMeshProUGUI teamUpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teamUpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        teamUpText.text = "Current Team: " + GameManager.currentTeam;
    }
}
