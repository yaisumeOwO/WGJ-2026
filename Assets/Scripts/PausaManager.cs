using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaManager : MonoBehaviour
{
    // Carga la primera escena (Menú principal, índice 0)
    public void Reiniciar()
    {
        // Reanudamos la escala de tiempo por si el juego estaba pausado
        Time.timeScale = 1f;

        // Carga la escena en la posición 0 del Build Profiles (Scenes/Menu)
        SceneManager.LoadScene(0);
    }

    // Cierra la aplicación/ejecutable
    public void Salir()
    {
        Debug.Log("Saliendo del ejecutable..."); // Mensaje de control para la consola
        Application.Quit(); // Cierra el ejecutable del juego
    }
}