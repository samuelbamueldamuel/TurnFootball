using UnityEngine;

public enum TeamUp
{
    TeamA,
    TeamB
}

public class GameManager: MonoBehaviour
{
    public static TeamUp currentTeam = TeamUp.TeamA;
    public static int turnLimit = 3;
    public static int currentTurn = 1;


    void Update()
    {
        if (currentTurn > turnLimit)
        {
            if(currentTeam == TeamUp.TeamA)
            {
                currentTeam = TeamUp.TeamB;
                currentTurn = 1;
            }
            else
            {
                currentTeam = TeamUp.TeamA;
                currentTurn = 1;
            }
        }
    }
}