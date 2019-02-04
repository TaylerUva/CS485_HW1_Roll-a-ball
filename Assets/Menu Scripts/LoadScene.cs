using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) {
		SceneManager.LoadScene(sceneIndex);
	}
}