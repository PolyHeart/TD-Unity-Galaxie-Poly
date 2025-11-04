using UnityEngine;

public class QuitApp : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

#if UNITY_EDITOR
            // Permet aussi d’arrêter le mode Play dans l’éditeur
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

