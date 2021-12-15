using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    


    public void LoadMainGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(1);
    }
}
