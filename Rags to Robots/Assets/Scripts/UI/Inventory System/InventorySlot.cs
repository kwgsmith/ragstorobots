using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InventorySlot : MonoBehaviour, IDropHandler {

	public GameObject Item 
	{ 
		get 
		{ 
			if(transform.childCount > 0)
				return transform.GetChild(0).gameObject;   

			return null;
		} 
	} 

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		//if no item, drop into slot
		if (Item == null) 
		{
			DragHandler.itemBeingDragged.transform.SetParent(transform);
		}
		//if item is there switch
		else if (Item != null) 
		{
			Item.transform.SetParent(DragHandler.startParent);
			DragHandler.itemBeingDragged.transform.SetParent(transform);
		}
	}

	#endregion
}
