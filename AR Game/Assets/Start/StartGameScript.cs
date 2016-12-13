using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	public Canvas canvas;  // UI Canvas
	public Button startBtn;    // Start button object
	public Text btnText;       // Start button text object

	// Use this for initialization
	void Start () {
		// Get persistent data.
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

		canvas = persistentScript.getSceneCanvas ();
		canvas.transform.position = Vector3.zero;

		// Set start button text and add StartGame function on click
		btnText.text = "Start Game";
		Button btn = startBtn.GetComponent<Button>();
		btn.onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Adds dialogue textbox to scene and destroys start btn
	void StartGame() {

		// Create textbox game object if doesn't already exist
		if (GameObject.Find("Narrative Text") == null) {

			// Style and position textbox
			GameObject textBoxGO = new GameObject("Dialogue Textbox");
			textBoxGO.AddComponent<Image>().color = Color.white;

			RectTransform rt = textBoxGO.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(800, 100);
			rt.anchorMin = new Vector2 (.5f, 0);
			rt.anchorMax = new Vector2 (.5f, 0);
			rt.pivot = new Vector2 (.5f, 0);
			textBoxGO.transform.SetParent(canvas.transform, false);

			// Add text to textbox
			GameObject textGO = new GameObject("Narrative Text");
			textGO.transform.localPosition = Vector3.zero;
		 	
			// Style and position text in textbox
		    Text narrText = textGO.AddComponent<Text>();
		    narrText.text = "Hello";
			narrText.color = Color.black;
			narrText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

			RectTransform rtText = textGO.GetComponent<RectTransform> ();
			rtText.sizeDelta = new Vector2(300, 100);
			rtText.anchorMin = new Vector2 (.2f, .2f);
			rtText.anchorMax = new Vector2 (.9f, .9f);
			rtText.pivot = new Vector2 (.5f, .5f);
			textGO.transform.localPosition = Vector3.zero;

			textGO.transform.SetParent(textBoxGO.transform);
			textGO.transform.position = Vector3.zero;
			textGO.transform.localPosition = Vector3.zero;
			textGO.transform.localScale = Vector3.one;

			// Adds "next" button to textbox
			GameObject contBtn = new GameObject("Continue Btn");

			contBtn.transform.SetParent(textBoxGO.transform, false);
			contBtn.transform.localPosition = Vector3.zero;
			contBtn.AddComponent<BeginStory>();

			Destroy(GameObject.Find("Button"));
			Destroy(GameObject.Find("splashscreen"));
		}
	}
}
