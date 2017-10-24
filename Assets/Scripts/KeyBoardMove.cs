using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent (typeof(Camera))]
public class KeyBoardMove : MonoBehaviour
{

	public float speed = 4.0f;
	public float shiftSpeed = 16.0f;
	public bool showInstructions = true;

	private Vector3 startEulerAngles;
	private Vector3 startMousePosition;
	private float realTime;
	private bool mouseKeyBoardOn = false;

	//-------------------------------------------------
	void OnEnable ()
	{
		realTime = Time.realtimeSinceStartup;
	}


	//-------------------------------------------------
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.K)) {
			mouseKeyBoardOn = !mouseKeyBoardOn;
		}


		if (mouseKeyBoardOn) {
			float forward = 0.0f;
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
				print ("move ");
				forward += 1.0f;
			}
			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
				forward -= 1.0f;
			}

			float right = 0.0f;
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				right += 1.0f;
			}
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				right -= 1.0f;
			}

			float currentSpeed = speed;
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				currentSpeed = shiftSpeed;
			}

			float realTimeNow = Time.realtimeSinceStartup;
			float deltaRealTime = realTimeNow - realTime;
			realTime = realTimeNow;

			Vector3 delta = new Vector3 (right, 0.0f, forward) * currentSpeed * deltaRealTime;

			transform.position += transform.TransformDirection (delta);

			Vector3 mousePosition = Input.mousePosition;

			if (Input.GetMouseButtonDown (0) /* left mouse */ || Input.GetKeyDown (KeyCode.V)) {
				startMousePosition = mousePosition;
				startEulerAngles = transform.localEulerAngles;
			}

			if (Input.GetMouseButton (0) /* left mouse */) {
				Vector3 offset = mousePosition - startMousePosition;
				transform.localEulerAngles = startEulerAngles + new Vector3 (-offset.y * 360.0f / Screen.height, offset.x * 360.0f / Screen.width, 0.0f);
			}

			transform.position += new Vector3(Input.mouseScrollDelta.x,Input.mouseScrollDelta.y,0) ;

		}
	}

}
