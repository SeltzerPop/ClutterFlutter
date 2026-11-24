using UnityEngine;
using UnityEngine.UI;

public class InteractableTreasureChest : MonoBehaviour
{
    public MoveBackToOrigin moveBackToOrigin;
    public BoxCollider2D boxCollider;

   
    // Update is called once per frame
    void Update()
    {

        if (moveBackToOrigin.movedAway)
        {
            boxCollider.enabled = true;
            GetComponent<Button>().interactable = true;
        }
        else { 
            GetComponent<Button>().interactable = false;
            boxCollider.enabled = false;
        }
        

    }
}
