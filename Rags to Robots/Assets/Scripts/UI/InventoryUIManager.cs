using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 * This class is for managing what is shown in the backpack
 */
public class InventoryUIManager : MonoBehaviour {

	public GameObject inventorySlotPrefab;
	public GameObject itemsPanel;
	public static bool update;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (update) 
		{
			for(int i = 0; i < PlayerManager.inventorySlots; i++)
			{
				GameObject newSlot = Instantiate(inventorySlotPrefab);
				newSlot.transform.SetParent(itemsPanel.transform, false);
				newSlot.GetComponent<ItemSlot>().ClearItem();
			}
			update = false;
		}
	}
}
