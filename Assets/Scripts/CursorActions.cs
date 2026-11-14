using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CursorActions : MonoBehaviour
{
    /*
     * This script is changing the cursor sprite when the cursor is hovering over an interactable object.
     * 
     * cursor should turn from no outline to a yellow outline on the following: 
     *          1) Clutter Wall 1
     *          2) Clutter Wall 2
     *          3) Locked Door Wall 
     *          4) Any interactible UI Buttons (Scroll & Return Button)
     *          5) Moveable/Draggable objects
     */


    public Texture2D[] cursorSprites;
    CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;
    public DraggingController draggableController;
    public KeyController keyController;

    void Start()
    {
        if (GameObject.Find("Dragging Controller") != false) { 
            draggableController = GameObject.Find("Dragging Controller").GetComponent<DraggingController>();
        }

        if (GameObject.Find("Key Controller") != false)
        {
            keyController = GameObject.Find("Key Controller").GetComponent<KeyController>();
        }
    }
    public void OnInteractableCursor()
    {
        // pulled from Unity Documentation: 
        //https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/cursor/setcursor

        //change cursor sprite to yellow highlighted outline

        
        Cursor.SetCursor(cursorSprites[1], hotspot, cursorMode);

    }
    public void NonInteractableCursor()
    {
        // turn off the yellow highlighted outline and return to default cursor sprite
        Cursor.SetCursor(cursorSprites[0], hotspot, cursorMode);
    }

    void Update()
    {
        if (draggableController != null)
        {
            if (draggableController.raycastHit)
            {
                OnInteractableCursor();
                print("Detecting item");
            }
            else
            {
                NonInteractableCursor();
            }

            if (draggableController.raycastHit && keyController != null) {

                if (draggableController.keyHit) { 
                    keyController.MoonKeyCollect();
                }
            }
        }
       
        //if (EventSystem.current.)
        //{
        //    print("Working");
        //}

    }
}
