using UnityEngine;
using System.Collections;

public class BuildTrigger : MonoBehaviour {
 
	public ArrayList colliders = new ArrayList();
	
	void OnTriggerEnter(Collider collide)
	{
		if (collide.gameObject != null)
		{
			colliders.Add(collide);
		}
	}
	
	void OnTriggerExit(Collider collide)
	{
		if (collide.gameObject != null)
		{
			colliders.Remove(collide);
		}
	}
}