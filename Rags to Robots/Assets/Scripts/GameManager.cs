using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WarpwareStudios.ItemSystem;

public class GameManager : MonoBehaviour {

	public static List<ISObject> itemDatabase;

	//ISWeaponDatabase weaponDatabase;
	//ISArmorDatabase armorDatabase;
	//ISToolDatabase toolDatabase;
	public ISComponentDatabase componentDatabase;
	//ISConsumableDatabase consumableDatabase;

	// Use this for initialization
	void Start () {
		itemDatabase = new List<ISObject> ();
		LoadItemDatabase ();
		PlayerManager player = GameObject.Find ("Player").GetComponent<PlayerManager>();
		player.AddToInventory (itemDatabase [0]);
		player.AddToInventory (itemDatabase [0]);
		player.RemoveFromInventory (itemDatabase [0]);

	}
	
	// Update is called once per frame
	void Update () {
	}

	void LoadItemDatabase()
	{

		for(int i = 0; i < componentDatabase.Count; i++) 
		{
			Debug.Log (componentDatabase.Get(i).Name);
			itemDatabase.Add(componentDatabase.Get(i));
		}

	}

	public static ISObject FindItemInDatabase(string name)
	{
		foreach (ISObject item in itemDatabase) 
		{
			if(item.Name.Equals(name))
			{
				return item;
			}
		}

		Debug.Log ("Item not found!");

		return null;
	}
}
