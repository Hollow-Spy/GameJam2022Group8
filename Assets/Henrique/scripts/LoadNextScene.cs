using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{

    [SerializeField] int NextSceneID;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LoadScene(NextSceneID);
        }
    }
    public void LoadScene(int nextscene)
    {
        StartCoroutine(LoadNumerator(nextscene));
    }

    IEnumerator LoadNumerator(int nextscene)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(NextSceneID);

    }
}
