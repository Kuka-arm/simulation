using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	public float minX = -50f;
	public float maxX = 50f;
	public bool active = false;

	public float sensitivity;
	public Camera cam;

	float rotY;
	float rotX;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
        if (!active)
        {
			return;
        }

		rotY += Input.GetAxis("Mouse X") * sensitivity;
		rotX += Input.GetAxis("Mouse Y") * sensitivity;
		rotX = Mathf.Clamp(rotX, minX, maxX);

		cam.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Cursor.visible && Input.GetMouseButtonDown(1))
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}
