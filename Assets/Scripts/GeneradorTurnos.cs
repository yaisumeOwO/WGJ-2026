using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GeneradorTurnos : MonoBehaviour
{
    [Header("Economía y UI")]
    public int dinero = 100;
    public TextMeshProUGUI ContadorPesos;
    public PanelMover panelInferior;
    public TextMeshProUGUI textoLibreta;

    [Header("Sprites de los 3 Personajes")]
    public SpriteRenderer spriteRendererCliente;
    public Sprite spriteNino;       
    public Sprite spritePersonaje2; 
    public Sprite spritePersonaje3; 

    [Header("Objetos exclusivos del Niño ")]
    public GameObject[] objetosCorrea; 
    [Header("Objetos para los demás personajes")]
    public List<GameObject> objetosGenerales; 
    public GameObject objetoSeleccionado;

    public void AceptarTrato()
    {
        if (objetoSeleccionado != null)
        {
            ObjetoClickeable info = objetoSeleccionado.GetComponent<ObjetoClickeable>();
            if (info.esValido)
            {
                dinero += info.precio;
            }
            else
            {
                dinero -= info.precio;
            }
        }
        FinalizarTurno();
    }
    public void RechazarTrato()
    {
       
        FinalizarTurno();
    }

    private void FinalizarTurno()
    {
        if (ContadorPesos != null)
        {
            ContadorPesos.text = "$" + dinero;
        }
        if (panelInferior != null)
        {
            panelInferior.Bajar();
        }
        GenerarNuevoClienteYObjeto();
    }

    public void GenerarNuevoClienteYObjeto()
    {
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.SetActive(false);
        }
        int personajeRandom = Random.Range(0, 3);
        if (personajeRandom == 0)
        {
            spriteRendererCliente.sprite = spriteNino;
            int indiceCorrea = Random.Range(0, objetosCorrea.Length);
            objetoSeleccionado = objetosCorrea[indiceCorrea];
        }
        else
        {
            if (personajeRandom == 1)
                spriteRendererCliente.sprite = spritePersonaje2;
            else
                spriteRendererCliente.sprite = spritePersonaje3;
            int indiceObjeto = Random.Range(0, objetosGenerales.Count);
            objetoSeleccionado = objetosGenerales[indiceObjeto];
        }

        objetoSeleccionado.SetActive(true);

        ObjetoClickeable infoObjeto = objetoSeleccionado.GetComponent<ObjetoClickeable>();

        textoLibreta.text = infoObjeto.textoChecklist;
        infoObjeto.sistemaDeDialogo.startDialogue(infoObjeto.indiceInicio, infoObjeto.indiceFin);

        objetoSeleccionado.GetComponent<ObjetoClickeable>().sistemaDeDialogo.startDialogue(
            objetoSeleccionado.GetComponent<ObjetoClickeable>().indiceInicio,
            objetoSeleccionado.GetComponent<ObjetoClickeable>().indiceFin
        );
    }

    void Start()
    {
        if (ContadorPesos != null)
        {
            ContadorPesos.text = "$" + dinero;
        }
        GenerarNuevoClienteYObjeto();
    }
}