using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    public string[] dialogos;
    public TextMeshProUGUI dialogoEnPantalla;
    public int index= 0;


    public void SetDialogue(int indice)
    {
        dialogoEnPantalla.text = dialogos[indice];
    }

    public void nextDialogue()
    {
        index++;
        SetDialogue(index);
      
    }

    public void startDialogue() { }
    void Start()
    {
        SetDialogue(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
