using UnityEngine;
using System.Collections;

//This script is attached to the barrel ends of the turret and simply plays the shoot.wav audio sound when player fires.
public class CannonSound : MonoBehaviour 
{
	void Update () 
	{
		//For some reason, the button boolean has to be in the update functions.
		bool fire_down = Input.GetButtonDown ("Fire"); 

		if (fire_down) //If mouse is clicked
		{ 
			audio.Play(); //Play shooting sound
		}
	
	}
}
