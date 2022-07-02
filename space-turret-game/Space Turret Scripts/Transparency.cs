using UnityEngine;
using System.Collections;

//This simple script makes an object transparent.
public class Transparency : MonoBehaviour 
{
	public float transparency = 0.2f;

	void Update () 
	{
		//Grab the renderer material color and put it in the alpha_color variable.
		Color color_adjusted = renderer.material.color;

		//Set the alpha level of that color to the transparency float number.
		color_adjusted.a = transparency;

		//Set the actual renderer's material color to the adjusted color
		renderer.material.color = color_adjusted;
	}
}
