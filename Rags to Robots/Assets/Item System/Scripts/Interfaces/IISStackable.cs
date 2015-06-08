using UnityEngine;
using System.Collections;

namespace WarpwareStudios.ItemSystem
{
	
	public interface IISStackable{

		int MaxStack { get; }
		int Stack(int amount); //default of zero

	}
	
}
