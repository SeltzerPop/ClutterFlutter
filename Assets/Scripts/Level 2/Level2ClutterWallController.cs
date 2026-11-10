using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2ClutterWallController1: MonoBehaviour
{
    // each change scene refers to the button in level 1 scene
    public void ChangeSceneRightWall()
    {
        Debug.Log("rightwalllvl1");
        SceneManager.LoadScene(3);
    }
    public void ChangeSceneLeftWall()
    {
        Debug.Log("leftwalllvl1");
        SceneManager.LoadScene(2);
    }
    public void ChangeSceneDoor()
    {
        Debug.Log("doorlvl1");
        SceneManager.LoadScene(4);
    }
    public void ChangeSceneOpenDoor()
    {
        Debug.Log("opendoorlvl1");
        SceneManager.LoadScene(5);
    }
    public void ChangeSceneLevel1Complete()
    {
        Debug.Log("lvl1complete");
        SceneManager.LoadScene(6);
    }
    
}