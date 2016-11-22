using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour {
	private Dictionary<int, string> companions = new Dictionary<int, string> ();
	private int scene = 0;
	private int personalityTestResult = -1;

	// Use this for initialization
	void Start () {
		companions.Add (0, "Bulbasaur");
		companions.Add (1, "Charmander");
		companions.Add (2, "Squirtle");
		companions.Add (3, "Pikachu");
		companions.Add (4, "Eevee");
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public string getCompanionName(int id) {
		string temp = "";
		bool success = companions.TryGetValue (id, out temp);
		return (success) ? temp : "";
	}

	public GameObject getSceneCanvas() {
		return GameObject.Find ("Canvas-" + scene.ToString ());
	}

	public int getPersonalityTestResult() {
		return personalityTestResult;
	}

	public void setPersonalityTestResult(int result) {
		personalityTestResult = result;
	}

	public void setScene(int newScene) {
		scene = newScene;
	}

	public void loadNextScene() {
		scene++;
		SceneManager.LoadScene (scene);
	}

	public void loadPreviousScene() {
		scene--;
		SceneManager.LoadScene (scene);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
