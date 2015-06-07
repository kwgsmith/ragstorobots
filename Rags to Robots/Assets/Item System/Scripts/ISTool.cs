using UnityEngine;
using UnityEditor;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	//base weapon
	[System.Serializable]
	public class ISTool : ISWearable, IISTool
	{
		public ISTool():base()
		{

		}

		#region IISTool implementation
		public void Buff ()
		{
			throw new System.NotImplementedException ();
		}
		#endregion

		public override void ShowStats()
		{	
			base.ShowStats ();
		}

	}
}
