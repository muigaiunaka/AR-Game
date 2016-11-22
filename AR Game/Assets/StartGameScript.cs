using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	public GameObject canvas;  // UI Canvas
	public Button startBtn;    // Start button object
	public Text btnText;       // Start button text object

	// Use this for initialization
	void Start () {
		// Get persistent data.
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

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
			rt.transform.position = new Vector3(434, 70, 0); //340 70 434, 70

			// Add text to textbox
			GameObject textGO = new GameObject("Narrative Text");
		    textBoxGO.transform.SetParent(canvas.transform);
		    textGO.transform.SetParent(textBoxGO.transform);
		 	
			// Style and position text in textbox
		    Text narrText = textGO.AddComponent<Text>();
		    narrText.text = "What is life?";
			narrText.color = Color.black;
			narrText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			narrText.transform.position = new Vector2(339, 50);

			// Adds "next" button to textbox
			GameObject contBtn = new GameObject("Continue Btn");
			contBtn.transform.SetParent(textBoxGO.transform);
			contBtn.AddComponent<BeginStory>();

			Destroy(GameObject.Find("Button"));
		}
	}
}
