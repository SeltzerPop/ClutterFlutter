using UnityEngine;

public class ToggleText : MonoBehaviour
{
    public CursorActions actions;
    public LayerMask mask;
    public GameObject textBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (actions ==null) GameObject.Find("Cursor Controller").GetComponent<CursorActions>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, mask);

        if (hit)
        {
            if (hit.transform.CompareTag("Interactable Button")) {
                actions.OnInteractableCursor();
            }

            if (hit.transform.name == "Door Button")
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
                {
                    textBox.SetActive(true);
                }
            }
            else {
                textBox.SetActive(false);
            }
        }
        else { 
           
            actions.NonInteractableCursor();
        }

    }
}
