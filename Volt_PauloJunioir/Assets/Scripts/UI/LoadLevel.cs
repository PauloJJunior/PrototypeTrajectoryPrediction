using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public void LoadSceneLevel(string levelName)
    {
        SFXController.instance.PlayClip(SFXController.instance.transitionClip);
        SceneManager.LoadScene(levelName);
        

    }

    public void LoadCurrentScene()
    {
        SFXController.instance.PlayClip(SFXController.instance.transitionClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
