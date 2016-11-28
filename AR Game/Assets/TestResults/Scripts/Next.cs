using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Next : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	private GameObject canvas;
	private TestResults testResults;
	private ArrayList textContents;
	private IEnumerator textIter;
	private Text currentText;
	private Button nextButton;

	// Use this for initialization
	void Start () {
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();
		persistentScript.setScene (2);

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
		currentText.text = "Your Companion is: " + persistentScript.getCompanionName (companionId);
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
