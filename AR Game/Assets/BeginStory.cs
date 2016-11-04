using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeginStory : MonoBehaviour {
	private int counter = 0;

	// Use this for initialization
	void Start () {
		print("Script Added!");

		GameObject contBtn = GameObject.Find("Continue Btn");

		Button btn = contBtn.AddComponent<Button>();
		contBtn.AddComponent<Image>();
		btn.onClick.AddListener(Next);

		GameObject cTextGO = new GameObject("Continue Text");
		cTextGO.transform.SetParent(contBtn.transform);

	    Text contText = cTextGO.AddComponent<Text>();
	    contText.text = "Next";
		contText.color = Color.black;
		contText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		contText.transform.position = new Vector2(50, -15);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Next() {
		counter++;
		Text narrText = GameObject.Find("Narrative Text").GetComponent<Text>();
		narrText.text = "You clicked next " + counter + " time(s)";
	}
}
