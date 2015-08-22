using UnityEngine;
using System.Collections;

public class CameraTriggerSwitch : MonoBehaviour {
	public Camera _cam = null;

	// Use this for initialization
	void Start () {
		if(_cam != null) DataCore.listOfCameras.Add (_cam);
	}

	void OnTriggerEnter(Collider col) {
		if(col.tag == "cameraFollowTarget") {
			//Debug.Log("Ding! #");
			foreach(Camera _camera in DataCore.listOfCameras) {
				_camera.enabled = false;
			}
			_cam.enabled = true;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
