using System.Collections;
using UnityEngine;

// we want the cube to spin

public class Rotater : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        // the action needs to be smooth and frame rate independent
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	  
	}
}
