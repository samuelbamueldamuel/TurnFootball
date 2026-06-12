using UnityEngine;
using System.Collections.Generic;

public class PlayerSelector: MonoBehaviour
{
    //raycast
    public Camera cam;

    public GameObject ShootRay(TeamUp team) //shoots rays and checks if object is on current team, called by pdm and returns the player hit
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject selected = null;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name + " on team: " + hit.collider.gameObject.tag);
            // Do something with the hit object
            if(hit.collider.gameObject.CompareTag(team.ToString()))
            {
                selected = hit.collider.transform.gameObject;
            }
            
        }
        return selected;
    }
}