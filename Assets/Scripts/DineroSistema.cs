using UnityEngine;
using TMPro;



public class DineroSistema : MonoBehaviour
{
    public int count;
    public TextMeshProUGUI ContadorPesos;
    private ObjetoClickeable precio;

    //Mandar a llamar la variable bool de decision (comprar o rechazar)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        precio = GetComponent<ObjetoClickeable>();
        ContadorPesos.text = "" + count;
    }

    // Update is called once per frame
    void Update()
    {
        precio = GetComponent<ObjetoClickeable>();
        ////Aqui va a ir si la decision es comprar, se resta el dinero de tu inventario
        //if (decision = true)
        //{
        //    count -= objeto


        //} 
        //Contador en pantalla
        ContadorPesos.text = "" + count;

    }
}
