using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // need two variables here

    // A public GameObject reference to the player
    public GameObject player;

    // hold our offset value, offset is private because we can se that value here in the script
    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate runs every frame, just like Update
    // but it is guaranteed to run after all items have been processed in update
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}

    // so when we set the position of the camera, we know absolutely that the player has moved for that frame
}
