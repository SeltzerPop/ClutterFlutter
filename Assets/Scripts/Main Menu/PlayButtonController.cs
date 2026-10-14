using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButtonController : MonoBehaviour
{
    // Call this function from the button
    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
   
}