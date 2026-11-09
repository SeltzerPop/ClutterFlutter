using UnityEngine;

public class DraggingController : MonoBehaviour
{
    private Transform dragging = null;
    Vector3 rotation = new Vector3(0, 0, 0);
    private Vector3 offset;
    [SerializeField] private LayerMask movableLayers;
    public GameObject[] interactableItems;
    public CursorActions cursorActions;


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, movableLayers);
        if (hit)
        {
            /*
             * Change cursor sprite when hovering over interactable objects
             */
            cursorActions.OnInteractableCursor();
        }
        else
        {
            cursorActions.NonInteractableCursor();
        }


        if (Input.GetMouseButtonDown(0)) //if mouse is clicked on moveable object 
        {
            if (hit)
            {
                /*
                 * Change cursor sprite when hovering over interactable objects
                 */
                cursorActions.OnInteractableCursor();

                Debug.Log("hit interactable");

                if (hit.transform.CompareTag("Can Rotate"))
                {

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
