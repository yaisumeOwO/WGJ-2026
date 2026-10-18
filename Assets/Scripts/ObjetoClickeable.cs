using UnityEngine;
public class ObjetoClickeable : MonoBehaviour
{
    public Dialogo sistemaDeDialogo;
    public int precio;
    public int indiceInicio;
    public int indiceFin;

    [Header("Sprites hiperdetallados")]
    public Sprite spriteGeneral;
    public Sprite spriteHiperdetallado;

    [Header("Checklist")]
    public string textoChecklist;

    private SpriteRenderer miRenderer;
    private bool viendoConLupa=false;

    void OnEnable()
    {
        miRenderer = GetComponent<SpriteRenderer>();
        viendoConLupa = false;
        if (spriteGeneral != null)
        {
            miRenderer.sprite=spriteGeneral;
        }
    }

    public void AlternarVistaLupa()
    {
        viendoConLupa = !viendoConLupa;
        if (viendoConLupa)
        {
            miRenderer.sprite = spriteHiperdetallado;
        }
        else
        {
            miRenderer.sprite = spriteGeneral;
        }
    }

    void OnMouseDown()
    {
        
    }
}