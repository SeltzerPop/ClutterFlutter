using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMain : MonoBehaviour
{
    [Range(1, 5)]
    public float duration;
    public SceneTransition transition;
    
    void Update()
    {
        if (SceneManager.GetSceneByName("End Scene").isLoaded)
        {
            StartCoroutine(StartTimerTransition());

        }
        
    }

    IEnumerator StartTimerTransition() { 
        yield return new WaitForSeconds(duration);
        transition.BackToMainMenu();

    }
}
