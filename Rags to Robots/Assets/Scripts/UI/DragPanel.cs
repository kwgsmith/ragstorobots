using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;

	void Awake()
	{
		Canvas canvas = GetComponentInParent<Canvas> ();
		if (canvas != null) 
		{
			canvasRectTransform = canvas.transform as RectTransform;
			panelRectTransform = transform.parent as RectTransform;
		}
	}

	//on click moves the window up to the top of the view and
	//sets the offset to the point that was clicked so that
	//it can be dragged
	public void OnPointerDown(PointerEventData data)
	{
		panelRectTransform.SetAsLastSibling ();
		RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset); 
	}

	public void OnDrag(PointerEventData data)
	{
		//if there is no panel, just ignore
		if (panelRectTransform == null)
			return;

		Vector2 pointerPosition = ClampToWindow (data);

		Vector2 localPointerPosition;
		//get a value of the pointer on the local canvas
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (canvasRectTransform, pointerPosition, data.pressEventCamera, out localPointerPosition)) 
		{
			panelRectTransform.localPosition = localPointerPosition - pointerOffset;
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
