using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	public class ISObject : IISObject 
	{

		[SerializeField] string _name;
		[SerializeField] float _value;
		[SerializeField] Sprite _icon;
		[SerializeField] int _burden;
		[SerializeField] ISQuality _quality;

	#region IISObject implementation

		public string ISName {
			get { return _name; }
			set { _name = value; }
		}

		public float ISValue {
			get { return _value; }
			set { _value = value; }
		}

		public Sprite ISIcon {
			get { return _icon; }
			set { _icon = value; }
		}

		public int ISBurden {
			get { return _burden; }
			set { _burden = value; }
		}

		public ISQuality ISQuality {
			get { return _quality; }
			set { _quality = value; }
		}

	#endregion


	}
}