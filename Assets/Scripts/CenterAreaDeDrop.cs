using UnityEngine;

public class CenterAreaDeDrop : MonoBehaviour, AreaDeDrop
{
    public void OnObjectDrop ( ArrastrarYSoltar obj)
    {
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        Debug.Log("Objeto dropeado aqui");
    }
}
