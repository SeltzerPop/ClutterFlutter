using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;
using Unity.VisualScripting;
using System.Net;

public class MoveBackToOrigin : MonoBehaviour
{
    public GameObject coveringGameObject;

    public List<Vector3> originalPosition = new List<Vector3> ();
    public List<Transform> moveableObjects = new List<Transform>();
    public Transform surroundKeyPosition;
    public DraggingController draggingController;
    public bool grabbedItem = false;
    GameObject currentCollisionOBJ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        if (GameObject.Find("Dragging Controller") != false)
        {
            //getting dragging controller for raycast 
            draggingController = GameObject.Find("Dragging Controller").GetComponent<DraggingController>();
        }


        for (int i = 0; i < gameObject.transform.childCount; i++) {
            // adding all children to list 
             var child = gameObject.transform.GetChild(i).gameObject;
            moveableObjects.Add(child.transform);


            
            originalPosition.Add(child.transform.localPosition);

           /*if the surrounding key position target and the Game Object covering the key is set in the inspector, 
            * change the original position of the obstructing object to the new target position
            */
           
            if (surroundKeyPosition != null)
            {
                if (coveringGameObject != null)
                {
                    if (child.transform.name == coveringGameObject.name)
                    {
                        originalPosition[i] = surroundKeyPosition.localPosition;
                    }
                }
            }
        }


    }

    void Update()
    {
        float speed = 5f * Time.deltaTime; // set speed for movement

        for (int i = 0; i < moveableObjects.Count; i++)
        {
            //get current colliding object and store in variable when rraycast is hit and mouse button is pressed
            if (draggingController.hit && Input.GetMouseButtonDown(0)) { 
                currentCollisionOBJ = draggingController.hit.collider.gameObject;
            }

            if (Input.GetMouseButtonUp(0) && moveableObjects[i].localPosition != originalPosition[i])
            {

                grabbedItem = true;
               
            }

            //pulled moving objects over time from Unity Documentation: 
            // https://docs.unity.com/en-us/engine/6000.6/script-reference/unityengine/vector3/movetowards
            
            /*
             * if current colliding obj stored in raycast matches to the moved object name, move the object back to it's origin point 
             */
            if (grabbedItem && currentCollisionOBJ.name == moveableObjects[i].name) {

                //change covering game object over key 's collider very small so player can select the key. 
                if (coveringGameObject != null && moveableObjects[i].name == coveringGameObject.name) moveableObjects[i].GetComponent<BoxCollider2D>().size = Vector3.one/4f;
                
                moveableObjects[i].localPosition = Vector3.MoveTowards(moveableObjects[i].localPosition, originalPosition[i], speed);

            }

            //if currently moving object is close to it's original position, stay at original position point

            if (grabbedItem && Vector3.Distance(moveableObjects[i].localPosition, originalPosition[i]) < 0.001f)
            {
                moveableObjects[i].localPosition = originalPosition[i];
               
               
            }
        }
    }
    

}

