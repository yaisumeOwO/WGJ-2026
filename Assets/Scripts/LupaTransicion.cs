using UnityEngine;
using TMPro;

public class LupaTransicion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GeneradorTurnos generador;

    [Header("UI checklist")]
    public GameObject panelChecklist;
    public TextMeshProUGUI textoLibreta;

    void OnMouseDown()
    {
        if (generador.objetoSeleccionado != null)
        {
            ObjetoClickeable obj = generador.objetoSeleccionado.GetComponent<ObjetoClickeable>();
            if (obj != null)
            {

                obj.AlternarVistaLupa();
                if(panelChecklist!=null && textoLibreta != null)
                {
                    panelChecklist.SetActive(true);
                    textoLibreta.text = obj.textoChecklist;
                }
            }
        }
    }

    
}
