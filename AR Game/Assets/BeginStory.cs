using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeginStory : MonoBehaviour {
	private string[] dialogue;       // The textbox dialogue
	private int counter = 0;         // Used for getting the line in the dialoge array
	private GameObject narrTextBox;  // the dialogue textbox game object

	// Use this for initialization
	void Start () {

		// Style and position next button
		GameObject contBtn = GameObject.Find("Continue Btn");
		Button btn = contBtn.AddComponent<Button>();
		contBtn.AddComponent<Image>();
		RectTransform rt = contBtn.GetComponent<RectTransform>();
		btn.onClick.AddListener(Next);
		rt.sizeDelta = new Vector2(150, 50);
		rt.transform.position = new Vector2(560, 45);

		// Add text to next button
		GameObject cTextGO = new GameObject("Continue Text");
		cTextGO.transform.SetParent(contBtn.transform);

		// Style next button text
	    Text contText = cTextGO.AddComponent<Text>();
	    contText.text = "Next";
		contText.color = Color.black;
		contText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		contText.transform.position = new Vector2(600, 0);

		// Add dialogue to the string array
		dialogue = new string[] {
			"Once upon a time...",
			"there was a sloth that wanted some bread",
			"And it decided it wouldn't eat anything other than bread.",
			"So he was going to search for some.",
			"But then he remembered...",
			"That he was a sloth.",
			"A super lazy sloth.",
			"And looking for bread would be a lot of work.",
			"But this was a sloth of his word, and he had vowed not to eat anything other than bread.",
			"So he starved.",
			"And died.",
			"The End."
		};

		// Set textbox game object to a variable
		narrTextBox = GameObject.Find("Narrative Text");
		narrTextBox.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 100);
	
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
		}
	}
}
