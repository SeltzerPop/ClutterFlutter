using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public LayerMask UI;


    public void OnInteractableCursor() {
        // pulled from Unity Documentation: 
        //https://docs.unity.com/en-us/engine/6000.0/script-reference/unityengine/cursor/setcursor

        //increase size of cursor 

        Cursor.SetCursor(cursorSprites[1],hotspot,cursorMode);

    }
    public void NonInteractableCursor() {
        Cursor.SetCursor(cursorSprites[0],hotspot,cursorMode);
    }
    public void OnRaycastUI()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, UI);

        if (hit)
        {
            if (hit.transform.CompareTag("Interactable Button"))
            {
                print("");
                OnInteractableCursor();
            }
            else
            {
                NonInteractableCursor();
            }
        }
       

    }
    public void OnCursorClick()
    {
        
    }
}
