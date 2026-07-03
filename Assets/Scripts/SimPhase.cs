using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SimPhase : MonoBehaviour
{
    public PlayDesignManager PlayDesignManager;
    public GameManager GameManager;
    public static float moveDuration = 1f; //time in bewtween moves
    

    public void MovePlayersToSimPositions(int index)
    {
        StartCoroutine(MovePlayersCoroutine(index));
    }

    IEnumerator MovePlayersCoroutine(int index)
    {
        Debug.Log("Sim Phase Begun");
        for (int i = 0; i < PlayDesignManager.TeamAPlayers.transform.childCount; i++) //iterate through each player
        {
            PlayDesignManager.TeamAPlayers.transform.GetChild(i).position = PosBank.turnPositionsA[index][i].Item2; //moves player
        }
        for (int i = 0; i < PlayDesignManager.TeamBPlayers.transform.childCount; i++)
        {
            PlayDesignManager.TeamBPlayers.transform.GetChild(i).position = PosBank.turnPositionsB[index][i].Item2; //moves player
        }
        
        yield return new WaitForSeconds(moveDuration); // Wait 2 seconds
        
        if(index < GameManager.turnLimit)
        {
            MovePlayersToSimPositions(index + 1);//recursively calls itself until it has moved players for each turn
        }
        else
        {
            Debug.Log("Sim Phase Ended");
            GameManager.currentTeam = TeamUp.TeamA; //resets to team A for next play
            GameManager.simPhaseStarted = false; //resets sim phase for next play
            GameManager.swapped = false; //resets swapped for next play

        }
    }
}