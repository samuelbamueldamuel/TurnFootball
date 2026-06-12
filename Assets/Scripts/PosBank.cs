using UnityEngine;

public class PosBank: MonoBehaviour
{
    public GameObject[] teamAStartingPositions;
    public GameObject[] teamBStartingPositions;
    public void saveStartingPositions(GameObject teamA, GameObject teamB)
    {
        for (int i = 0; i < teamA.transform.childCount; i++)
        {
            teamAStartingPositions[i] = teamA.transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < teamB.transform.childCount; i++)
        {
            teamBStartingPositions[i] = teamB.transform.GetChild(i).gameObject;
        }
    }
}