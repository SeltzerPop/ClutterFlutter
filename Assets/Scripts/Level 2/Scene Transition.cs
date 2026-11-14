using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public SceneAsset[] targetScene;
    public KeyController keyController;

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
}
