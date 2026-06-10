using UnityEngine;
using System.Collections.Generic;


public class PlayDesignManager : MonoBehaviour
{
    public PlayerSelector playerSelector;
    public CheckDistance checkDistance;
    public MovePlayer movePlayer;
    public bool isPlayerSelected = false;
    public GameObject selectedPlayer;
    public GameObject TeamAPlayers;
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
            // Debug.Log("pew pew");
            selectedPlayer = playerSelector.ShootRay(GameManager.currentTeam);

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

    public void resetLayers(TeamUp team)
    {
        Debug.Log("Resetting layers for " + team.ToString());
        if (team == TeamUp.TeamA)
        {
            foreach (Transform player in TeamAPlayers.transform)
            {
                player.gameObject.layer = LayerMask.NameToLayer("Unmoved");
            }
        }
        else if (team == TeamUp.TeamB)
        {
            foreach (Transform player in TeamBPlayers.transform)
            {
                player.gameObject.layer = LayerMask.NameToLayer("Unmoved");
            }
        }
    }
}

