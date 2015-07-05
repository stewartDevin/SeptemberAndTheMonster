using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {

	[Space(5)]
	public GameObject followTarget = null;
	public bool lookAtTarget = false;
	
	[Space(10)]
	public float pos_leftToRight = 0.0f;
	public float speed_leftToRight = 3.0f;
	[Space(5)]
	public float pos_topToBottom = 0.0f;
	public float speed_topToBottom = 3.0f;
	[Space(5)]
	public float pos_backToFront = 0.0f;
	public float speed_backToFront = 3.0f;

	private Camera cam = null;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();
	}

	void UpdateXPos() {
		Vector3 tempVec = transform.position;
		tempVec.x += (speed_leftToRight * ((followTarget.transform.position.x + pos_leftToRight) - tempVec.x))  * Time.deltaTime;
		transform.position = tempVec;
	}
	void UpdateYPos() {
		Vector3 tempVec = transform.position;
		tempVec.y += (speed_topToBottom * ((followTarget.transform.position.y + pos_topToBottom) - tempVec.y))  * Time.deltaTime;
		transform.position = tempVec;
	}
	void UpdateZPos() {
		Vector3 tempVec = transform.position;
		tempVec.z += (speed_backToFront * ((followTarget.transform.position.z + pos_backToFront) - tempVec.z))  * Time.deltaTime;
		//tempVec.z = followTarget.transform.position.z - pullBackAmount;
		transform.position = tempVec;
	}

	void UpdatePosition() {
		UpdateXPos ();
		UpdateYPos ();
		UpdateZPos ();
	}

//	void ConstrainCameraYPosition() {
//		float offset = 4.0f;
//		if(transform.position.y >= Datacore.World.yTopBound - offset) {
//			Vector3 tempVec = transform.position;
//			tempVec.y = Datacore.World.yTopBound - offset;
//			transform.position = tempVec;
//		}
//	}

	void RunLookAtTarget () {
		Vector3 tempPos = followTarget.transform.position;
		tempPos.y += 1.3f;
		if(lookAtTarget) cam.transform.LookAt (tempPos);
	}

	[Space(10)]
	public bool useMouseLook = false;
	public float horizontalSensitivity = 2.0f;
	public float verticalSensitivity = 2.0f;

	private bool usingMouseLook = false;
	void RunMouseLook() {
		if (Input.GetMouseButton (0)) {
			float h = horizontalSensitivity * Input.GetAxis ("Mouse X");
			float v = verticalSensitivity * Input.GetAxis ("Mouse Y");

			this.transform.position += this.transform.right * h;
			this.transform.position += this.transform.up * v;

			usingMouseLook = true;
		} else {
			usingMouseLook = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if(followTarget == null) {
			followTarget = GameObject.FindGameObjectWithTag("cameraFollowTarget");
		}
		if(followTarget == null) {
			Debug.Log("The follow target could not be found for the cameraDolly.");
			return;
		}
		if(cam == null) return;

		RunMouseLook ();
		if(!usingMouseLook) UpdatePosition ();
		
		RunLookAtTarget ();


		//transform.position += transform.right;

	}
}
