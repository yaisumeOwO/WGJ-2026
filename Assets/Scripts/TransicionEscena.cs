using UnityEngine;

public class TransicionEscena : MonoBehaviour
{
   ParteSuperior pos transform;
    ParteInferior parteInferior;

    public void ShowInspectionScreen()
    {
        parteInferior.transform.position= pos;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

  
}
