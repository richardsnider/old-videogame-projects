using UnityEngine;
using System.Collections;

//This script is attached to the pre-fabricated photon object and destroys it after a certain amount of time past creation.
//I do this so that the game doesn't get slow and cluttered with photon objects as you keep playing.
public class PhotonDestruction : MonoBehaviour 
{
	public float time_until_destroyed = 2f; //2 seconds

	void Start () 
	{
		//Destroy the photon object after a set time.
		Destroy (gameObject, time_until_destroyed);
	}
}
