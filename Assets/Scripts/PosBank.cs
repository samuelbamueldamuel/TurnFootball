using UnityEngine;
using System.Collections.Generic;
public class PosBank: MonoBehaviour
{
    // public List<(GameObject, Vector3)> teamAStartingPositions = new List<(GameObject, Vector3)>();
    // public List<(GameObject, Vector3)> teamBStartingPositions = new List<(GameObject, Vector3)>();
    public static List<List<(GameObject, Vector3)>> turnPositionsA = new List<List<(GameObject, Vector3)>>(); //lists of lists to store positions every turn, index 0 will be starting positions
    public static List<List<(GameObject, Vector3)>> turnPositionsB = new List<List<(GameObject, Vector3)>>(); 
    public void savePositions(GameObject team)
    {

        List<(GameObject, Vector3)> positions = new List<(GameObject, Vector3)>(); //this is the sub-list in the lists defined on line 7 and 8
        for (int i = 0; i < team.transform.childCount; i++)
        {
            positions.Add((team.transform.GetChild(i).gameObject, team.transform.GetChild(i).position)); //adds each players position to the list as a tuple of (player, position)
        }


        if(team.CompareTag("TeamA")) //makes sure saved to correct list
        {
            turnPositionsA.Add(positions);

        }
        else if(team.CompareTag("TeamB"))
        {
            turnPositionsB.Add(positions);
        }
    }        

}