using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISConsumable : ISObject, IISConsumable, IISStackable
	{
		[SerializeField]int _maxStack = 25;

		#region IISConsumable implementation
		public void Effect ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion
		
		#region IISStackable implementation
		public int Stack (int amount)
		{
			throw new System.NotImplementedException ();
		}
		public int MaxStack {
			get {
				throw new System.NotImplementedException ();
			}
		}
		#endregion

		public override void ShowStats()
		{
			
			base.ShowStats ();
			_maxStack = System.Convert.ToInt32(EditorGUILayout.TextField ("Maximum Stack Size: ", _maxStack.ToString()));
		}
	}
}
