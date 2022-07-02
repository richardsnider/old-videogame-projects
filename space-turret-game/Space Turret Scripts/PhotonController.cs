using UnityEngine;
using System.Collections;

//This script is attached to the turret object twice and each controls a photon's movement.
//When the mouse is clicked, the photon is instantiated as a rigidbody and a force is added to it in the barrel's direction.
public class PhotonController : MonoBehaviour 
{
	public Rigidbody photonPrefab; //The prefabricated photon
	public Transform barrelEnd; //The coordinates of the end of the turret barrel.
	public float photon_force = 3000; //The force of the photon leaving the barrel.
	Rigidbody photonInstance; //An instance of the pre-fabricated photon.
	
	void Update () 
	{
		//For some reason, the button boolean has to be in the update functions.
		bool fire_down = Input.GetButtonDown ("Fire");

		if (fire_down) //If mouse is clicked
		{
			//Instantiate the prefabricated photon at the barrelEnd transforms position and rotation.
			photonInstance = Instantiate(photonPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;

			//Because it's a Rigidbody, I can add a force to it in the forward direction of the end of the barrel.
			photonInstance.AddForce(barrelEnd.forward * photon_force);
		}
	}
}
