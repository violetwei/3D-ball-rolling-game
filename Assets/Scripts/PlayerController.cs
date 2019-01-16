using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    // add a reference for (Win Text) UI text element

    // accessing another component on the same game object: create a variable to hold this reference in our script and will set this reference in the Start() function
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set up the starting value of count
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate () 
    {
        // grabs the input from our player through the keyboard
        // the two float variables record the input from the horizontal and vertical axis, which are controlled by the keys on a keyboard
        // our player game object uses a rigidbody and interacts with a physics engine
        // we will use this input to add forces to the rigidbody and move the player game object in the scene
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertial = Input.GetAxis ("Vertical");

        // function to the rigidbody class -- AddForce, adds a force to the rigidbody, as a result the rigidbody will startt moving
        // Vector3 holds 3 decimal values in one container, this makes it easy for us to move around and use values for things like a force in 3D space
        // which requires a value for force on each of the X,Y and Z axis.
        // or to describe a rotation which would also require a value for each of the X, Y and Z axis.

        // new Vector3 made up of an X, Y and Z (x, y, z) , the x, y, z values will determine the direction of the force which we will add to our ball
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertial);

        rb.AddForce (movement * speed);
	}

    // this will be called by Unity when our player game object first touches a trigger collider
    // we are given as an argument, a reference to the trigger collider that we have touched, the Collider called other
    // this reference gives us a way to get a hold of the colliders that we touch 

    // Destroy(other.gameObject);
    //with this code, when we touch another trigger collider, we will destroy the game object that the trigger coliider is attached to, through the reference other.gameObject
    // By destroying that game object, the game object all of its components and all of its children and their components are removed from the scene.

    // for this assignment, we won't destroy the other game object, we will deactivate it.

    // will be called every time we touch a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // deactivate that game object
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }

    }

    void SetCountText ()
    {
    	countText.text = "Count: " + count.ToString ();
    	if (count >= 12){
    		winText.text = "You Win!";
    	}

    }

}
