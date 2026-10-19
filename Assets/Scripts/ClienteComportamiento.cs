using System.Collections;
using UnityEngine;
public class ClienteComportamiento : MonoBehaviour
{
    public float duracion = 2f; 
    private SpriteRenderer spriteRenderer;
    public ScriptableObject personaje;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color tmp = spriteRenderer.color;
        tmp.a = 0f;
        spriteRenderer.color = tmp;
        StartCoroutine(AparecerGradualmente());
    }
    IEnumerator AparecerGradualmente()
    {
        float tiempoPasado = 0f;
        Color tmp = spriteRenderer.color;
        while (tiempoPasado < duracion)
        {
            tiempoPasado += Time.deltaTime;
            tmp.a = Mathf.Clamp01(tiempoPasado / duracion);
            spriteRenderer.color = tmp;
            yield return null; 
        }
        tmp.a = 1f;
        spriteRenderer.color = tmp;
    }
}
