using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour
{
   public List <GameObject> starPieces = new List<GameObject>();
    public DraggingController draggingController;
    public Vector3[] rotations;
    public GameObject completed;
    public GameObject starKey;
    public KeyController keyController;
    bool puzzleSolved;
    public Animator anim;

    public SceneTransition transition;


    void Start()
    {
        if (GameObject.Find("Key Controller")) keyController = GameObject.Find ("Key Controller").GetComponent<KeyController>();
        if (GameObject.Find("Dragging Controller")) draggingController = GameObject.Find("Dragging Controller").GetComponent<DraggingController>();

        for (int i = 0; i < gameObject.transform.childCount; i++) { 
            var child = gameObject.transform.GetChild(i);
            starPieces.Add(child.gameObject);
        }

        for (int i = 0; i < starPieces.Count; i ++) {
            starPieces[i].transform.localEulerAngles = rotations[Random.Range(0, rotations.Length)];
        }
    }

    void Update()
    {
        if (draggingController != null) {
            StartCoroutine(CheckPuzzle());

                if (completed.transform.childCount == starPieces.Count) {
                    print("WOO");
                    StartCoroutine(Exit());
                }

           

                
        }
        
    }

    IEnumerator CheckPuzzle()
    {
        for (int i = 0; i < starPieces.Count; i++)
        {
            if (starPieces[i].transform.localEulerAngles.z >= -45f &&
                starPieces[i].transform.localEulerAngles.z <= 45f)
            {

                starPieces[i].transform.localEulerAngles = Vector3.zero;

                starPieces[i].transform.parent = completed.transform;
            }

            if (draggingController.hit && draggingController.hit.transform.localEulerAngles == Vector3.zero && draggingController.hit.transform.CompareTag("Can Rotate"))
            {
                draggingController.hit.transform.tag = "Untagged";
                draggingController.hit.transform.gameObject.layer = 0;
            }
            yield return null;
        }
    }

    IEnumerator Exit() {
        yield return new WaitForSeconds(0.2f);

        if (SceneManager.GetSceneByName("Sample Puzzle 3").isLoaded)
        {
            transition.RightClutterWall();
        }
        else if (SceneManager.GetSceneByName("Sample Puzzle 2").isLoaded)
        {
            transition.LeftClutterWall();
        }
        else if (SceneManager.GetSceneByName("Sample Puzzle 1").isLoaded) { 
            transition.LeftClutterWall();
        }
    }
    
}
