using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{

    public DraggingController keyController;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (keyController == null)
        {
            return;
        }
        else { 
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyControllerCollect();
    }

    void KeyControllerCollect() {
        if (keyController.keyHit) { 
          
            StartCoroutine(KeyPulseAnimation());

        }

    }

    IEnumerator KeyPulseAnimation() { 
        animator.SetTrigger("Pulse");
        yield return new WaitForSeconds(0.2f);
        keyController.keyHit = false;

    }
}
