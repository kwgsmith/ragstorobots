using UnityEngine;
using System.Collections;

public class ScrapInteraction : MonoBehaviour , InteractableObject 
{
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {}

	// required method on InteractableObject interface
	public void Interact ()
	{
		// TODO: add scrap to player inventory
		Debug.Log("1 Scrap added to inventory");

		Destroy (this.gameObject);
	}

}
