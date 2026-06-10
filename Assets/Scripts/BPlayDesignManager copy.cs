using UnityEngine;
using System.Collections.Generic;


public class BPlayDesignManager : MonoBehaviour
{
    public PlayerSelector playerSelector;
    public CheckDistance checkDistance;
    public MovePlayer movePlayer;
    bool isPlayerSelected = false;
    public GameObject selectedPlayer;
    public GameObject TeamBPlayers;
    public GameManager gm;



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
            selectedPlayer = playerSelector.ShootRay("TeamB");
            if (selectedPlayer != null )
            {
                if(selectedPlayer.layer == LayerMask.NameToLayer("Unmoved"))
                {
                    Debug.Log("Selected Player: " + selectedPlayer.name);
                    checkDistance.CheckDistanceFromPlayer(selectedPlayer);
                    
                    isPlayerSelected = true;
                }
                else
                {
                    Debug.Log("Selected Player has already moved");
                }
                
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
