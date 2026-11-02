using UnityEngine;
public class KeyController : MonoBehaviour
{
    public bool MoonKey = false;
    public bool SunKey = false;
    public bool StarKey = false;
    public static KeyController instance;
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void MoonKeyCollect()
    {
        Debug.Log("got moon key");
        bool MoonKey = true;

    }
    public void SunKeyCollect()
    {
        Debug.Log("got sun key");
        bool SunKey = true;
    }
    public void StarKeyCollect()
    {
        Debug.Log("got star key");
        bool StarKey = true;
    }
}