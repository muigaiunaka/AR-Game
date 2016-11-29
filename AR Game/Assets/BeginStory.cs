using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BeginStory : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	private string[] dialogue;       // The textbox dialogue
	private int counter = 0;         // Used for getting the line in the dialoge array
	private GameObject narrTextBox;  // the dialogue textbox game object

	// Use this for initialization
	void Start () {
		// Get persistent data.
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

		// Style and position next button
		GameObject contBtn = GameObject.Find("Continue Btn");
		Button btn = contBtn.AddComponent<Button>();
		contBtn.AddComponent<Image>();
//		RectTransform rt = contBtn.GetComponent<RectTransform>();
		btn.onClick.AddListener(Next);
//		rt.sizeDelta = new Vector2(150, 50);
		//		rt.transform.position = new Vector3(759, 45, 0); //560, 45 759

		// Add text to next button
		GameObject cTextGO = new GameObject("Continue Text");
		cTextGO.transform.SetParent(contBtn.transform, false);

		// Style next button text
	    Text contText = cTextGO.AddComponent<Text>();
	    contText.text = "Next";
		contText.color = Color.black;
		contText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

		//		contText.transform.position = Vector3.zero;
		contBtn.transform.localPosition = Vector3.zero;
		RectTransform btnRect = contBtn.GetComponent<RectTransform> ();
		btnRect.sizeDelta = new Vector2(150, 50);
		btnRect.anchorMin = new Vector2 (1, .2f);
		btnRect.anchorMax = new Vector2 (1, .2f);
		btnRect.pivot = new Vector2 (1, 0);
		contText.transform.localPosition = Vector3.zero;

//		contText.transform.position = new Vector2(794, 0); //600, 0

		// Add dialogue to the string array
		dialogue = new string[] {
			"Once upon a time..."//,
//			"there was a sloth that wanted some bread",
//			"And it decided it wouldn't eat anything other than bread.",
//			"So he was going to search for some.",
//			"But then he remembered...",
//			"That he was a sloth.",
//			"A super lazy sloth.",
//			"And looking for bread would be a lot of work.",
//			"But this was a sloth of his word, and he had vowed not to eat anything other than bread.",
//			"So he starved.",
//			"And died.",
//			"The End."
		};

		// Set textbox game object to a variable
		narrTextBox = GameObject.Find("Narrative Text");
//		narrTextBox.transform.position = Vector3.zero;
//
//		RectTransform rtText = narrTextBox.GetComponent<RectTransform> ();
//		rtText.sizeDelta = new Vector2(300, 100);
//		rtText.anchorMin = new Vector2 (.1f, 0);
//		rtText.anchorMax = new Vector2 (.1f, 0);
//		rtText.pivot = new Vector2 (.5f, 0);
//		narrTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 100);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Gets the next string in the dialogue array
	void Next() {
		Text narrText = narrTextBox.GetComponent<Text>();
		if (counter < dialogue.Length) {
			narrText.text = dialogue[counter];
			counter++;
		} else {
			persistentScript.loadNextScene ();
		}
	}
}
