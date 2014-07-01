using UnityEngine;
using System.Collections;

//This script is attached to the Quit cube game object in the menu. It closes the application when it is clicked.
public class QuitScript : MonoBehaviour 
{
	void OnMouseDown()
	{
		Application.Quit ();
	}
}
