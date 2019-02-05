using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WarpNextLevel : MonoBehaviour {

	public Text winText;
	public int nextSceneIndex;

	private void Start() {
		winText.gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			if (nextSceneIndex >= 1) {
				SceneManager.LoadScene(nextSceneIndex);
			} else {
				gameComplete();
				other.gameObject.SetActive(false);
			}
		}
	}

	private void gameComplete() {

		int score = PlayerPrefs.GetInt("score");
		int highscore = PlayerPrefs.GetInt("highscore");
		if (score > highscore) {
			PlayerPrefs.SetInt("highscore", score);
		}
		winText.text = "YOU WIN!\nScore:\n" + score + "\nHigh Score:\n" + highscore;
		winText.gameObject.SetActive(true);
		PlayerPrefs.DeleteKey("score");
	}
}