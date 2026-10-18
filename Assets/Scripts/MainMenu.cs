using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar entre escenas

public class MainMenu : MonoBehaviour
{
    // Método para iniciar el juego cargando la siguiente escena
    public void Jugar()
    {
        // Carga la siguiente escena según el Build Index
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Alternativa: Si conoces el nombre exacto de la escena de juego:
        SceneManager.LoadScene("InGame");
    }

    // Método para cerrar el juego
    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Mensaje para verificar en el Editor
        Application.Quit(); // Cierra la aplicación (solo funciona en builds ejecutables)
    }
}