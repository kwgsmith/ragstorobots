
using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]

public class UnityChanControlScriptWithRgidBody : MonoBehaviour
{

	public float animSpeed = 1.5f;				
	public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
	public bool useCurves = true;				// Mecanim
												
	public float useCurvesHeight = 0.5f;		


	public float forwardSpeed = 7.0f;
	public float backwardSpeed = 2.0f;
	public float rotateSpeed = 2.0f;
	public float jumpPower = 3.0f; 
	private CapsuleCollider col;
	private Rigidbody rb;
	private Vector3 velocity;
	// CapsuleCollider
	private float orgColHight;
	private Vector3 orgVectColCenter;
	
	private Animator anim;							
	private AnimatorStateInfo currentBaseState;	// base layer

	private GameObject cameraObject;

	static int idleState = Animator.StringToHash("Base Layer.Idle");
	static int locoState = Animator.StringToHash("Base Layer.Locomotion");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int restState = Animator.StringToHash("Base Layer.Rest");

	void Start ()
	{
		// Animator
		anim = GetComponent<Animator>();
		// CapsuleCollider
		col = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();

		cameraObject = GameObject.FindWithTag("MainCamera");
		// CapsuleCollider
		orgColHight = col.height;
		orgVectColCenter = col.center;
}
	

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal");			
		float v = Input.GetAxis("Vertical");				
		anim.SetFloat("Speed", v);							
		anim.SetFloat("Direction", h); 						
		anim.speed = animSpeed;								
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	
		rb.useGravity = true;
		
		

		velocity = new Vector3(0, 0, v);		

		velocity = transform.TransformDirection(velocity);

		if (v > 0.1) {
			velocity *= forwardSpeed;		
		} else if (v < -0.1) {
			velocity *= backwardSpeed;	
		}
		/*
		if (Input.GetButtonDown("Jump")) {	

			if (currentBaseState.nameHash == locoState){

				if(!anim.IsInTransition(0))
				{
						rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
						anim.SetBool("Jump", true);	
				}
			}
		}*/
		
		
		transform.localPosition += velocity * Time.fixedDeltaTime;
		
		transform.Rotate(0, h * rotateSpeed, 0);	
	


		if (currentBaseState.nameHash == locoState){
			if(useCurves){
				resetCollider();
			}
		}/*
		// JUMP
		else if(currentBaseState.nameHash == jumpState)
		{
			cameraObject.SendMessage("setCameraPositionJumpView");	
			if(!anim.IsInTransition(0))
			{
				if(useCurves){
					float jumpHeight = anim.GetFloat("JumpHeight");
					float gravityControl = anim.GetFloat("GravityControl"); 
					if(gravityControl > 0)
						rb.useGravity = false;	
										
					Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
					RaycastHit hitInfo = new RaycastHit();

					if (Physics.Raycast(ray, out hitInfo))
					{
						if (hitInfo.distance > useCurvesHeight)
						{
							col.height = orgColHight - jumpHeight;			
							float adjCenterY = orgVectColCenter.y + jumpHeight;
							col.center = new Vector3(0, adjCenterY, 0);	
						}
						else{
							resetCollider();
						}
					}
				}
				// Jump bool				
				anim.SetBool("Jump", false);
			}
		}*/
		/*
		// IDLE
		else if (currentBaseState.nameHash == idleState)
		{
			if(useCurves){
				resetCollider();
			}
			if (Input.GetButtonDown("Jump")) {
				anim.SetBool("Rest", true);
			}
		}*/
		// REST
		else if (currentBaseState.nameHash == restState)
		{
			//cameraObject.SendMessage("setCameraPositionFrontView");
			if(!anim.IsInTransition(0))
			{
				anim.SetBool("Rest", false);
			}
		}
	}

	void resetCollider()
	{
		col.height = orgColHight;
		col.center = orgVectColCenter;
	}
}
