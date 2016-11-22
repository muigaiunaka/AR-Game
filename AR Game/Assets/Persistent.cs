using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour {
	int scene = 0;
	int personalityTestResult = -1;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public int getPersonalityTestResult() {
		return personalityTestResult;
	}

	public void setPersonalityTestResult(int result) {
		personalityTestResult = result;
	}

	public void nextScene() {
		scene++;
	}

	public void previousScene() {
		scene--;
	}

	public void loadScene() {
		SceneManager.LoadScene (scene);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
