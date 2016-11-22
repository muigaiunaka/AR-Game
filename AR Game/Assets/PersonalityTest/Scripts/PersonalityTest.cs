using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class PersonalityTest : MonoBehaviour {
	private GameObject persistent;
	private  Persistent persistentScript;

	public static char[] DECISION_LETTERS = new char[5]{ 'a', 'b', 'c', 'd', 'e' };
	private static string XML_FILE = "FairyTailMagicText";

	public GameObject decisionPrefab;
	public GameObject questionPrefab;
	public GameObject currentQuestion;
	public GameObject canvas;
	public bool isFinished = false;

	private int questionCount;

	public HashSet<GameObject> currentDecisions;

	// Use this for initialization
	void Start () {
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

		canvas = GameObject.Find ("Canvas");
		resetCanvasTransform ();

		questionCount = 1;
		currentDecisions = new HashSet<GameObject> ();
		Debug.Log (Resources.Load (XML_FILE));

		TextAsset xmlAsset = Resources.Load (XML_FILE) as TextAsset;
		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (xmlAsset.text);
		XmlNodeList personalityTest = xmlDoc.GetElementsByTagName ("story");
		XmlNodeList firstQuestion = personalityTest [0].ChildNodes;
		parseQuestion (firstQuestion);
	}

	public void parseQuestion (XmlNodeList question) {
		int counter = 45;

		foreach (XmlNode item in question) {
			string tag = item.Name;
			resetCanvasTransform ();

			switch (item.Name) 
			{
			case "description":
				Debug.Log ("Description: " + item.InnerText);
				break;

			case "prompt":
				if ("n".Equals (item.Attributes ["end"].Value)) {
					GameObject questionObj = Instantiate (questionPrefab) as GameObject;
					questionObj.GetComponent<Text> ().text = (questionCount.ToString () + ") " + item.InnerText);
					questionObj.transform.SetParent (canvas.transform, false);
					questionObj.transform.localScale = Vector3.one;
					currentQuestion = questionObj;
					questionCount++;
				}
				break;

			case "opt":
				string text = item.SelectSingleNode ("decision").FirstChild.Value;
				Decision decision = new Decision (text, item.ChildNodes);
				GameObject decisionObj = Instantiate (decisionPrefab, new Vector3 (0, counter, 0), Quaternion.identity) as GameObject;
				decisionObj.transform.SetParent (canvas.transform, false); 
					//decisionObj.transform.position = ;
				decisionObj.GetComponentInChildren<Text> ().text = "  " + (DECISION_LETTERS [currentDecisions.Count]) + ") " + decision.getOptionText ();
				decisionObj.GetComponent<Decide> ().decision = decision;
				currentDecisions.Add (decisionObj);
				counter -= 40;
				break;

			case "ending":
//				Retreive data from the ending tag
//				GameObject endingObj = Instantiate (questionPrefab, canvas.transform) as GameObject;
//				endingObj.GetComponent<Text> ().text = item.InnerText;
//				endingObj.transform.position = new Vector3 ();

				persistentScript.setPersonalityTestResult (int.Parse (item.InnerText));
				isFinished = true;
				break;

//				Create a button to go to the companion scene.
//				GameObject nextBtn = new GameObject("Next Button");
//				nextBtn.transform.SetParent(canvas.transform);
//				nextBtn.AddComponent<Image>();
//				nextBtn.GetComponent<RectTransform>();
//				Button btn = nextBtn.AddComponent<Button>();
//				btn.onClick.AddListener(nextScene);
//				return;
			}
		}
	}

	void resetCanvasTransform () {
		canvas.transform.position = Vector3.zero;
		canvas.transform.rotation = Quaternion.identity;
	}

	// Update is called once per frame
	void Update () {
	}
}
