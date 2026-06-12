using UnityEngine;

public class FinishTurn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayDesignManager PlayDesignManager;
    public GameManager GameManager;
    public void EndTurn() //called by button, increments turn 
    {
        GameManager.currentTurn++;
        Debug.Log("Turn: " + GameManager.currentTurn);
        // APlayDesignManager = GetComponent<APlayDesignManager>();

        PlayDesignManager.resetLayers(GameManager.currentTeam); //resets to unmoved so players can be moved again
    }

}
