using UnityEngine;
using System.Collections;

public class ScrapInteraction : MonoBehaviour , InteractableObject 
{

	private GameManager manager;

	// Use this for initialization
	void Start () 
	{
		manager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {}

	// required method on InteractableObject interface
	public void Interact ()
	{
		// TODO: add scrap to player inventory (!partial!)
		manager.addItemToPlayer (0);
		Destroy (this.gameObject);

		Debug.Log("1 Scrap added to inventory");
	}

}
