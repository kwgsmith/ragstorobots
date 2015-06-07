using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISArmor : ISWearable, IISArmor
	{
		int _armorRating;
		string _damageType;

		public ISArmor() : base()
		{

		}

		public ISArmor (int durability, int maxDurability, ISEquipmentSlot equipSlot, GameObject prefab) : base(durability,maxDurability,equipSlot,prefab)
		{
			
		}
		#region IISArmor implementation

		public int ReduceDamage ()
		{
			throw new System.NotImplementedException ();
		}

		public int ArmorRating { get { return _armorRating;	} set { _armorRating = value; } }

		public string DamageType { get { return _damageType;	} set { _damageType = value; } }

		#endregion


		//this code is to be placed in a new class later on
		
		public override void ShowStats()
		{
			
			base.ShowStats ();
			_armorRating = System.Convert.ToInt32(EditorGUILayout.TextField ("Armor Rating: ", _armorRating.ToString()));
			_damageType = EditorGUILayout.TextField ("Damage Type: ", _damageType);
		}


	}
}
