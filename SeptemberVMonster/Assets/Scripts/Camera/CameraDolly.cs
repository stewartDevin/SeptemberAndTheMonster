using UnityEngine;
using System.Collections;

public class CameraDolly : MonoBehaviour {

	public GameObject followTarget = null;
	public float leftToRight = 0.0f;

	public float pullBackAmount = 0.0f;


	// Use this for initialization
	void Start () {
		
	}

	void UpdateXPos() {
		Vector3 tempVec = transform.position;
		tempVec.x += (0.2f * ((followTarget.transform.position.x + leftToRight) - tempVec.x))  * Time.deltaTime;
		transform.position = tempVec;
	}
	void UpdateYPos() {
		Vector3 tempVec = transform.position;
		tempVec.y = tempVec.y + ((0.2f*30f) * (followTarget.transform.position.y - tempVec.y) * Time.deltaTime);
		transform.position = tempVec;
	}
	void UpdateZPos() {
		Vector3 tempVec = transform.position;
		tempVec.z = tempVec.z + ((0.2f*30f) * (followTarget.transform.position.z - tempVec.z) * Time.deltaTime);
		//tempVec.z = followTarget.transform.position.z - pullBackAmount;
		transform.position = tempVec;
	}

	void UpdatePosition() {
		UpdateXPos ();
		//UpdateYPos ();
		//UpdateZPos ();
	}

	void ConstrainCameraYPosition() {
//		float offset = 4.0f;
//		if(transform.position.y >= Datacore.World.yTopBound - offset) {
//			Vector3 tempVec = transform.position;
//			tempVec.y = Datacore.World.yTopBound - offset;
//			transform.position = tempVec;
//		}
	}

	// Update is called once per frame
	void Update () {
		//if(Datacore.GAME_STATE == Datacore.STATE.GameScreen) {
		if(followTarget == null) {
			followTarget = GameObject.FindGameObjectWithTag("cameraFollowTarget");
		}
		if(followTarget == null) {
			Debug.Log("The follow target could not be found for the cameraDolly.");
			return;
		}
		UpdatePosition ();
		ConstrainCameraYPosition ();
		//}
	}
}
