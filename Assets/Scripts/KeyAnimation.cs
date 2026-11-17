using JetBrains.Annotations;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KeyAnimation : MonoBehaviour
{

    public DraggingController keyController;
    Animator animator;
    public AudioSource audioSource;
    public AudioClip clip;
    ParticleSystem particlsystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particlsystem = GetComponent<ParticleSystem>();
        if (GameObject.Find("Dragging Controller") != false)
        {
            keyController = GameObject.Find("Dragging Controller").GetComponent<DraggingController>();
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyController.keyHit)
        {
            audioSource.PlayOneShot(clip);

            KeyControllerCollect();
        }
    }

    void KeyControllerCollect() {
        
        StartCoroutine(KeyPulseAnimation());
        //StartCoroutine(PlayTwinkle());

    }

    IEnumerator KeyPulseAnimation() { 
        animator.SetTrigger("Pulse");
        particlsystem.Play();
        yield return new WaitForSeconds(0.2f);

        keyController.keyHit = false;

    }

    IEnumerator PlayTwinkle() {
        yield return new WaitForSeconds(0.2f);

    }
}
