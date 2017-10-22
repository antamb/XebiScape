using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectServer : MonoBehaviour {

	bool placed=false;
	bool placing=false;
	Collider collided;
	void OnTriggerEnter(Collider col)
	{
		Debug.Log(col.gameObject.name + " collision detected");
		if (col.gameObject.CompareTag("ServerTag"))
		{

			collided = col;
			placing = true;

			if (Vector3.Distance(col.gameObject.transform.position, this.gameObject.transform.position )<1)
			{
				placed = true;
				//placing = false;
				Debug.Log(col.gameObject.name + " Well placed");

			}

		}
	}

	void Update(){
		if (placing) {
			float speed=2f;
			Debug.Log(collided.gameObject.name + "  placing");
			Debug.Log("destination"+this.gameObject.name+this.gameObject.transform.position+this.gameObject.transform.localPosition);
			float step = speed * Time.deltaTime;
			Vector3 destination =this.gameObject.transform.position;
			//destination.Scale(this.gameObject.transform.transform.lossyScale);
			collided.attachedRigidbody.velocity = new Vector3 (0,0,0);
			collided.attachedRigidbody.angularVelocity =new  Vector3 (0,0,0);
			Debug.Log(" "+collided.gameObject.transform.position +" "+destination+" "+ Vector3.MoveTowards(collided.gameObject.transform.position,  destination, step));
			collided.gameObject.transform.position = Vector3.MoveTowards(collided.gameObject.transform.position,  destination, step);
			collided.gameObject.transform.position = Vector3.RotateTowards(collided.gameObject.transform.position,destination, step, step);
		}
	}
}
