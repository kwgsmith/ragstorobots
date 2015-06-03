using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlot : MonoBehaviour {

	public Item currentItem;
	public Text currentItemName;
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

	public void LoadItem(Item item)
	{
		currentItem = item;
	}
	
	public void ClearItem()
	{
		currentItem = Item.Empty();
		amount = 0;
		UpdateUI ();
	}

	public void UpdateUI ()
	{
		currentItemName.text = currentItem.name;
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
