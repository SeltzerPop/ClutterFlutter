using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReturnButtonController : MonoBehaviour
{
    public bool MoonKey = false;
    public bool SunKey = false;
    public bool StarKey = false;
    public KeyController keyController;


    void Start()
    {
        if (GameObject.Find("Key Controller") != false)
        {
            keyController = GameObject.Find("Key Controller").GetComponent<KeyController>();
        }
    }


    public void ReturnLvl1()
    {

        if (keyController != null)
        {
            if (!keyController.MoonKey)
            {
                Debug.Log("returned");
                SceneManager.LoadScene(1);
            }
            else if (keyController.MoonKey)
            {
                Debug.Log("completedlvl1");

                SceneManager.LoadScene(6);
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
    