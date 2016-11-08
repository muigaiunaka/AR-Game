using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour {
	public GameObject button;
	public int val;
	public Button btn;
	public GameObject UI;
	public GameObject newCanvas;
	int ix = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			button.GetComponent<Text> ().text = "hey jesse";
			UI = new GameObject (); 


		} else if (Input.GetKeyDown (KeyCode.A)) {
			button.GetComponent<Text> ().text = "hey ari";
			newCanvas = new GameObject("Canvas");
			Canvas c = newCanvas.AddComponent<Canvas>();
			c.renderMode = RenderMode.ScreenSpaceOverlay;
			newCanvas.AddComponent<CanvasScaler>();
			newCanvas.AddComponent<GraphicRaycaster>();
			GameObject panel = new GameObject("Panel");
			panel.AddComponent<CanvasRenderer>();
			Image i = panel.AddComponent<Image>();
			i.color = Color.red;
			panel.transform.SetParent(newCanvas.transform, false);

			ix++;
			panel.transform.position = new Vector3(ix, ix, 0);
		}
	}
}
