using UnityEngine;
using System.Collections;



public class GetObject : MonoBehaviour {

	public Transform self;
	public string objectName = "element";
	bool gotObject = false; 
	//public var getObjectKey = Input.k

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == objectName)
		{
			
		}
	}

	void OnTriggerEnter(Collider other)
	{
		print ("OnTriggerEnter");
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyUp(KeyCode.F)) {
			gotObject = !gotObject;
		}

		if (gotObject) {
			other.transform.parent = self.transform;
			print ("gotObject!");
		}
		print ("OnTriggerStay");
	}

	void Update () {
	
	}
}
