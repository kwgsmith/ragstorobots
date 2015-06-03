using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base object
	public interface IISObject 
	{

		//name
		//value - money value
		//icon
		//burden
		//quality level
		string ISName { get; set;}
		float ISValue { get; set;}
		Sprite ISIcon { get; set;}
		int ISBurden { get; set;}
		ISQuality ISQuality { get; set;}

		//these go to other item interfaces
		//equip
		//questItem flag
		//durability
		//takedamage
		//prefab
	}
}