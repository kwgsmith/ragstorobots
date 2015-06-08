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

	public int inventorySlots;
	
	public InventoryUIManager inventoryManager;

	// Use this for initialization
	void Awake () {
		inventorySlots = 16;
		inventoryManager = GameObject.Find ("GUI Manager").GetComponent<InventoryUIManager> ();
		inventoryManager.UpdateInventorySlots (inventorySlots);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddToInventory(ISObject item)
	{
		inventoryManager.AddToInventory (item, inventorySlots);
	}

	
	public void RemoveFromInventory(ISObject item)
	{
		inventoryManager.RemoveFromInventory (item);
	}

}
