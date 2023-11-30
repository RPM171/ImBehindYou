using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirsPersonCamera : MonoBehaviour
{


    //variables

    public float range = 100f;
    public Camera fpsCam;

    public int ammo = 35;
    public int mag = 2;

    public float mouseSens = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public float leanAmount = 50f;
    public float leanSpeed = 5f;

    //private Quaternion uprightRotation;
    
    //private Quaternion targetRotation;

    void Start()
    {
        //hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //lean 
       // uprightRotation = transform.rotation;
       //targetRotation = uprightRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        //rotation 
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 35f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

        //shooting method raycast type

        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo = ammo - 1;
            Shoot();
            Debug.Log("Ammo left" + ammo);
        }
        else
        {
            Reload();
        }

        if(ammo == 0)
        {
          
            Debug.Log("Mags left :" + mag);
            StartCoroutine(Reload());
        }
        //leaning

        /*if (Input.GetKeyDown(KeyCode.Q)) // Start leaning left
        {
            targetRotation = Quaternion.Euler(0, 0, -leanAmount);
        }
        else if (Input.GetKeyDown(KeyCode.E)) // Start leaning right
        {
            targetRotation = Quaternion.Euler(0, 0, leanAmount);
        }
        else if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E)) // Stop leaning
        {
            targetRotation = uprightRotation;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * leanSpeed);*/
    }

    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log("Hit" + hitInfo.transform.name);
        }
    }

   IEnumerator Reload()
    {
        Debug.Log("Rloading...");
        yield return new WaitForSeconds(2);
        ammo = 35;
        mag = mag - 1;
    }

    /*void Lean(float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * leanSpeed);
    }*/
}