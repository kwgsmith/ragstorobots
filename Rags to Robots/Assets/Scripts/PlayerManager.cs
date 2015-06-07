using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WarpwareStudios.InventorySystem;
using WarpwareStudios.ItemSystem;


/*
 * This class is for tracking player specific things like skills,
 * and upgrades, total inventory slots, what you actually have in your
 * pack etc
 */
public class PlayerManager : MonoBehaviour {

	public static int inventorySlots;
	
	public InventoryUIManager inventoryManager;

	// Use this for initialization
	void Awake () {
		inventorySlots = 16;
		inventoryManager = GameObject.Find ("Inventory").GetComponent<InventoryUIManager> ();
		inventoryManager.UpdateInventorySlots (inventorySlots);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddToInventory(ISObject item)
	{
		Debug.Log ("Adding " + item.Name + " to inventory!");
		//if item exists add to the amount
		foreach (ItemSlot itemSlot in inventoryManager.itemSlots) 
		{
			if(itemSlot.currentItem.Equals(item))
			{
				Debug.Log ("Item already exists! Adding one to amount.");
				//this is quick and dirty, needs better implementation
				itemSlot.amount++;
				itemSlot.UpdateUI();
				return;
			}
		}
		//find first empty slot and put item in it
		if (inventoryManager.itemSlots.Count <= inventorySlots) 
		{
			Debug.Log ("Inventory slots are not full");
			int count = 0;
			foreach (ItemSlot slot in inventoryManager.itemSlots) 
			{
				Debug.Log ("Checking slot " + count);
				if (slot.empty) 
				{
					Debug.Log ("Checking slot " + count + " is empty!");
					slot.LoadItem (item);
					slot.empty = false;
					return;
				}
				count++;
			}
		}
	}

}
