using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace WarpwareStudios.ItemSystem
{
	//pieces of the crafting system
	public interface IISComponent
	{
		//id for indicating what recipes this is used in
		int RecipeID { get; set; }
	}
	
}
