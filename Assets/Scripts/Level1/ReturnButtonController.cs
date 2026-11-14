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

    void Update()
    {
        if (keyController != null)
        {

            if (keyController.MoonKey)
            {
                MoonKey = true;
            }
            else if (!keyController.MoonKey)
            {
                MoonKey = false;
            }

            if (keyController.SunKey)
            {
                SunKey = true;
            }
            else if (!keyController.SunKey)
            {
                SunKey = false;
            }

            if (keyController.StarKey)
            {
                StarKey = true;
            }
            else if (!keyController.StarKey)
            {
                StarKey = false;
            }
        }
    }
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
    public void ReturnLvl2() {
        if (!SunKey) { 
            SceneManager.LoadScene(7); // load original scene 2 
        }
        else {
            Debug.Log("completed lvl2");
            SceneManager.LoadScene(11); // load completed scene 2
        }

    }

    public void ReturnLvl3()
    {
        if (!StarKey)
        {
            SceneManager.LoadScene(12); // load original scene 3 
        }
        else
        {
            Debug.Log("completed lvl3");
            SceneManager.LoadScene(16); // load completed scene 3

        }
    }
}
