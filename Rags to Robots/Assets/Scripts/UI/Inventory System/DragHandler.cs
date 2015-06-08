using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public Canvas guiManager;
	public static Transform startParent;

	void Start ()
	{
		guiManager = GameObject.Find ("GUI Manager").GetComponent<Canvas> ();
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startParent = transform.parent;
		transform.SetParent (guiManager.transform, false);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{

		transform.position = Input.mousePosition;

	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
		if (transform.parent == guiManager.transform) 
		{
			transform.SetParent(startParent);
		}
		GetComponent<CanvasGroup>().blocksRaycasts = true;

	}

	#endregion



}
