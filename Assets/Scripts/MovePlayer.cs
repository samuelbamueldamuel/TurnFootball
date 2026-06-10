using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    
    public void ChooseTile(GameObject player)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject selectedTile = null;

        if (Physics.Raycast(ray, out hit))
        {
            
            
            selectedTile = hit.collider.transform.gameObject;
        }
        if(selectedTile != null && selectedTile.CompareTag("MoveableTile"))
        {
            MoveToTile(player, selectedTile);
        }
        
    }

    public void MoveToTile(GameObject player, GameObject tile)
    {
        Vector3 targetPosition = new Vector3(tile.transform.position.x, player.transform.position.y, tile.transform.position.z);
        player.transform.position = targetPosition;
        player.layer = LayerMask.NameToLayer("Moved");
    }
}