using UnityEngine;
using UnityEngine.SceneManagement;

//This class is responsible for loading new scenes.
public class LoadLevel : MonoBehaviour
{

    //Load new Scene
    public void LoadSceneLevel(string levelName)
    {
        //Player Clip Audio Button Transition
        SFXController.instance.PlayClip(SFXController.instance.transitionClip);

        //Load Scene
        SceneManager.LoadScene(levelName);
        

    }

    // Load Current Scene
    public void LoadCurrentScene()
    {
        //Player Clip Audio Button Transition
        SFXController.instance.PlayClip(SFXController.instance.transitionClip);

        //Load Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
