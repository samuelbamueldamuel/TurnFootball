using UnityEngine;
using System.Collections.Generic;
public class PosBank: MonoBehaviour
{
    // public List<(GameObject, Vector3)> teamAStartingPositions = new List<(GameObject, Vector3)>();
    // public List<(GameObject, Vector3)> teamBStartingPositions = new List<(GameObject, Vector3)>();
    public List<List<(GameObject, Vector3)>> turnPositionsA = new List<List<(GameObject, Vector3)>>();
    public List<List<(GameObject, Vector3)>> turnPositionsB = new List<List<(GameObject, Vector3)>>();
    public void savePositions(GameObject team)
    {

            List<(GameObject, Vector3)> positions = new List<(GameObject, Vector3)>();
            for (int i = 0; i < team.transform.childCount; i++)
            {
                positions.Add((team.transform.GetChild(i).gameObject, team.transform.GetChild(i).position));
            }
            if(team.CompareTag("TeamA"))
            {
                turnPositionsA.Add(positions);
                Debug.Log("Saved positions for Team A:");
                foreach (var (player, position) in positions)
                {
                    Debug.Log($"{player.name} at {position}");
                }
            }
            else if(team.CompareTag("TeamB"))
            {
                turnPositionsB.Add(positions);
            }
            


        // Debug.Log("Saved starting positions for Team A:");
        // foreach (var (player, position) in teamAStartingPositions)
        // {
        //     Debug.Log($"{player.name} at {position}");
        // }
    }
}