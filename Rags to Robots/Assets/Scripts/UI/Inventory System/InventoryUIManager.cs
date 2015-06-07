using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
					Debug.Log (itemSlots.Count + " new slots created.");
				}
			}
		}
	}
}