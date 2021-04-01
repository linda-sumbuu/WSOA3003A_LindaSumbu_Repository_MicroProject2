using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void SceneChange(int level)

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);

    }
}
