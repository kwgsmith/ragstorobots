using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISWearable : ISObject, IISEquipable, IISDestructible, IISGameObject
	{
		[SerializeField]int _durability;
		[SerializeField]int _maxDurability;
		[SerializeField]ISEquipmentSlot _equipmentSlot;
		[SerializeField]GameObject _prefab;
		
		
		public ISWearable()
		{
			_equipmentSlot = new ISEquipmentSlot ();
		}
		
		public ISWearable (int durability, int maxDurability, ISEquipmentSlot equipSlot, GameObject prefab)
		{
			_durability = durability;
			_maxDurability = maxDurability;
			_equipmentSlot = equipSlot;
			_prefab = prefab;
		}

		#region IISEquipable implementation
		
		public ISEquipmentSlot EquipmentSlot {
			get { return _equipmentSlot; }
		}
		
		#endregion
		
		#region IISDestructible implementation
		
		public void TakeDamage (int amount)
		{
			_durability -= amount;
			if (_durability < 0) 
				_durability = 0;
			
			if (_durability == 0)
				Break ();
		}
		
		//
		public void Repair ()
		{
			_maxDurability--;
			if (_maxDurability > 0)
				_durability = _maxDurability;
			else
				Break ();
		}
		
		//reduce the durability to zero
		public void Break ()
		{
			_durability = 0;
		}
		
		public int Durability {
			get { return _durability; }
		}
		
		public int MaxDurability {
			get { return _maxDurability; }
		}
		
		#endregion
		
		#region IISGameObject implementation
		
		public GameObject Prefab {
			get { return _prefab; }
		}
		
		#endregion
		
		//this code is to be placed in a new class later on
		
		public override void ShowStats()
		{
			base.ShowStats ();
			_durability = System.Convert.ToInt32(EditorGUILayout.TextField ("Durability: ", _durability.ToString()));
			_maxDurability = System.Convert.ToInt32(EditorGUILayout.TextField ("Max Durability: ", _maxDurability.ToString()));
			DisplayEquipmentSlot ();
			//prefab
			DisplayPrefab ();
			
		}
		
		public void DisplayEquipmentSlot()
		{
			GUILayout.Label ("Equipment Slot");
		}
		
		public void DisplayPrefab()
		{
			GUILayout.Label ("Prefab");
		}
	}
}

