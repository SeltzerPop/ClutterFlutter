using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    
    public string[] targetScene;
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
        
       SceneManager.LoadScene(targetScene[0]); 
    }

    public void LeftClutterWall() {
        SceneManager.LoadScene(targetScene[1]);

    }

    public void RightClutterWall() {
        SceneManager.LoadScene(targetScene[2]);
    }

    public void ExitToLevel2 (){ 
        if (keyController != null)
        {
            if (keyController.SunKey)
            {
                SceneManager.LoadScene(targetScene[4]);
            }
            else {
                SceneManager.LoadScene(targetScene[3]);

            }
        }
        else { 
            SceneManager.LoadScene(targetScene[3]);
        }
    }  

    public void ExitToLevel3()
    {
        if (keyController != null)
        {
            if (keyController.StarKey)
            {
                SceneManager.LoadScene(targetScene[6]);
            }
            else
            {
                SceneManager.LoadScene(targetScene[5]);
            }
        }
        else
        {
            SceneManager.LoadScene(targetScene[5]);
        }

    }
    
    public void ExitToLevel3Complete()
    {
        SceneManager.LoadScene(targetScene[6]);
    }
}
