using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;

public class Decide : MonoBehaviour {
	private GameObject persistent;
	private Persistent persistentScript;

	private Button decisionButton;
	private Canvas canvas;
	public Decision decision;

	void Start () {
		persistent = GameObject.Find ("Persistent");
		persistentScript = persistent.GetComponent<Persistent> ();

		canvas = persistentScript.getSceneCanvas ();
		decisionButton = gameObject.GetComponent<Button>();
		decisionButton.onClick.AddListener (decide);

	}

	void decide() {
		PersonalityTest personalityTest = canvas.GetComponent<PersonalityTest>();
		Destroy (personalityTest.currentQuestion);

		foreach (GameObject option in personalityTest.currentDecisions) {
			Destroy (option);
		}

		personalityTest.currentDecisions.Clear ();
		personalityTest.parseQuestion (decision.getNextQuestion ());

		if (personalityTest.isFinished) {
			Destroy (GameObject.Find ("TestTitle"));
			persistentScript.loadNextScene ();
		};
	}

	// Update is called once per frame
	void Update () {
		// Touch
		if (Input.touchCount > 0 && (TouchPhase.Began == Input.GetTouch (0).phase)) {
			Debug.Log ("Touched!");
		}


		/*
		Began	A finger touched the screen.
		Moved	A finger moved on the screen.
		Stationary	A finger is touching the screen but hasn't moved.
		Ended	A finger was lifted from the screen. This is the final phase of a touch.
		Canceled	The system cancelled tracking for the touch.
		*/
	}
}


public class Decision {
	private string option;
	private XmlNodeList nextQuestions;

	public Decision(string option) {
		this.option = option;
		this.nextQuestions = null;
	}

	public Decision(string option, XmlNodeList nextQuestions) {
		this.option = option;
		this.nextQuestions = nextQuestions;
	}

	public string getOptionText() {
		return this.option;
	}

	public void setOptionText(string option) {
		this.option = option;
	}

	public XmlNodeList getNextQuestion() {
		return this.nextQuestions;
	}

	public void setNextQuestion(XmlNodeList nextQuestions) {
		this.nextQuestions = nextQuestions;
	}

	override
	public string ToString() {
		return this.option;
	}
}
