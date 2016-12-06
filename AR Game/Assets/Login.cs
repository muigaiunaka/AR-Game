using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	/** Variables */

	//Static variables
	public static string Email = "";
	public static string Password = "";

	//Public Variables
	private string CurrentMenu = "Login";

	// Private Variables
	private string CreateAccountUrl = "http://localhost:8888/createAcct.php";
	private string LoginUrl = "http://localhost:8888/login.php";
	//private string LoginUrl = "";
	private string ConfirmPassword = "";
	private string ConfirmEmail = "";
	private string CEmail = "";
	private string CPassword = "";

	// GUI Test Section
	private float X;
	private float Y;
	private float Width;
	private float Height;
	private float btnWidth;
	private float btnHeight;


	// Use this for initialization
	void Start ()
	{

		Width = Screen.width;
		Height = Screen.height;
		X = 0;
		Y = 0;
		btnWidth = 150;
		btnHeight = 40;
	}
		
	// Main GUI Function
	void OnGUI ()
	{
		if (CurrentMenu == "Login") {
			LoginGUI ();
		} else if (CurrentMenu == "Create Account") {
			// Call create account GUI method
			CreateAccountGUI ();
		}
	}
	// end ONGUI

	/** Custom Methods*/

	// This method will login the accounts
	void LoginGUI ()
	{	
		GUI.Box (new Rect (X, Y, Width, Height), "Login");
		// Open Create Account window
		if (GUI.Button (new Rect (Width/4, Height - 60, btnWidth, btnHeight), "Create Account")) {
			CurrentMenu = "Create Account";
		}
		// Open Login window
		if (GUI.Button (new Rect (Width/4 + 200, Height - 60, btnWidth, btnHeight), "Log In")) {
			//CurrentMenu = "Login";
			StartCoroutine( LoginToGame() );
		}// end Buttons

		// Email Input Field
		GUI.Label (new Rect (Width/4, (Height / 3), 220, 50), "Email:");
		Email = GUI.TextField (new Rect (Width/4, Height / 3 + 20, Width/2, 30), Email);
		// Password Input Field
		GUI.Label (new Rect (Width/4, (Height / 3) + 60, 220, 50), "Password:");
		Password = GUI.TextField (new Rect (Width/4, Height / 3 + 80, Width/2, 30), Password);
	}
	// End Login GUI

	// This method will be the GUI for creating the account.
	void CreateAccountGUI ()
	{
		GUI.Box (new Rect (X, Y, Width, Height), "Create Account");

		// Email Input Field
		GUI.Label (new Rect (Width/4, (Height / 5), 220, 50), "Email:");
		CEmail = GUI.TextField (new Rect (Width/4, Height / 5 + 20, Width/2, 30), CEmail);
		// Password Input Field
		GUI.Label (new Rect (Width/4, (Height / 5) + 60, 220, 50), "Password:");
		CPassword = GUI.TextField (new Rect (Width/4, Height / 5 + 80, Width/2, 30), CPassword);
		// Email Input Field
		GUI.Label (new Rect (Width/4, (Height / 5) + 120, 220, 50), "Confirm Email:");
		ConfirmEmail = GUI.TextField (new Rect (Width/4, Height / 5 + 140, Width/2, 30), ConfirmEmail);
		// Password Input Field
		GUI.Label (new Rect (Width/4, (Height / 5) + 180, 220, 50), "Confirm Password:");
		ConfirmPassword = GUI.TextField (new Rect (Width/4, Height / 5 + 200, Width/2, 30), ConfirmPassword);

		// Open Create Account window
		if (GUI.Button (new Rect (Width/4, Height - 60, btnWidth, btnHeight), "Create Account")) {
			if (ConfirmPassword == CPassword && ConfirmEmail == CEmail) {
				StartCoroutine(CreateAccount());
				//CurrentMenu = "Create Account";
			} else {
				//StartCoroutine( LoginToGame() );
				Debug.Log("Those don't match");
			}
		}
		// Open Login window
		if (GUI.Button (new Rect (Width/4 + 200, Height - 60, btnWidth, btnHeight), "Back")) {
			CurrentMenu = "Login";
		}// end Buttons
	}
	// End CA GUI

	// end Custom Methods

	/** Start Coroutines*/

	// Create the Accounts
	IEnumerator CreateAccount ()
	{
		WWWForm Form = new WWWForm ();
		Form.AddField ("Email", CEmail);
		Form.AddField ("Password", CPassword);
		WWW CreateAcctWWW = new WWW (CreateAccountUrl, Form);
		// wait for the php to send something back to unity
		yield return CreateAcctWWW;
		if (CreateAcctWWW.error != null) {
			Debug.LogError ("Cannot connect to account creation. Error: " + CreateAcctWWW.error);
		} else {
			string CreateAcctReturn = CreateAcctWWW.text;
			Debug.Log ("CAR: " + CreateAcctReturn);
			Debug.Log (CEmail);
			//Debug.Log (CreateAcctWWW.text);
			if (CreateAcctReturn == "Success") {
				Debug.Log ("Success");
				CurrentMenu = "Login";
				Debug.Log (CurrentMenu);
			} else if (CreateAcctReturn == (CEmail + "has already registered an account")) {
				CurrentMenu = "Login";

			}
		}
	}

	// Login to the game
	IEnumerator LoginToGame ()
	{
		WWWForm loginForm = new WWWForm ();
		loginForm.AddField ("Email", Email);
		loginForm.AddField ("Password", Password);
		WWW LoginWWW = new WWW (LoginUrl, loginForm);
		yield return LoginWWW;
		Debug.Log(LoginWWW.text);

	}

	// end Coroutines



}
