using UnityEngine;
using UnityEngine.UI;

public class InteractableTreasureChest : MonoBehaviour
{
    public MoveBackToOrigin moveBackToOrigin;

   
    // Update is called once per frame
    void Update()
    {

        if (moveBackToOrigin.movedAway)
        {
            GetComponent<Button>().interactable = true;
        }
        else { 
            GetComponent<Button>().interactable = false;
        }
        

    }
}
