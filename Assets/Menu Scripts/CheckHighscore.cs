using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHighscore : MonoBehaviour {
	public Text highscoreText;

	private void Start() {
		int highscore = PlayerPrefs.GetInt("highscore");
		highscoreText.text = "High Score:\n " + highscore;
	}

	public void resetHighscore() {
		PlayerPrefs.DeleteKey("highscore");
		highscoreText.text = "High Score:\n " + 0;
	}
}