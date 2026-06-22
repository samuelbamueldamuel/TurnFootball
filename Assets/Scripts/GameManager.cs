using UnityEngine;

public enum TeamUp //enum used to specify what team is up
{
    TeamA,
    TeamB,
    Sim
}

public class GameManager: MonoBehaviour
{
    public static TeamUp currentTeam = TeamUp.TeamA;
    // public SimPhase simPhase;
    public static int turnLimit = 3;
    public static int currentTurn = 1;
    public bool swapped = false; //used to know when both teams
    public static bool simPhaseStarted = false; //used to make sure sim phase only starts once


    void Update()
    {
        if (currentTurn > turnLimit) //changes teams after 3 moves
        {
            if(swapped && !simPhaseStarted) //makes sure both teams have had 3 turns before starting sim phase)
            {
                currentTeam = TeamUp.Sim;
                SimPhase simPhase = GetComponent<SimPhase>(); //static needs object reference to call method
                simPhase.MovePlayersToSimPositions(0);// starts simphase, 0 is index for first turn then it calls itself recursively +1
                simPhaseStarted = true; //flicks switch so only call method one
                currentTurn = 1; //resets turn for next play

            }
            else if(currentTeam == TeamUp.TeamA && !simPhaseStarted)
            {
                currentTeam = TeamUp.TeamB;
                currentTurn = 1;
                swapped = true;
            }
            else if(currentTeam == TeamUp.TeamB && !simPhaseStarted)
            {
                currentTeam = TeamUp.TeamA;
                currentTurn = 1;
                swapped = true;
            }
        }
    }
}