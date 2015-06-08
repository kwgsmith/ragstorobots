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
		public GameObject itemPrefab;
		public GameObject itemsPanel;


		public List<InventorySlot> itemSlots = new List<InventorySlot>();

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
					itemSlots.Add(newSlot.GetComponent<InventorySlot>());
				}
			}
		}

		// NOTE: Debug statements left in the following for use to see if the adding of items is actually working
		// DO NOT DELETE until testing is done with more than one or two items


		public void AddToInventory(ISObject item, int totalSlotNum)
		{
			//Debug.Log ("Adding " + item.Name + " to inventory!");
			//if item exists add to the amount
			foreach (InventorySlot itemSlot in itemSlots) 
			{
				if(itemSlot.Item != null)
				{
					//get item info in current slot
					Item itemInSlot = itemSlot.Item.GetComponent<Item>();
					//if there is something in the slot, and it's name is equal to the current item add one to amount
					if(itemInSlot != null && itemInSlot.itemData.Name.Equals(item.Name))
					{
						//Debug.Log ("Item already exists! Adding one to amount.");
						//this is quick and dirty, needs better implementation
						itemInSlot.amount++;
						itemInSlot.UpdateUI();
						return;
					}
				}
			}
			//find first empty slot and put item in it
			if (itemSlots.Count <= totalSlotNum) 
			{
				//instantiate item
				GameObject temp = Instantiate (itemPrefab); 
				Item itemToAdd = temp.GetComponent<Item>();
				//prepare prefab with item info
				itemToAdd.LoadItem(item);

				//Debug.Log ("Inventory slots are not full");
				int count = 0;
				foreach (InventorySlot slot in itemSlots) 
				{
					//Debug.Log ("Checking slot " + count);
					//if slot is empty
					if (slot.Item == null) 
					{
						//Debug.Log ("Checking slot " + count + " is empty!");
						//put the item in the slot
						itemToAdd.transform.SetParent(slot.transform);
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
			foreach (InventorySlot itemSlot in itemSlots) 
			{
				if(itemSlot.Item != null)
				{
					//get item info in current slot
					Item itemInSlot = itemSlot.Item.GetComponent<Item>();
					//if there is something in the slot, and it's name is equal to the current item add one to amount
					if(itemInSlot != null && itemInSlot.itemData.Name.Equals(item.Name))
					{
						//Debug.Log ("Subtracting 1 from amount and removing if none left");
						//this is quick and dirty, needs better implementation
						itemInSlot.amount--;
						if(itemInSlot.amount == 0)
						{
							itemInSlot.ClearItem();
						}
						itemInSlot.UpdateUI();
						return;
					}
				}
			}
		}

	}
}