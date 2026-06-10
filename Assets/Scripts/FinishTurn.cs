using UnityEngine;

public class FinishTurn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public APlayDesignManager APlayDesignManager;
    public void EndTurn()
    {
        GameManager.currentTurn++;
        Debug.Log("Turn: " + GameManager.currentTurn);
        // APlayDesignManager = GetComponent<APlayDesignManager>();
        APlayDesignManager.resetLayers();
    }

}
