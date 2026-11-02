using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnButtonController : MonoBehaviour
{
    public bool MoonKey = false;
    public void ReturnLvl1()
    {
        if (MoonKey == false)
        {
        Debug.Log("returned");
        SceneManager.LoadScene(1);
        }
        else if (MoonKey == true)
        {
            Debug.Log("completedlvl1");
            SceneManager.LoadScene(6);
        }
    }
    public void MoonKeyCollect()
    {
        Debug.Log("got moon key");
        bool MoonKey = true;

    }
}
