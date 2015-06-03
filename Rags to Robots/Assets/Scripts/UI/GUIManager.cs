using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	
	public GameObject InventoryWindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) 
		{
			TogglePanel(InventoryWindow);
		}
	}

	public void TogglePanel (GameObject panel) {
		panel.SetActive (!panel.activeSelf);
	}

	public void ToggleTooltip (GameObject tooltip) {
		tooltip.SetActive (!tooltip.activeSelf);
	}

}
