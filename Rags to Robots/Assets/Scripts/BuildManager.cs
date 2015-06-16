using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {


	public GameObject itemBuildPrefab;

	private GameObject _buildItem;
	public bool buildMode = false;
	public GameObject guiManager;
	
	public float distance = 1.0f;
	public bool useInitialCameraDistance = false;
	private float _actualDistance;
	
	public BuildTrigger buildTrigger;
	
	// Update is called once per frame
	void Update () {	
		if(buildMode.Equals(true))
		{
		
		
			//mouse direction of the moving object
			Vector3 mousePosition = Input.mousePosition;
			mousePosition = new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y);
			Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
			_buildItem.transform.position = new Vector3(point.x, 1f, point.z);
			
			if(IsLegalPosition().Equals(false))
			{
				_buildItem.GetComponent<Renderer>().material.color = Color.red;
			}
			else
			{
				_buildItem.GetComponent<Renderer>().material.color = Color.green;
			}	
			
			if(Input.GetKey(KeyCode.Escape)) // turns off build mode
			{
				Destroy(_buildItem);
				buildMode = false;
				buildTrigger = null;
				guiManager.gameObject.SetActive(true);
				
			}
			
			if(Input.GetButton("Fire1")) //places object if placable and is on build mode
			{
				if(IsLegalPosition().Equals(true)) 
				{
					_buildItem.GetComponent<MeshCollider>().isTrigger = false;
					buildMode = false;
					_buildItem.GetComponent<Renderer>().material.color = Color.white;
					buildTrigger = null;
					guiManager.gameObject.SetActive(true);
				}
			}
			
			if(Input.GetButtonUp("Fire2"))//rotates object in build mode 
			{
				_buildItem.transform.Rotate(new Vector3(0, 90, 0));
			}
		}	
	}

	public void Build() //Turns on Build Mode and Spawns Build Item on Mouse
	{
		 buildMode = true;
		 guiManager.gameObject.SetActive(false);
		 
		_buildItem = Instantiate(itemBuildPrefab) as GameObject;
		_buildItem.GetComponent<MeshCollider>().isTrigger = true;
		buildTrigger = _buildItem.GetComponent<BuildTrigger>();
	}
	
	bool IsLegalPosition() //checks to see if placement is good or not
	{
		if(buildTrigger.colliders.Count > 0) 
		{		
			return false;
		}
		return true;	
	}
}
