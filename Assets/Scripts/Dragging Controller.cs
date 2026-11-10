using UnityEngine;
using UnityEngine.InputSystem.DualShock.LowLevel;
using UnityEngine.UIElements;

public class DraggingController : MonoBehaviour
{
    private Transform dragging = null;
    Vector3 rotation = new Vector3 (0,0,10);
    private Vector3 offset;
    [SerializeField] private LayerMask movableLayers;
    RaycastHit2D hit;
    public bool raycastHit;
    public bool keyHit;


    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, movableLayers);

          if (hit) raycastHit = true;// I added this so that I can check the raycast from another script - Tati
          else raycastHit = false;


        if (Input.GetMouseButtonDown(0)) //if mouse is clicked on moveable object 
        {

            if (hit)
            {
                if (hit.transform.CompareTag("Key")) {
                    keyHit = true;

                }

                if (hit.transform.CompareTag("Can Rotate"))
                {

                    //rotate object on the z axis
                    if (Input.mousePosition.x < hit.transform.position.x)
                    {


                        hit.transform.localEulerAngles += rotation; //rotate to the left

                    }
                    else if (Input.mousePosition.x > hit.transform.position.x)
                    {

                        hit.transform.localEulerAngles -= rotation;
                    }
                }
                else { 
                    hit.transform.localEulerAngles = new Vector3(0, 0, 0); //reset rotation if not a rotatable object
                }
                if (hit.transform.CompareTag("Can Move"))
                {
                    dragging = hit.transform;
                    offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }
        if (dragging != null)
        {
            dragging.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }

  
}
