using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public SceneAsset[] targetScene;
    public KeyController keyController;

    void Start()
    {
        if (GameObject.Find("Key Controller") != false)
        {
            keyController = GameObject.Find("Key Controller").GetComponent<KeyController>();
        }
    }
    public void DoorScene()
    {
        
       SceneManager.LoadScene(targetScene[0].name); 
    }

    public void LeftClutterWall() {
        SceneManager.LoadScene(targetScene[1].name);

    }

    public void RightClutterWall() {
        SceneManager.LoadScene(targetScene[2].name);
    }

    public void ExitToLevel2 (){ 
        if (keyController != null)
        {
            if (keyController.SunKey)
            {
                SceneManager.LoadScene(targetScene[4].name);
            }
            else {
                SceneManager.LoadScene(targetScene[3].name);

            }
        }
        else { 
            SceneManager.LoadScene(targetScene[3].name);
        }
    }  

    public void ExitToLevel3()
    {
        if (keyController != null)
        {
            if (keyController.StarKey)
            {
                SceneManager.LoadScene(targetScene[6].name);
            }
            else
            {
                SceneManager.LoadScene(targetScene[5].name);
            }
        }
        else
        {
            SceneManager.LoadScene(targetScene[5].name);
        }

    }
    
    public void ExitToLevel3Complete()
    {
        SceneManager.LoadScene(targetScene[6].name);
    }
}
