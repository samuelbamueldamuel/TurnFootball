using UnityEngine;
using System.Collections.Generic;


public class PlayDesignManager : MonoBehaviour
{
    public PlayerSelector playerSelector;
    public CheckDistance checkDistance;
    public MovePlayer movePlayer;
    bool isPlayerSelected = false;
    public GameObject selectedPlayer;

    void Start()
    {

        playerSelector = GetComponent<PlayerSelector>();
        checkDistance = GetComponent<CheckDistance>();
        checkDistance.populateList();
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isPlayerSelected)
        {
            selectedPlayer = playerSelector.ShootRay();
            if (selectedPlayer != null)
            {
                Debug.Log("Selected Player: " + selectedPlayer.name);
                checkDistance.CheckDistanceFromPlayer(selectedPlayer);
                
                isPlayerSelected = true;
                
            }
        }
        else if(Input.GetMouseButtonDown(0) && isPlayerSelected)
        {
            movePlayer = GetComponent<MovePlayer>();
            movePlayer.ChooseTile(selectedPlayer);
            checkDistance.removeMoveableTag();
            isPlayerSelected = false;
        }
    }
}
