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
        // Salir de la aplicación
#if UNITY_EDITOR
        // Si estamos en el editor, detener la ejecución de Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si estamos en una plataforma compilada (como Android, Windows, etc.), cerrar la aplicación
            Application.Quit();
#endif
    }
}
