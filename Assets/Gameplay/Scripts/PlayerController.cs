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

		rb.AddForce(movement * speed);
	}

	private void Update() {
		if (Input.GetButtonDown("Jump") && isGrounded) {
			rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
			isGrounded = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			score = score + 1;
			PlayerPrefs.SetInt("score", score);
			SetCountText();
		} else if (other.gameObject.CompareTag("Fake Pick Up")) {
			other.gameObject.SetActive(false);
			gameOver();
			this.gameObject.SetActive(false);
		} else if (other.gameObject.CompareTag("Death Wall")) {
			gameOver();
			this.gameObject.SetActive(false);
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
			gameOver();
		}
	}

	void gameOver() {
		int highscore = PlayerPrefs.GetInt("highscore");
		if (score > highscore) {
			PlayerPrefs.SetInt("highscore", score);
		}
		loseText.text = "GAME OVER!\nScore:\n" + score + "\nHigh Score:\n" + highscore;
		loseText.gameObject.SetActive(true);
		PlayerPrefs.DeleteKey("score");
	}

}