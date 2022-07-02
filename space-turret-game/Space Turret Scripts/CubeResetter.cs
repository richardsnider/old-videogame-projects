using UnityEngine;
using System.Collections;

//This script is attached to the cubes and continually resets their position
//to the center of the platform after a certain amount of time.
public class CubeResetter : MonoBehaviour 
{
	float initial_x; float initial_y; float initial_z;
	float initial_x_rotation; float initial_y_rotation; float initial_z_rotation;
	public float time_until_reset = 15f;
	float timer;

	void Awake() //When cube is first created in game.
	{
		//Grab the original coordinates of the cube.
		initial_x = transform.position.x;
		initial_y = transform.position.y;
		initial_z = transform.position.z;

		//Get the original rotation of the cube
		initial_x_rotation = transform.rotation.x;
		initial_y_rotation = transform.rotation.y;
		initial_z_rotation = transform.rotation.z;

		//Load the timer with the reset time
		timer = time_until_reset;
	}
	
	void Update () //Every frame
	{
		timer -= Time.deltaTime; //Countdown the timer

		if (timer < 0) //If time interval has elapsed
		{
			//Reset the position and rotation of the cube to the original coordinates.
			transform.position = new Vector3(initial_x, initial_y, initial_z);
			transform.Rotate(new Vector3(initial_x_rotation, initial_y_rotation, initial_z_rotation));

			//Refill the timer
			timer = time_until_reset;

			//Reset the velocity and rotation velocity of the cube to zero.
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
		}
	}
}
