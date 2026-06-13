using UnityEngine;

public class VisualManager : MonoBehaviour
{
    [SerializeField] GameObject ghostModel;
    private bool previewOngoing = false;


    public void SetPreSelect(bool truthorfalsehoods)
    {
        previewOngoing = truthorfalsehoods;
        ghostModel.SetActive(truthorfalsehoods);
    }

    private void Update()
    {
        if (previewOngoing)
        {
            //ghostModel.transform.position = mouse
        }
    }



}
