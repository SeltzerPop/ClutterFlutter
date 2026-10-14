using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnButtonController : MonoBehaviour
{
    public void ReturnLvl1()
    {
        Debug.Log("returned");
        SceneManager.LoadScene(1);

    }
}
