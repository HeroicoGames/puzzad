using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public GameObject paintBall;
	public Transform shotSpawn;
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float fireRate;

	private float nextFire;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	private Transform transformCharacterBody;

	void Movement() {
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;

			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void Fire() {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (paintBall, shotSpawn.position, shotSpawn.rotation);
		}
	}

	bool VerifiedHorizontalRotation() {
		if (Input.GetAxis ("Vertical") == 0) {
			return true;
		} else
			return false;
	}

	bool VerifiedVerticalRotation () {
		if (Input.GetAxis ("Horizontal") == 0) {
			return true;
		} else {
			return false;
		}
	}

	void Rotate () {
		if (VerifiedHorizontalRotation() && Input.GetAxis ("Horizontal") < 0 && transformCharacterBody.eulerAngles.y != 270f) {
			transformCharacterBody.rotation = Quaternion.Euler(0, 270, 0);
		} else if (VerifiedHorizontalRotation() && Input.GetAxis ("Horizontal") > 0 && transformCharacterBody.eulerAngles.y != 90f) {
			transformCharacterBody.rotation = Quaternion.Euler(0, 90, 0);
		} else if (VerifiedVerticalRotation() && Input.GetAxis ("Vertical") < 0 && transformCharacterBody.eulerAngles.y != 180f) {
			transformCharacterBody.rotation = Quaternion.Euler(0, 180, 0);
		} else if (VerifiedVerticalRotation() && Input.GetAxis ("Vertical") > 0 && transformCharacterBody.eulerAngles.y != 0f) {
			transformCharacterBody.rotation = Quaternion.identity;
		}
	}

	void Talk () {
		if (Input.GetButtonDown ("Interaction")) {
			print ("Talking with NPC");
		}
	}

	void Carry () {
		if (Input.GetButton ("Interaction")) {
			print ("Carryng character");
		}
	}

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		transformCharacterBody = GetComponentsInChildren<Transform> ()[1];
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Rotate ();
		Fire ();
		Talk ();
	}
}
