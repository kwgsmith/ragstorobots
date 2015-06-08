using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base object
	public interface IISObject 
	{
		string Name { get; set;}
		float Value { get; set;}
		Sprite Icon { get; set;}
		int Weight { get; set;}
		ISQuality Quality { get; set;}

		//questItem flag
	}
}