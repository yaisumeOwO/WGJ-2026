using UnityEngine;
using TMPro;
using System.Collections;

public class LupaTransicion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GeneradorTurnos generador;

    [Header("UI checklist")]
    public GameObject panelChecklist;
    public TextMeshProUGUI textoLibreta;

    [Header("Animación de la Lupa")]
    public Transform puntoCentro;      
    public float duracionViaje = 0.3f;
    public float tiempoEnCentro = 0.15f;

    private Vector3 posicionInicial;
    private bool animando = false;


    void Start()
    {
        posicionInicial = transform.localPosition;
    }

    void OnMouseDown()
    {
        if (!animando && generador.objetoSeleccionado != null)
        {
            ObjetoClickeable obj = generador.objetoSeleccionado.GetComponent<ObjetoClickeable>();
            if (obj != null)
            {
                StartCoroutine(AnimarLupaYCambiarSprite(obj));
            }
        }
    }

    IEnumerator AnimarLupaYCambiarSprite(ObjetoClickeable obj)
    {
        animando = true;
        
        Vector3 destinoCentro = puntoCentro != null ? puntoCentro.localPosition : new Vector3(0f, 0f, -2f);
        destinoCentro.z = transform.localPosition.z; 
        
        float tiempo = 0f;
        while (tiempo < duracionViaje)
        {
            tiempo += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, tiempo / duracionViaje);
            transform.localPosition = Vector3.Lerp(posicionInicial, destinoCentro, t);
            yield return null;
        }
        transform.localPosition = destinoCentro;
        obj.AlternarVistaLupa();

        if (panelChecklist != null && textoLibreta != null)
        {
            panelChecklist.SetActive(true);
            textoLibreta.text = obj.textoChecklist;
        }
       
        yield return new WaitForSeconds(tiempoEnCentro);
      
        tiempo = 0f;
        while (tiempo < duracionViaje)
        {
            tiempo += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, tiempo / duracionViaje);
            transform.localPosition = Vector3.Lerp(destinoCentro, posicionInicial, t);
            yield return null;
        }
        transform.localPosition = posicionInicial;
        animando = false;
    }

}
