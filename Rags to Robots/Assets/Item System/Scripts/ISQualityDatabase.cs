using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WarpwareStudios.ItemSystem
{
	public class ISQualityDatabase : ScriptableObject
	{
		//[SerializeField]
		public List<ISQuality> database = new List<ISQuality>();
	}
}
