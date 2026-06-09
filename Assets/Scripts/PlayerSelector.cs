using UnityEngine;
using System.Collections.Generic;

public class PlayerSelector: MonoBehaviour
{
    //raycast
    public Camera cam;

    public GameObject ShootRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject selected = null;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            // Do something with the hit object
            if(hit.collider.gameObject.CompareTag("TeamOne"))
            {
                selected = hit.collider.transform.gameObject;
            }
            
        }
        return selected;
    }
}