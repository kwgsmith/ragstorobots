using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item{

	public string name;
	public int id;
	public Image itemImage;
	public float value;

	public static Item Empty()
	{
		Item item = new Item();
		item.name = "Empty";
		item.id = 0;
		item.itemImage = null;
		item.value = 0.0f;

		return item;
	}
}
