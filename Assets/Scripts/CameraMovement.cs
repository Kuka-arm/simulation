using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float rotSpeed;
    public float movSpeed;

    public float upperLimit;
    public float lowerLimit;

    public GameObject mainCam;
    public GameObject secondCam;

    public static bool StartMenu = true;
    public LayerMask noUI;
    public LayerMask allUI;
    public Camera UICamera;

    public GameObject startUI;
    public GameObject cinemaButtonOn;
    public GameObject cinemaButtonOff;

    private void Start()
    {
        UICamera.cullingMask = noUI;
    }

    void Update()
    {
        if (Input.anyKeyDown && StartMenu)
        {
            StartMenu = false;
            startUI.SetActive(false);
            cinemaButtonOff.SetActive(true);
            UICamera.cullingMask = allUI;
        }

        if (StartMenu)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + 0.2f, transform.localRotation.eulerAngles.z);
            return;
        }

        float rotationSpeed = rotSpeed * Time.deltaTime;
        float movementSpeed = movSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (mainCam.activeSelf)
            {
                transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y + rotationSpeed, transform.localRotation.eulerAngles.z);
            }
            else
            {
                //secondCam.transform.localRotation = Quaternion.Euler(secondCam.transform.localRotation.eulerAngles.x, secondCam.transform.localRotation.eulerAngles.y + rotationSpeed, secondCam.transform.localRotation.eulerAngles.z);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (mainCam.activeSelf)
            {
                transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y - rotationSpeed, transform.localRotation.eulerAngles.z);
            }
            else
            {
                //secondCam.transform.localRotation = Quaternion.Euler(secondCam.transform.localRotation.eulerAngles.x, secondCam.transform.localRotation.eulerAngles.y - rotationSpeed, secondCam.transform.localRotation.eulerAngles.z);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (mainCam.activeSelf)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + movementSpeed, lowerLimit, upperLimit), transform.position.z);
            }
            else
            {
                //secondCam.transform.position = new Vector3(secondCam.transform.position.x, Mathf.Clamp(secondCam.transform.position.y + movementSpeed * 2, 2.5f, 6f), secondCam.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (mainCam.activeSelf)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y - movementSpeed, lowerLimit, upperLimit), transform.position.z);
            }
            else
            {
                //secondCam.transform.position = new Vector3(secondCam.transform.position.x, Mathf.Clamp(secondCam.transform.position.y - movementSpeed * 2, 2.5f, 6f), secondCam.transform.position.z);
            }
        }
    }

    public void SwitchView()
    {
        mainCam.SetActive(!mainCam.activeSelf);
        secondCam.SetActive(!secondCam.activeSelf);
        secondCam.GetComponent<ThirdPersonCamera>().active = !secondCam.GetComponent<ThirdPersonCamera>().active;
    }

    public void CinemaModeOn()
    {
        UICamera.cullingMask = noUI;
        cinemaButtonOn.SetActive(false);
        cinemaButtonOff.SetActive(true);
    }

    public void CinemaModeOff()
    {
        UICamera.cullingMask = allUI;
        cinemaButtonOn.SetActive(true);
        cinemaButtonOff.SetActive(false);
    }
}
