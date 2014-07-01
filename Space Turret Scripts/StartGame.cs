using UnityEngine;
using System.Collections;

//This script is attached to the Start Game cube object in the menu. 
// It switches cameras, and enables the turret and disables the menu once it is clicked on.
public class StartGame : MonoBehaviour 
{
	public Camera menu_camera;
	public Camera game_camera;
	public GameObject turret_object;
	public GameObject menu_object;
	
	void Start () 
	{
		//Start with the menu camera enabled, and the game camera and turret disabled.
		menu_camera.enabled = true;
		game_camera.enabled = false;
		turret_object.SetActive (false);
	}

	void OnMouseDown() //When the start game cube is clicked on.
	{
		//Disable the menu and camera
		menu_camera.enabled = false;
		menu_object.SetActive (false);

		//Enable the turret camera and object.
		game_camera.enabled = true;
		turret_object.SetActive (true);	

		//Hide the cursor so it doesn't get in the way of the cross hair.
		Screen.showCursor = false;
	}
}
