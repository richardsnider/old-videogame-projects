using UnityEngine;
using System.Collections;

//This script is attached to the turret object.  It controls aiming (+ audio) and moving of the turret.
public class MovementScript : MonoBehaviour 
{
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;
	float initial_y;
	float current_x;
	float current_z;
	float audio_timer;

	//Awake is called before Start()
	void Awake()
	{
		//Keep turret on the platform so that it can't fly.
		initial_y = gameObject.transform.position.y;
		//Lower the audio volume of turning.wav, otherwise it's annoying.
		audio.volume = 0.1f;
	}

	// Update is called once per frame
	void Update () 
	{
		float mouse_X_turn = Input.GetAxis ("Mouse X");
		float mouse_Y_turn = Input.GetAxis ("Mouse Y");
		bool forward_down = Input.GetButtonDown ("Forward Move");
		bool forward_held = Input.GetButton ("Forward Move");
		bool reverse_down = Input.GetButtonDown ("Reverse");
		bool reverse_held = Input.GetButton ("Reverse");

		//If mouse is currently moving, play the turning audio.
		if(mouse_X_turn != 0f || mouse_Y_turn != 0f) 
		{ 
			if(!audio.isPlaying) audio.Play();
			else audio_timer = 0.1f; //Putting a timer helps make it sound less glitchy.
		}
		else //If there is no mouse movement
		{
			audio_timer -= Time.deltaTime; //Countdown the timer.
			if (audio_timer <= 0f) { audio.Stop (); } //When timer runs out, stop the audio.
		}

		//Control turning the turrret left and right based on mouse movement
		if(mouse_X_turn > 0f) //If mouse turns right
		{ 
			//Rotate the turret up (which is actually right) at the turn speed in meters per second.
			//I use world Space.World for side turning so that the turret doesn't tilt on it's x-axis.
			transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime, Space.World);
		}
		else if(mouse_X_turn < 0f) //If mouse turns left
		{ 
			//Rotate the turret down (which is actually left) at the turn speed in meters per second.
			//I use world Space.World for side turning so that the turret doesn't tilt on it's x-axis.
			transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime, Space.World);  
		} 

		//Control vertical rotation of turret based on mouse movement
		if(mouse_Y_turn > 0f) //If mouse turns up
		{ 
			//Rotate the turret in the forward direction (up actually)
			transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
		}
		else if(mouse_Y_turn < 0f) //If mouse turns down
		{ 
			//Rotate the turret in the forward direction (up actually)
			transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);
		}

		//Control moving forward and backwards
		if (forward_down || forward_held) //If forward button is pressed
		{
			//Move the turret in the right vector (actually forward) in meters per second.
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

			//Stop the turret from flying.
			resetYcoordinates(transform);
		}
		else if(reverse_down || reverse_held) //If reverse button is pressed
		{
			//Move the turret in the left vector (actually back) in meters per second.
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

			//Stop the turret from flying.
			resetYcoordinates(transform);
		}

		//If the escape key is hit, close the game.
		if (Input.GetKeyDown(KeyCode.Escape) || transform.position.y < 10) 
		{
			Application.Quit();
		}
	}

	//Lock the Y-coordinates of the turret so it can't fly
	void resetYcoordinates(Transform turret_transform)
	{
		//Grab the current x and z coordinates of the turret.
		current_x = turret_transform.position.x;
		current_z = turret_transform.position.z;
		
		//Reset the position coordinates of the y direction only
		turret_transform.position = new Vector3(current_x,initial_y,current_z);

		//Kill the velocities of the turret's rigidbody so that it doesn't become too unstable.
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = Vector3.zero;
	}
}
