using UnityEngine;

public class ResetBooleans : MonoBehaviour
{

    public KeyController controller;
    void Start()
    {
        if (GameObject.Find("Key Controller") != false) {
            controller = GameObject.Find("Key Controller").GetComponent<KeyController>();
            controller.SunKey = false;
            controller.StarKey = false;
            controller.MoonKey = false;
        }
    }

}
