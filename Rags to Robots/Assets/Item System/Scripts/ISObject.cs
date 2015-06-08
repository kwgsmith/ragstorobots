using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	[System.Serializable]
	public class ISObject : IISObject 
	{

		[SerializeField] string _name;
		[SerializeField] float _value;
		[SerializeField] Sprite _icon;
		[SerializeField] int _weight;
		[SerializeField] ISQuality _quality;

	#region IISObject implementation

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public float Value {
			get { return _value; }
			set { _value = value; }
		}

		public Sprite Icon {
			get { return _icon; }
			set { _icon = value; }
		}

		public int Weight {
			get { return _weight; }
			set { _weight = value; }
		}

		public ISQuality Quality {
			get { return _quality; }
			set { _quality = value; }
		}

	#endregion

		//this code is to be placed in a new class later on

		public virtual void ShowStats()
		{	

			_name = EditorGUILayout.TextField ("Name: ", _name);
			_value = (float)System.Convert.ToDecimal(EditorGUILayout.TextField ("Value: ", _value.ToString()));
			_weight = System.Convert.ToInt32(EditorGUILayout.TextField ("Weight: ", _weight.ToString()));
			DisplayIcon ();
			DisplayQuality ();

		}
		public void DisplayIcon()
		{
			GUILayout.Label ("Icon");
		}
		public void DisplayQuality()
		{
			GUILayout.Label ("Quality");
		}

	}
}