using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using WarpwareStudios.ItemSystem;


namespace WarpwareStudios.InventorySystem
{
	public class ItemSlot : MonoBehaviour {

		public ISObject currentItem;
		public Text currentItemName;
		public Text amountText;
		public int amount;
		public bool empty = true;
		public bool update;

		void Update ()
		{
			if (update) 
			{
				UpdateUI();
				update = false;
			}
		}

		public void LoadItem(ISObject item)
		{
			Debug.Log ("Loading " + item.Name + " into inventory slot!");
			currentItem = item;
			amount++;
			UpdateUI ();
		}
		
		public void ClearItem()
		{
			empty = true;
			currentItem = new ISObject();
			amount = 0;

			UpdateUI ();
		}

		public void UpdateUI ()
		{
			currentItemName.text = currentItem.Name;
			SetTextNumberOfItems ();
		}

		public void SetTextNumberOfItems()
		{
			if (amount == 0) {
				amountText.text = "";
			} 
			else 
			{
				amountText.text = amount.ToString();
			}
		}

	}
}
