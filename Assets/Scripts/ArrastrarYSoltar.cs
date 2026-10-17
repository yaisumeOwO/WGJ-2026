using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class ArrastrarYSoltar : MonoBehaviour
{
    private Collider2D col;
    private Vector3 PosicionDeInicio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col= GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        PosicionDeInicio = transform.position;
        transform.position = ObtenerPosicionMouse();

    }

    private void OnMouseDrag()
    {
        transform.position = ObtenerPosicionMouse();
    }

    private void OnMouseUp()
    {
        col.enabled = false;
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        col.enabled = true;
        if (hitCollider != null && hitCollider.TryGetComponent(out AreaDeDrop areaDeDrop)){
            areaDeDrop.OnObjectDrop(this);
        }
        else
        {
            transform.position = PosicionDeInicio;
        }
    }

    public Vector3 ObtenerPosicionMouse()
    {
        Vector3 p =Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        p.z =-1f;
        return p;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
