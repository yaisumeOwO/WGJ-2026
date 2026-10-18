using System.Collections;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    public Vector3 posicionArriba;

    public float duracion = 0.5f;

    private Vector3 posicionAbajo;
    private bool estaArriba = false;
    private Coroutine rutinaMovimiento;

    private void Start()
    {
        // Guardamos la posición inicial como la posición de abajo
        posicionAbajo = transform.localPosition;
    }

    /// <summary>
    /// Cambia entre subir y bajar el panel.
    /// Puede asignarse al evento OnClick de un Button UI.
    /// </summary>
    public void TogglePanel()
    {
        if (estaArriba)
        {
            Bajar();
        }
        else
        {
            Subir();
        }
    }

    public void Subir()
    {
        if (rutinaMovimiento != null) StopCoroutine(rutinaMovimiento);
        rutinaMovimiento = StartCoroutine(MoverHacia(posicionArriba));
        estaArriba = true;
    }

    public void Bajar()
    {
        if (rutinaMovimiento != null) StopCoroutine(rutinaMovimiento);
        rutinaMovimiento = StartCoroutine(MoverHacia(posicionAbajo));
        estaArriba = false;
    }

    private IEnumerator MoverHacia(Vector3 destino)
    {
        Vector3 inicio = transform.localPosition;
        float tiempo = 0f;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;

            // Suavizado de movimiento (EaseInOut)
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.localPosition = Vector3.Lerp(inicio, destino, t);
            yield return null;
        }

        transform.localPosition = destino;
    }
}
