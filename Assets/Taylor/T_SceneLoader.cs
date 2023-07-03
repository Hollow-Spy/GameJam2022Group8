using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class T_SceneLoader : MonoBehaviour
{

    public void LoadNextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
