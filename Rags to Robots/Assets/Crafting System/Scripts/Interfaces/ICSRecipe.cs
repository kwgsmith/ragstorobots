using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using WarpwareStudios.ItemSystem;

namespace WarpwareStudios.CraftingSystem
{
	//base recipe
	public interface ICSRecipe
	{
		//item to create
		ISObject Item { get; }
		//objects needed to create this item
		Dictionary<ISObject,int> partsList { get; }
	}
}
