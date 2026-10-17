using JetBrains.Annotations;
using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{

    [SerializeField] 
    private Camera cam;

    [SerializeField]
    private float zoom=10;

    private Vector3 dragOrigin;

    // Update is called once per frame
    void Update()
    {
        PanCamera();
        ScrollZoom();   
        
    }

    private void PanCamera()
    {
        //save mouse position in world space
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        //calculate distance between drag origin and new position if it's still held
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

        
            print("origin" + dragOrigin + "nesPosition" + cam.ScreenToWorldPoint(Input.mousePosition) + "=difference" + difference);
            //move camera by distance
            cam.transform.position += difference;

        }
    }

    public void ScrollZoom()
    {
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;

        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
    }

}
