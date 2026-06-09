using UnityEngine;
using System.Collections.Generic;


public class PlayDesignManager : MonoBehaviour
{
    PlayerSelector playerSelector;
    CheckDistance checkDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        checkDistance = GetComponent<CheckDistance>();
        checkDistance.populateList();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            playerSelector = GetComponent<PlayerSelector>();
            GameObject selectedPlayer = playerSelector.ShootRay();
            if (selectedPlayer != null)
            {
                Debug.Log("Selected Player: " + selectedPlayer.name);
                checkDistance.CheckDistanceFromPlayer(selectedPlayer);
            }
        }
    }
}
