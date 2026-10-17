using UnityEngine;
using TMPro;



public class DineroSistema : MonoBehaviour
{
    public int count=1;
    public TextMeshProUGUI ContadorPesos;
    //Mandar a llamar la variable de precio del script de objeto
    //Mandar a llamar la variable bool de decision (comprar o rechazar)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ContadorPesos.text = "" + count;
    }

    // Update is called once per frame
    void Update()
    {
        ////Aqui va a ir si la decision es comprar, se resta el dinero de tu inventario
        //if (decision = true)
        //{
        //    count -= precioObjeto


        //} 
        //Contador en pantalla
        ContadorPesos.text = "" + count;

    }
}
