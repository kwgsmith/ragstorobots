using UnityEngine;
using System.Collections;


namespace WarpwareStudios.ItemSystem
{
	
	public interface IISDestructible{
		int Durability { get; }
		int MaxDurability { get; }
		void TakeDamage (int amount);
		void Repair();
		void Break();
	}
	
}