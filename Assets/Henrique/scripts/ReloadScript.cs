using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour
{public void LoadScene(string name)
    {
        FindObjectOfType<DifficultyScaling>().startTime = Time.time;

        DontDestroy[] objs = FindObjectsOfType<DontDestroy>();
        for(int i=0;i<objs.Length;i++)
        {
            Destroy(objs[i].gameObject);
        }

        SceneManager.LoadScene(name);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            LoadScene("MainScene");
        }
            
    }
}
