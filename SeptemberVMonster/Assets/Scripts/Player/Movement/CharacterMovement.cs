using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float forwardSpeed = 1.0f;
	public float backwardSpeed = 1.0f;
	public float strafeSpeed = 1.0f;
	public float turnSpeed = 1.0f;
	public float jumpHeight = 1.0f;
	[SerializeField] float m_GroundCheckDistance = 0.1f;

	Rigidbody m_Rigidbody;
	Animator m_Animator;
	bool m_IsGrounded;
	float m_OrigGroundCheckDistance;
	float m_TurnAmount;
	float m_ForwardAmount;

	private Rigidbody rb = null;

	// Use this for initialization
	void Start () {


		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
		//m_Capsule = GetComponent<CapsuleCollider>();
		//m_CapsuleHeight = m_Capsule.height;
		//m_CapsuleCenter = m_Capsule.center;
		
		//m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		//m_OrigGroundCheckDistance = m_GroundCheckDistance;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.m_Rigidbody == null) return;

		bool Up = Input.GetKey(KeyCode.W);
		bool Down = Input.GetKey(KeyCode.S);
		bool Right = Input.GetKey(KeyCode.D);
		bool Left = Input.GetKey (KeyCode.A);
		bool StrafeLeft = Input.GetKey (KeyCode.Q);
		bool StrafeRight = Input.GetKey (KeyCode.E);
		bool Jump = Input.GetKey (KeyCode.Space);

		if(Up) {
			m_Rigidbody.transform.Translate (0, 0, forwardSpeed * Time.deltaTime, Space.Self);
		}
		if (Down) {
			m_Rigidbody.transform.Translate (0,0, -backwardSpeed * Time.deltaTime, Space.Self);
		}
		if(StrafeLeft){
			m_Rigidbody.transform.Translate(-strafeSpeed * Time.deltaTime, 0, 0, Space.Self);
		}
		if(StrafeRight){
			m_Rigidbody.transform.Translate (strafeSpeed * Time.deltaTime, 0, 0, Space.Self);
		}
		if (Right) {
			m_Rigidbody.transform.Rotate (0, (turnSpeed*20.0f) * Time.deltaTime, 0, Space.World);
		}
		if (Left) {
			m_Rigidbody.transform.Rotate (0, (-turnSpeed*20.0f) * Time.deltaTime, 0, Space.World);
		}
		if(Jump) {
			m_Rigidbody.AddExplosionForce(jumpHeight, this.transform.position - new Vector3(0.0f, 1.0f, 0.0f), 5.0f);
		}

	}
}
