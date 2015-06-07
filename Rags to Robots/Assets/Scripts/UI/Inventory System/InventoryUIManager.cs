using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using WarpwareStudios.ItemSystem;

namespace WarpwareStudios.InventorySystem
{
	/*
	 * This class is for managing what is shown in the backpack
	 */
	public class InventoryUIManager : MonoBehaviour {

		public GameObject inventorySlotPrefab;
		public GameObject itemsPanel;

		public List<ItemSlot> itemSlots = new List<ItemSlot>();

		// Use this for initialization
		void Start () {
			UpdateInventorySlots (1);
		}
		
		// Update is called once per frame
		void Update () {

		}

		public void UpdateInventorySlots(int slotNum)
		{
			for(int i = 0; i < slotNum; i++)
			{
				//to keep current slots accurate, igore them by only adding more if necessary
				if(i >= itemSlots.Count)
				{
					GameObject newSlot = Instantiate(inventorySlotPrefab);
					newSlot.name = "Inventory Slot";
					newSlot.transform.SetParent(itemsPanel.transform, false);
					newSlot.GetComponent<ItemSlot>().ClearItem();
					itemSlots.Add(newSlot.GetComponent<ItemSlot>());
				}
			}
		}

		// NOTE: Debug statements left in the following for use to see if the adding of items is actually working
		// DO NOT DELETE until testing is done with more than one or two items


		public void AddToInventory(ISObject item, int totalSlotNum)
		{
			//Debug.Log ("Adding " + item.Name + " to inventory!");
			//if item exists add to the amount
			foreach (ItemSlot itemSlot in itemSlots) 
			{
				if(itemSlot.currentItem.Equals(item))
				{
					//Debug.Log ("Item already exists! Adding one to amount.");
					//this is quick and dirty, needs better implementation
					itemSlot.amount++;
					itemSlot.UpdateUI();
					return;
				}
			}
			//find first empty slot and put item in it
			if (itemSlots.Count <= totalSlotNum) 
			{
				//Debug.Log ("Inventory slots are not full");
				int count = 0;
				foreach (ItemSlot slot in itemSlots) 
				{
					//Debug.Log ("Checking slot " + count);
					if (slot.empty) 
					{
						//Debug.Log ("Checking slot " + count + " is empty!");
						slot.LoadItem (item);
						slot.empty = false;
						return;
					}
					count++;
				}
			}
		}
		
		public void RemoveFromInventory(ISObject item)
		{
			//Debug.Log ("Removing " + item.Name + " from inventory!");
			//if item exists subtract 1 from amount, then remove if amount is 0
			foreach (ItemSlot itemSlot in itemSlots) 
			{
				if(itemSlot.currentItem.Equals(item))
				{
					//Debug.Log ("Subtracting 1 from amount and removing if none left");
					//this is quick and dirty, needs better implementation
					itemSlot.amount--;
					if(itemSlot.amount == 0)
					{
						itemSlot.ClearItem();
					}
					itemSlot.UpdateUI();
					return;
				}
			}
		}

	}
}