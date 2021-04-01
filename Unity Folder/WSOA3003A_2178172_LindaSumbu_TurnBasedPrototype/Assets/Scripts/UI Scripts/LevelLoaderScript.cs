using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator sceneAnim;

    public float transitionTime;

 
    void Update()
    {
        
    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {
        sceneAnim.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(LevelIndex);
    }
}
