using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationEnder : MonoBehaviour
{
    /// <summary>
    /// Written by Shinnosuke (2024/10/28)
    /// </summary>
    public void EndApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
