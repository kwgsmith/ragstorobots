using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	public interface IISWeapon 
	{
		int MinDamage { get; set; }
		string DamageType { get; set; }
		int Attack();
	}

}
