using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) {
		PlayerPrefs.DeleteKey("score");
		SceneManager.LoadScene(sceneIndex);
	}
}