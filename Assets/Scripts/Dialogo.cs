using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public string[] dialogos;
    public TextMeshProUGUI dialogoEnPantalla;
    public GameObject butDialogo;
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
        }
        
      
    }

    public void startDialogue(int inicio, int fin) 
    {
        index = inicio;
        indexFinal = fin;
        butDialogo.SetActive(true);
        SetDialogue(index);
    }
    
}
