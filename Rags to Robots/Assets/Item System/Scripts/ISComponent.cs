using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISComponent : ISObject, IISComponent, IISStackable
	{
		int _recipeID;
		int _maxStack = 200;

		#region IISComponent implementation

		public int RecipeID { get { return _recipeID; } set { _recipeID = value; } }

		#endregion

		#region IISStackable implementation

		public int Stack (int amount)
		{
			throw new System.NotImplementedException ();
		}

		public int MaxStack { get { return _maxStack; } }

		#endregion

		//this code is to be placed in a new class later on
		
		public override void ShowStats()
		{
			
			base.ShowStats ();
			_recipeID = System.Convert.ToInt32(EditorGUILayout.TextField ("ID: ", _recipeID.ToString()));
			_maxStack = System.Convert.ToInt32(EditorGUILayout.TextField ("Maximum Stack Size: ", _maxStack.ToString()));
		}
	}	
}
