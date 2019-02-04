﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	public float jumpHeight = 1;
	public float lowerPlayerBounds = -2;

	public Text countText;
	public Text loseText;

	private Rigidbody rb;
	private int score;
	private bool isGrounded;

	void Start() {
		rb = GetComponent<Rigidbody>();
		score = PlayerPrefs.GetInt("score");
		SetCountText();

		loseText.gameObject.SetActive(false);
	}

	private void LateUpdate() {
		checkOutOfBounds();
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		if (Input.GetButtonDown("Jump") && isGrounded) {
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
			isGrounded = false;
		}

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			score = score + 1;
			PlayerPrefs.SetInt("score", score);
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = "Score: " + score.ToString();
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Ground")) {
			isGrounded = true;
		}
	}

	void checkOutOfBounds() {
		if (gameObject.transform.position.y < lowerPlayerBounds) {
			loseText.text = "GAME OVER!\nScore: " + PlayerPrefs.GetInt("score");
			loseText.gameObject.SetActive(true);
		}
	}

}