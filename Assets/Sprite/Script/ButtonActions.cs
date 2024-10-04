using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public string sceneName;

    // Método para cambiar de escena
    public void GoToNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    // Método para salir del juego
    public void QuitGame()
    {
        // Sale del juego
        Application.Quit();

        // Para propósitos de prueba en el editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
