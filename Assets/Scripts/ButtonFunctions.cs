using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }

    public void ExitApplication()
    {
        // Salir de la aplicaci�n
#if UNITY_EDITOR
        // Si estamos en el editor, detener la ejecuci�n de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si estamos en una plataforma compilada (como Android, Windows, etc.), cerrar la aplicaci�n
            Application.Quit();
#endif
    }
}
