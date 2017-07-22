using UnityEngine;
using System.Collections;

public class SimpleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;//150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		//transform.Rotate(0, x, 0);
		transform.Translate(-x, 0, -z);
	}
}
