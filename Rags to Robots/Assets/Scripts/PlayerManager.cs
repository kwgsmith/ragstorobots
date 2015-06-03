using UnityEngine;
using System.Collections;

/*
 * This class is for tracking player specific things like skills,
 * and upgrades, total inventory slots, what you actually have in your
 * pack etc
 */
public class PlayerManager : MonoBehaviour {

	public static int inventorySlots;

	public static Item[] inventory;
	// Use this for initialization
	void Start () {
		inventorySlots = 16;
		inventory = new Item[inventorySlots];

		//initialize each spot in the array as empty
		for(int i = 0; i < inventory.Length; i++) 
		{
			 inventory[i] = Item.Empty();
		}

		//update inventory the first time
		InventoryUIManager.update = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void AddToInventory(Item item)
	{
		
	}
}
