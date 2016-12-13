using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Next : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	private Canvas canvas;
	private GameObject gameImage;
	private RawImage gameImageComponent;

	private TestResults testResults;
	private ArrayList textContents;
	private IEnumerator textIter;
	private Text currentText;
	private Button nextButton;

	// Use this for initialization
	void Start () {
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

		gameImage = GameObject.Find ("ComputerModel");
		gameImageComponent = gameImage.GetComponent<RawImage> ();

		canvas = persistentScript.getSceneCanvas ();
		testResults = canvas.GetComponent<TestResults> ();
		textContents = testResults.getTextAfterPersonalityTest ();

		currentText = GameObject.Find ("CurrentText").GetComponent<Text>();
		nextButton = gameObject.GetComponent<Button>();
		nextButton.onClick.AddListener (showNextAfterTestText);
	}

	void showNextAfterTestText() {
		currentText.text = (string) textIter.Current;
		bool hasNext = textIter.MoveNext ();
		if (!hasNext) {
			nextButton.onClick.AddListener (showNextTestResultsText);
			nextButton.onClick.RemoveListener (showNextAfterTestText);
		}
	}

	void showNextTestResultsText() {
		int companionId = persistentScript.getPersonalityTestResult ();
		string companionName = persistentScript.getCompanionName (companionId).ToLower ();

		if (companionName.Equals("bulbasaur")) {
			Destroy (gameImage);
			GameObject companion = Instantiate (testResults.bulbasaur) as GameObject;
			companion.transform.SetParent (canvas.transform, false);
			Animator animator = companion.GetComponent<Animator> ();
			animator.Play ("Float");
		}
		else {
			gameImageComponent.texture = Resources.Load (companionName) as Texture;
		}

		currentText.text = "Your Companion is: " + companionName;
		nextButton.onClick.AddListener(persistentScript.loadNextScene);
		nextButton.onClick.RemoveListener (showNextTestResultsText);
	}
	
	// Update is called once per frame
	void Update () {
		if (textContents.Count == 0) {
			textContents = testResults.getTextAfterPersonalityTest ();
			textIter = testResults.getIter (textContents);
			showNextAfterTestText ();
		}
	}
}
