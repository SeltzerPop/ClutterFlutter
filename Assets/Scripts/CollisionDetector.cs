using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CollisionDetector : MonoBehaviour
{
    public Button KeyButton;
    private bool untouched = true;
    void Start()
    {
        Debug.Log("keysetfalse");
        KeyButton.interactable = false;
    }
    void Update()
    {
        if ((Input.GetMouseButtonDown(0) && untouched == true))
        Debug.Log("touched candle");
        KeyButton.interactable = true;
        untouched = false;
    }
    

}
