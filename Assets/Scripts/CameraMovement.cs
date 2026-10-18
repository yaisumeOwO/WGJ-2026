using JetBrains.Annotations;
using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{

    [SerializeField] 
    private Camera cam;

    [SerializeField]
    private float zoom=10;

    //limitar paneo
    public Vector2 minLimit;
    public Vector2 maxLimit;

    //limitar zoom
    public float minZoom = 3f;
    public float maxZoom = 10f;

    private Vector3 dragOrigin;
    //declarar variable bool de continuar desde el script de cliente/dialogos



    // Update is called once per frame
    void Update()
    {
        //if (continuar=true) {

        //    
        //}
        PanCamera();
        ScrollZoom();   
        
    }

    private void PanCamera()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        //calculate distance between drag origin and new position if it's still held
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
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

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position;

        //delimitar el paneo
        targetPosition.x=Mathf.Clamp(targetPosition.x, minLimit.x, maxLimit.x);
        targetPosition.y= Mathf.Clamp(targetPosition.y, minLimit.y, maxLimit.y);

        transform.position= targetPosition;
    }
}
