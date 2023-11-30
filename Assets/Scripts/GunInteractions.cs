using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInteractions : MonoBehaviour
{
    // Variables
    public Animator animator; // Reference to the Animator component
    private Vector3 lastPosition; // The last recorded position of the character
    private float idleTimer; // Timer to track idle time

    void Start()
    {
        lastPosition = transform.position; // Initialize lastPosition
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != lastPosition) // If the character has moved...
        {
            idleTimer = 0; // Reset the idle timer
            animator.SetBool("isIdle", false); // Stop the idle animation
        }
        else // If the character has not moved...
        {
            idleTimer += Time.deltaTime; // Increase the idle timer

            if (idleTimer >= 4) // If the character has been idle for 4 seconds...
            {
                animator.Play("metarig|idle"); // Play the idle animation
            }
        }

        lastPosition = transform.position; // Update lastPosition for the next frame

        if (Input.GetKeyDown(KeyCode.R)) // If the 'R' key is pressed...
        {
            animator.SetBool("isReloading", true); // Start the reload animation
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Reload")
                 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetBool("isReloading", false); // Stop the reload animation
        }
    }


}

