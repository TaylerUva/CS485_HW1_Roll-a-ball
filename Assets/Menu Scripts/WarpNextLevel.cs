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
			if (nextSceneIndex != 0) {
				SceneManager.LoadScene(nextSceneIndex);
			} else {
				winText.text = "You Win!\nScore: " + PlayerPrefs.GetInt("score");
				winText.gameObject.SetActive(true);
				other.gameObject.SetActive(false);
				PlayerPrefs.DeleteKey("score");
			}
		}
	}
}