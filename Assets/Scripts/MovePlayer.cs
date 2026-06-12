using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    
    public void ChooseTile(GameObject player) // raycast to select tile 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject selectedTile = null;

        if (Physics.Raycast(ray, out hit))
        {
            
            
            selectedTile = hit.collider.transform.gameObject;
        }
        if(selectedTile != null && selectedTile.CompareTag("MoveableTile")) //if selected tile is in range, move player to tile
        {
            MoveToTile(player, selectedTile);
        }
        
    }

    public void MoveToTile(GameObject player, GameObject tile) //changes player pos to tile and updates
    {
        Vector3 targetPosition = new Vector3(tile.transform.position.x, player.transform.position.y, tile.transform.position.z);
        player.transform.position = targetPosition;
        player.layer = LayerMask.NameToLayer("Moved");
    }
}