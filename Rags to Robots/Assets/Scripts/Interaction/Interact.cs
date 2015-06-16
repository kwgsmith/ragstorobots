using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {


	private int interactMask;// A layer mask so that a ray can be cast just at gameobjects with an interactable layer
	private float camRayLength = 100f;// The length of the ray from the camera into the scene.

	// Use this for initialization
	void Awake () 
	{
	    // Create a interactable layer mask
		interactMask = LayerMask.GetMask ("Interactable");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit objectHit;
		
		// Perform the raycast and if it hits something on the interactable...
		if(Physics.Raycast (camRay, out objectHit, camRayLength , interactMask))
		{
			// if left click
			if(Input.GetMouseButtonDown(0))
			{
				// attempt the interaction
				try
				{
					// grab script that implements InteractableObject
					InteractableObject usableObj = objectHit.transform.GetComponent<InteractableObject>();
					// execute implemented InteractableObject interact method
					usableObj.Interact();
				}// end try
				catch(System.Exception ex)
				{
					Debug.Log("Error with interaction or invalid interaction attempted!");
					Debug.Log(ex.Message);
					Debug.Log(ex.InnerException.Message);
					Debug.Log(ex.StackTrace);
				}// end catch
			}// end input if statement
		}// end raycast if statement
	}// update function


}
