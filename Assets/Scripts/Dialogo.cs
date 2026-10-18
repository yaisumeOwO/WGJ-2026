using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public string[] dialogos;
    public TextMeshProUGUI dialogoEnPantalla;
    public GameObject butDialogo;

    [Header("Botones que se activan al terminar de hablar")]
    public GameObject butWorkArea;
    public GameObject butAceptar;
    public GameObject butRechazar;

    public int index= 0;
    public int indexFinal = 0;


    public void SetDialogue(int indice)
    {
        dialogoEnPantalla.text = dialogos[indice];
    }

    public void nextDialogue()
    {
        if (index < indexFinal)
        {
            index++;
            SetDialogue(index);
        }
        else
        {
            butDialogo.SetActive(false);
            if (butWorkArea != null) butWorkArea.SetActive(true);
            if (butAceptar != null) butAceptar.SetActive(true);
            if (butRechazar != null) butRechazar.SetActive(true);
        }
        
      
    }

    public void startDialogue(int inicio, int fin) 
    {
        index = inicio;
        indexFinal = fin;
        butDialogo.SetActive(true);

        if (butWorkArea != null) butWorkArea.SetActive(false);
        if (butAceptar != null) butAceptar.SetActive(false); 
        if (butRechazar != null) butRechazar.SetActive(false);

        SetDialogue(index);
    }
    
}
