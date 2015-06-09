using UnityEngine;
using System.Collections;

// enumerate mouse buttons for later use
enum MouseButtonDown
{
	MBD_LEFT = 0,
	MBD_RIGHT,
	MBD_MIDDLE,
};

public class MouseAimCamera : MonoBehaviour {

	[SerializeField]
	private GameObject target; // game target to track

	private float camSpeed = 10f; // allowed rotation speed
	private float zoomSpeed = 4f; // allowed zoom speed
	private float distance = 4f; // initial camera distance
	private float minDistance = 2f; // minimum camera distance
	private float maxDistance = 6f; // maximum camera distance
	private float yMinLimit = -15f; // maximum angle camera may extend down
	private float yMaxLimit = 75f; // maximum angle camera may extend up
	private float x = 0f; // initial horizontal camera angle
	private float y = 0f;// initial vertical camera angle

	// unused atm
	private Vector3 offset; // offset vector for staying behind char

	// Use this for initialization
	void Start () {

		offset = target.transform.position - transform.position; // set offset vector

		// angle assignment
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		// initialize camera position
		cameraControl(0f, true);
	}
	
	// Update is called once per frame
	void Update () {

		// mouse wheel input
		float delta = Input.GetAxis("Mouse ScrollWheel");

		// camera rotation and simultaneous zoom if applicable
		if (target != null && Input.GetMouseButton ((int)MouseButtonDown.MBD_RIGHT)) 
		{ cameraControl(delta, false); }

		// just zoom
		if ( target != null && delta != 0.0f) 
		{ cameraControl(delta, true); }
			
	}
	
	void cameraControl(float delta, bool zoomOnly)
	{

		// TODO: enforce character turn at certain angle

		distance -= delta*zoomSpeed;


		// check for distance relative to allowed distances
		if (distance <= minDistance) 
		{
			distance = minDistance; // min zoom distance
		}
		if (distance >= maxDistance) 
		{
			distance = maxDistance; // max zoom distance
		}
		
		if (target) 
		{
			x += Input.GetAxis("Mouse X") * camSpeed;
			y -= Input.GetAxis("Mouse Y") * camSpeed;

			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;
			
			transform.rotation = rotation;
			transform.position = position;
		}
	}

	// keeps the angle valid
	static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}


	// testing area

	/*
	void obstacleRefocus()
	{
		Vector3 relativePos = transform.position - (target.transform.position);
		RaycastHit hit;
		if (Physics.Raycast (target.transform.position, relativePos, hit, distance+0.5)) {
			Debug.DrawLine(target.transform.position,hit.point);
			offset = distance - hit.distance + 0.8; 
			offset = Mathf.Clamp(offset,0,distance);
		}
		else
		{
			offset = 0;
		}
	}*/

}