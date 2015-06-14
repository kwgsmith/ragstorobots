using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WarpwareStudios.ItemSystem;

namespace WarpwareStudios.CraftingSystem
{
	public class CSRecipe : ICSRecipe
	{
		ISObject _item;
		Dictionary<ISObject, int> _partsList = new Dictionary<ISObject,int>();

		#region ICSRecipe implementation

		public ISObject Item { get { return _item; } }
		public Dictionary<ISObject, int> partsList { get { return _partsList; } }

		#endregion
	}
}
