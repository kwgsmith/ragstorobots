using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	public interface IISArmor
	{
		//armor rating of the armor
		int ArmorRating { get; set; }
		//the damage type that the armor protects against
		string DamageType { get; set; }
		//calculate and return how much damage reduction a piece of armor gives
		int ReduceDamage();
	}
	
}
