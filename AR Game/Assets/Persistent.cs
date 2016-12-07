using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Persistent : MonoBehaviour {
//	public Constants constants;
	private Dictionary<int, string> companionMap = new Dictionary<int, string> ();
	private Dictionary<string, int> sceneMap = new Dictionary<string, int> ();
	private int scene = 0;
	private int personalityTestResult = -1;
	private Canvas canvas;
	private Camera camera;

	// Use this for initialization
	void Start () {
//		constants = gameObject.GetComponent<Constants> ();
		canvas = this.getSceneCanvas ().GetComponent<Canvas> ();
		this.createCompanionMap ();
		this.createSceneMap ();
	}

	void Awake() {
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad (camera);
	}

	public void createCompanionMap() {
		string[] companions = Constants.COMPANIONS;
		for (int i = 0; i < companions.Length; i++) {
			companionMap.Add (i,  companions[i]);
		}
	}

	public void createSceneMap() {
		string[] scenes = Constants.SCENES;
		for (int i = 0; i < scenes.Length; i++) {
			sceneMap.Add (scenes [i], i);
		}
	}

	public string getCompanionName(int id) {
		string temp = "";
		bool success = companionMap.TryGetValue (id, out temp);
		return (success) ? temp : "";
	}

	public GameObject getKudanCamera() {
		return GameObject.Find("Kudan Camera");
	}

	public void setupCamera(Canvas canvas) {
		camera = this.getKudanCamera ().GetComponent<Camera> ();
		int sceneId = -1;
		bool success = sceneMap.TryGetValue (Constants.TEST_RESULTS, out sceneId);
		canvas.renderMode = (sceneId == scene) ? RenderMode.ScreenSpaceCamera : RenderMode.ScreenSpaceOverlay;
		camera.fieldOfView = (sceneId == scene) ? 40 : 60;
		canvas.worldCamera = camera;
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
