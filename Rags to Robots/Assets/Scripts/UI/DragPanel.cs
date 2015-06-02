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
			panelRectTransform = transform as RectTransform;
		}
	}

}
