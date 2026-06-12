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
        checkDistance.populateList(); // makes a list of all tiles on turf

        
    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0) && !isPlayerSelected) //player selection phase
        {
            // Debug.Log("pew pew");
            selectedPlayer = playerSelector.ShootRay(GameManager.currentTeam); //shoots ray to select player, checks if player on current team, attaches to selectedPlayer

            if (selectedPlayer != null )
            {
                if(selectedPlayer.layer == LayerMask.NameToLayer("Unmoved")) //layers are Moved or Unmoved, change and check to keep 1 player moving per turn
                {
                    Debug.Log("Selected Player: " + selectedPlayer.name);
                    checkDistance.CheckDistanceFromPlayer(selectedPlayer); // changes tiles in moving range to read
                    
                    isPlayerSelected = true;
                    
                    //to later be put in its own function selectVisuals()
                    //since selected is just a gameobject that makes this a little easier
                    //selectedPlayer//instead of this, make a call to a visuals part, which will have a reference to the ghost and spawn it at the currently looked at tile
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
            movePlayer.ChooseTile(selectedPlayer); // shoots ray to select tiles, checks if in distance then moves player to tile
            checkDistance.removeMoveableTag();
            isPlayerSelected = false; //triggers player selection phase
        }
        
    }

    public void resetLayers(TeamUp team) // resets layers of players so they can be moved again
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

