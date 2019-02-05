using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBounce : MonoBehaviour {

	public float jumpHeight = 1;

	private Rigidbody rb;
	private bool isGrounded;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if (isGrounded) {
			float random = Random.Range(2, 10);
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -random * Physics.gravity.y), ForceMode.VelocityChange);
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Ground")) {
			isGrounded = true;
		}
	}
}