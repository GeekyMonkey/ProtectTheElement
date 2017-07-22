using UnityEngine;
using System.Collections;

public class HoldItems : MonoBehaviour {


	public float speed = 10;
	public bool canHold = true;
	public GameObject element;
	public Transform guide;
	string elementTag = "element";

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.F))
		{
			if (!canHold)
				throw_drop();
			else
				Pickup();
		}//mause If

		if (!canHold && element)
			element.transform.position = guide.position;

	}//update

	//We can use trigger or Collision
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == elementTag)
		if (!element) // if we don't have anything holding
			element = col.gameObject;

		print ("OnTriggerEnter");
	}

	//We can use trigger or Collision
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == elementTag)
		{
			if (canHold)
				element = null;
		}
	}


	private void Pickup()
	{
		if (!element)
			return;

		//We set the object parent to our guide empty object.
		element.transform.SetParent(guide);

		//Set gravity to false while holding it
		//element.GetComponent<Rigidbody>().useGravity = false;

		//we apply the same rotation our main object (Camera) has.
		element.transform.localRotation = transform.rotation;
		//We re-position the ball on our guide object 
		element.transform.position = guide.position;

		canHold = false;
	}

	private void throw_drop()
	{
		if (!element)
			return;

		//Set our Gravity to true again.
		//element.GetComponent<Rigidbody>().useGravity = true;
		// we don't have anything to do with our ball field anymore
		element = null; 
		//Apply velocity on throwing
		//guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;

		//Unparent our ball
		guide.GetChild(0).parent = null;
		canHold = true;
	}
}//class