using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	public GameObject canvas;
	private Button menu;
	private Button closeMenu;
	private GameObject panel;
	private bool isOpen;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		isOpen = false;
		canvas = GameObject.Find ("Canvas");
		panel = GameObject.Find ("Panel");
		panel.gameObject.SetActive (false);

		this.menu = canvas.GetComponentInChildren<Button>();
		this.closeMenu = panel.GetComponentInChildren<Button>();

		this.closeMenu.onClick.AddListener (toggleMenu);
		this.menu.onClick.AddListener (toggleMenu);

		Debug.Log (menu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// toggle the menu 
	public void toggleMenu() {
		if (isOpen) {
			// hide the menu panel
			panel.gameObject.SetActive (false);
			menu.gameObject.SetActive (true);
		} else {
			// show the menu panel
			panel.gameObject.SetActive (true);
			menu.gameObject.SetActive (false);
		} 
		isOpen = !isOpen;
	}

}
