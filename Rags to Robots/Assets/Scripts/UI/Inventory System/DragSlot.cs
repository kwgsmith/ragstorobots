using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragSlot : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	//canvas variable to make sure that the slot can't go offscreen
	private RectTransform canvasRectTransform;
	//panel variable for getting what panel the slot is "dropped on"
	private RectTransform panelRectTransform;
	//Transform of the actual item slot
	private RectTransform slotRectTransform;
	//transform of the floating item slot
	private RectTransform floatTransform;
	private GameObject floatingSlot;
	public GameObject slotPrefab;

	void Awake()
	{
		Canvas canvas = GameObject.Find ("GUI Manager").GetComponent<Canvas> ();
		if (canvas != null ) 
		{
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
			slotRectTransform = transform as RectTransform;
		}
	}

	//on click creates a floating slot at the mouse point
	public void OnPointerDown(PointerEventData data)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle (slotRectTransform, data.position, data.pressEventCamera, out pointerOffset); 

		floatingSlot = Instantiate (slotPrefab) as GameObject;
		if (floatingSlot != null) 
		{
			floatTransform = floatingSlot.transform as RectTransform;
			floatTransform.SetParent(canvasRectTransform, false);
			floatTransform.sizeDelta = slotRectTransform.sizeDelta;

			SetToMousePos (data);

		}
	}

	public void OnDragEnd(PointerEventData data)
	{
		Destroy(floatingSlot);
	}
	
	public void OnDrag(PointerEventData data)
	{
		//if there is no slot, just ignore
		if (slotRectTransform == null || floatingSlot == null || floatTransform == null)
			return;
		
		SetToMousePos (data);
		
	}

	private void SetToMousePos(PointerEventData data)
	{
		Vector2 pointerPosition = ClampToWindow (data);
		
		Vector2 localPointerPosition;
		//get a value of the pointer on the local canvas
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (canvasRectTransform, pointerPosition, data.pressEventCamera, out localPointerPosition)) 
		{
			floatTransform.localPosition = localPointerPosition - pointerOffset;
		}
	}

	private Vector2 ClampToWindow(PointerEventData data)
	{
		Vector2 rawPointerPosition = data.position;
		Vector3[] canvasCorners = new Vector3[4];
		canvasRectTransform.GetWorldCorners (canvasCorners);
		
		float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners [0].x, canvasCorners [2].x);
		float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners [0].y, canvasCorners [2].y);
		
		return new Vector2(clampedX, clampedY);
	}
}
