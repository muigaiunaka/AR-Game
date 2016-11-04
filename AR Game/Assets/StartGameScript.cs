using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {
	public GameObject canvas;
	public Button startBtn;
	public Text btnText;

	// Use this for initialization
	void Start () {
		btnText.text = "Start Game";
		Button btn = startBtn.GetComponent<Button>();
		btn.onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartGame() {
		btnText.text = "Game Started";
		if (GameObject.Find("Narrative Text") == null) {
			GameObject textGO = new GameObject("Narrative Text");
		    textGO.transform.SetParent(canvas.transform);
		 
		    Text narrText = textGO.AddComponent<Text>();
		    narrText.text = "What is life?";
			narrText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

			// position starts at -339 and -150...using this for now to counter
			narrText.transform.position = new Vector2(339, 50);

			GameObject contBtn = new GameObject("Continue Btn");
			contBtn.transform.SetParent(canvas.transform);
			contBtn.AddComponent<BeginStory>();

			Destroy(GameObject.Find("Button"));
		}
		else {
			print("Text already exists!");
		}
	}
}
