using System.Collections.Generic;
using UnityEngine;
public class GeneradorTurnos : MonoBehaviour
{
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
        objetoSeleccionado.GetComponent<ObjetoClickeable>().sistemaDeDialogo.startDialogue(
            objetoSeleccionado.GetComponent<ObjetoClickeable>().indiceInicio,
            objetoSeleccionado.GetComponent<ObjetoClickeable>().indiceFin
        );
    }

    void Start()
    {
        GenerarNuevoClienteYObjeto();
    }
}