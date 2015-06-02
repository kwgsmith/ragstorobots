using UnityEngine;
using System.Collections;

namespace CameraController
{
	enum MouseButtonDown
	{
		MBD_LEFT = 0,
		MBD_RIGHT,
		MBD_MIDDLE,
	};

	public class CameraController : MonoBehaviour
	{
		[SerializeField]
		private Vector3 focus = Vector3.zero;
		[SerializeField]
		private GameObject focusObj = null;

		[SerializeField]
		private float zoomMax = 6f;
		[SerializeField]
		private float zoomMin = 2.5f;

		private Vector3 oldPos;

		void setupFocusObject(string name)
		{
			GameObject obj = this.focusObj = new GameObject(name);
			obj.transform.position = this.focus;
			obj.transform.LookAt(this.transform.position);

			return;
		}

		void Start ()
		{
			if (this.focusObj == null)
				this.setupFocusObject("CameraFocusObject");

			Transform trans = this.transform;
			transform.parent = this.focusObj.transform;

			trans.LookAt(this.focus);

			return;
		}
	
		void Update ()
		{
			this.mouseEvent();
			Transform trans = this.transform;
			transform.parent = this.focusObj.transform;

			return;
		}

		void mouseEvent()
		{
			float delta = Input.GetAxis("Mouse ScrollWheel");
			if (delta != 0.0f)
				this.mouseWheelEvent(delta);

			if (Input.GetMouseButtonDown((int)MouseButtonDown.MBD_LEFT) ||
				Input.GetMouseButtonDown((int)MouseButtonDown.MBD_MIDDLE) ||
				Input.GetMouseButtonDown((int)MouseButtonDown.MBD_RIGHT))
				this.oldPos = Input.mousePosition;

			this.mouseDragEvent(Input.mousePosition);

			return;
		}

		void mouseDragEvent(Vector3 mousePos)
		{
			Vector3 diff = mousePos - oldPos;

			if(Input.GetMouseButton((int)MouseButtonDown.MBD_LEFT))
			{
				//Zoom
				if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftCommand))
				{
					if (diff.magnitude > Vector3.kEpsilon)
						this.cameraTranslate(-diff / 100.0f);
				}
				//Rotation
				else if (Input.GetKey(KeyCode.LeftAlt))
				{
					if (diff.magnitude > Vector3.kEpsilon)
						this.cameraRotate(new Vector3(0.0f, diff.x, 0.0f));
				}
			}
			// Zoom
			else if (Input.GetMouseButton((int)MouseButtonDown.MBD_MIDDLE))
			{
				if (diff.magnitude > Vector3.kEpsilon)
					this.cameraTranslate(-diff / 100.0f);
			}
			//Rotation
			else if (Input.GetMouseButton((int)MouseButtonDown.MBD_RIGHT))
			{
				if (diff.magnitude > Vector3.kEpsilon)
					this.cameraRotate(new Vector3(0.0f, diff.x, 0.0f));
			}
				
			this.oldPos = mousePos;	

			return;
		}

		// Zoom
		public void mouseWheelEvent(float delta)
		{
			float distance = Vector3.Distance(this.transform.position, focusObj.transform.position);
			// prevent zooming too far out, allow zooming back in
			if(distance > zoomMax && delta > 0.0f)
			{
				return;
			}
			// prevent zooming too far in, allow zooming back out
			else if(distance < zoomMin && delta < 0.0f)
			{
				return;
			}

			Vector3 focusToPosition = this.transform.position - this.focus;

			Vector3 post = focusToPosition * (1.0f + delta);

			if (post.magnitude > 0.01)
				this.transform.position = this.focus + post;

			return;
		}

		// translated position of camera during zoom/rotation
		void cameraTranslate(Vector3 vec)
		{
			Transform focusTrans = this.focusObj.transform;

			vec.x *= -1;

			focusTrans.Translate(Vector3.right * vec.x);
			focusTrans.Translate(Vector3.up * vec.y);

			this.focus = focusTrans.position;

			return;
		}

		// turns camera, maintains rotation
		public void cameraRotate(Vector3 eulerAngle)
		{
			//Use Quaternion to prevent rotation flips on XY plane
			Quaternion q = Quaternion.identity;
 
			Transform focusTrans = this.focusObj.transform;
			focusTrans.localEulerAngles = focusTrans.localEulerAngles + eulerAngle;

			//Change this.transform.LookAt(this.focus) to q.SetLookRotation(this.focus)
			q.SetLookRotation (this.focus) ;

			return;
		}
	}
}
