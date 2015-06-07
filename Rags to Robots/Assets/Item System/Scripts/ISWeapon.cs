using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISWeapon : ISWearable,IISWeapon
	{
		[SerializeField]int _minDamage;
		[SerializeField]string _damageType;


		public ISWeapon() : base()
		{
		}

		public ISWeapon (int durability, int maxDurability, ISEquipmentSlot equipSlot, GameObject prefab) : base(durability,maxDurability,equipSlot,prefab)
		{

		}
		#region IISWeapon implementation
		public int Attack ()
		{
			throw new System.NotImplementedException ();
		}

		public int MinDamage { get { return _minDamage; } set{ _minDamage = value; } }

		public string DamageType { get { return _damageType; } set{ _damageType = value; } }

		#endregion


		//this code is to be placed in a new class later on

		public override void ShowStats()
		{
			base.ShowStats ();
			_minDamage = System.Convert.ToInt32(EditorGUILayout.TextField ("Damage: ", _minDamage.ToString()));
		}

	
	}
}
