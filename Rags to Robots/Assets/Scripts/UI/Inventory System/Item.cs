using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using WarpwareStudios.ItemSystem;


namespace WarpwareStudios.InventorySystem
{
	public class Item : MonoBehaviour {

		public ISObject itemData;
		public Text itemNameText;
		public Text amountText;
		public int amount;
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
			//Debug.Log ("Loading " + item.Name + " into inventory slot!");
			itemData = item;
			amount++;
			UpdateUI ();
		}
		
		public void ClearItem()
		{
			Destroy (this.gameObject);
		}

		public void UpdateUI ()
		{
			itemNameText.text = itemData.Name;
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
