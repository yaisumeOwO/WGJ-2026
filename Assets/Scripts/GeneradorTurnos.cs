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
    public GameObject panelGameOver;


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

    private int ultimoPersonaje = -1;
    private GameObject ultimoObjeto = null;

    public void AceptarTrato()
    {
        if (objetoSeleccionado != null)
        {
            ObjetoClickeable info = objetoSeleccionado.GetComponent<ObjetoClickeable>();
            dinero -= info.precio;
            Debug.Log("Trato ACEPTADO. Compraste: " + objetoSeleccionado.name + " por $" + info.precio + ". Dinero restante: $" + dinero);
        }
        FinalizarTurno();
    }

    public void RechazarTrato()
    {
        Debug.Log("Trato RECHAZADO. Pasando al siguiente cliente. Dinero actual: $" + dinero);
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

        if (dinero < ObtenerPrecioMasBarato())
        {
            GameOverPorBancarrota();
            return; // Detenemos aquí para que ya no genere otro cliente
        }

        GenerarNuevoClienteYObjeto();
    }

    private int ObtenerPrecioMasBarato()
    {
        int masBarato = int.MaxValue;
        foreach (GameObject obj in objetosCorrea)
        {
            if (obj != null)
            {
                int p = obj.GetComponent<ObjetoClickeable>().precio;
                if (p < masBarato) masBarato = p;
            }
        }
        foreach (GameObject obj in objetosGenerales)
        {
            if (obj != null)
            {
                int p = obj.GetComponent<ObjetoClickeable>().precio;
                if (p < masBarato) masBarato = p;
            }
        }
        return masBarato;
    }

    private void GameOverPorBancarrota()
    {
        Debug.Log("¡Game Over! Te quedaste en bancarrota.");

        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.SetActive(false);
        }

        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void GenerarNuevoClienteYObjeto()
    {
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado.SetActive(false);
        }

        int personajeRandom = Random.Range(0, 3);
        while (personajeRandom == ultimoPersonaje)
        {
            personajeRandom = Random.Range(0, 3);
        }
        ultimoPersonaje = personajeRandom;

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
            if (objetosGenerales.Count > 1)
            {
                while (objetosGenerales[indiceObjeto] == ultimoObjeto)
                {
                    indiceObjeto = Random.Range(0, objetosGenerales.Count);
                }
            }
            objetoSeleccionado = objetosGenerales[indiceObjeto];
        }

        ultimoObjeto = objetoSeleccionado;
        objetoSeleccionado.SetActive(true);

        ObjetoClickeable infoObjeto = objetoSeleccionado.GetComponent<ObjetoClickeable>();

        if (textoLibreta != null)
        {
            textoLibreta.text = infoObjeto.textoChecklist;
        }

        if (infoObjeto.sistemaDeDialogo != null)
        {
            infoObjeto.sistemaDeDialogo.startDialogue(infoObjeto.indiceInicio, infoObjeto.indiceFin);
        }
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