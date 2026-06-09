using UnityEngine;
using System.Collections.Generic;

public class CheckDistance : MonoBehaviour
{
    public GameObject turf;
    public List<GameObject> tiles = new List<GameObject>();
    public float moveLimit = 5f;
    public Material newMaterial;
    public Material defaultMaterial;


    public void populateList()
    {

        foreach (Transform child in turf.transform)
        {

            tiles.Add(child.gameObject);

            
            // Debug.Log("Added to list: " + child.gameObject.name);

        }
        Debug.Log("Total tiles in list: " + tiles.Count);
    }
    public void removeMoveableTag()
    {
        foreach (GameObject tile in tiles)
        {
            // Debug.Log("Resetting tile: " + tile.name);
            MeshRenderer tileRenderer = tile.GetComponent<MeshRenderer>();
            tile.GetComponent<MeshRenderer>().material = defaultMaterial;
            tile.tag = "Tile";
            
        }
        
    }

    public void CheckDistanceFromPlayer(GameObject player)
    {
        Debug.Log("Checking distance from player: " + player.name);
        foreach (GameObject tile in tiles)
        {
            float playerX = player.transform.position.x;
            float playerZ = player.transform.position.z;
            float tileX = tile.transform.position.x;
            float tileZ = tile.transform.position.z;

            Vector2Int playerPos = new Vector2Int(Mathf.RoundToInt(playerX), Mathf.RoundToInt(playerZ));
            Vector2Int tilePos = new Vector2Int(Mathf.RoundToInt(tileX), Mathf.RoundToInt(tileZ));
            int distance =
                Mathf.Abs(playerPos.x - tilePos.x) +
                Mathf.Abs(playerPos.y - tilePos.y);

            if (distance <= moveLimit)
            {
                // Debug.Log($"Highlighting {tile.name} at {tilePos}");
                // Debug.Log(newMaterial.GetType());
                // Debug.Log(newMaterial.name);
                MeshRenderer tileRenderer = tile.GetComponent<MeshRenderer>();
                tile.GetComponent<MeshRenderer>().material = newMaterial;
                tile.tag = "MoveableTile";
            }
            // else
            // {
            //     // Debug.Log("Distance:  " + distance);
            // }
        }
        
    }
}