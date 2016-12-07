using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constants {

	// Companions
	public static string BULBASAUR = "Bulbasaur";
	public static string CHARMANDER = "Charmander";
	public static string SQUIRTLE = "Squirtle";
	public static string PIKACHU = "Pikachu";
	public static string EEVEE = "Eevee";

	// Scenes
	public static string LOGIN = "Login";
	public static string START = "Start";
	public static string PERSONALITY_TEST = "PersonalityTest";
	public static string TEST_RESULTS = "TestResults";
	public static string COLLECT_ITEM = "CollectItem";
	public static string MENU = "Menu";

	public static string[] COMPANIONS = {
		BULBASAUR, CHARMANDER, SQUIRTLE, PIKACHU, EEVEE
	};

	public static string[] SCENES = { 
		START, PERSONALITY_TEST, TEST_RESULTS, COLLECT_ITEM, MENU 
	};

	public static HashSet<string> RENDER_CAMERA_SCENES = new HashSet<string> {
		TEST_RESULTS
	};

	public static HashSet<string> RENDER_OVERLAY_SCENES = new HashSet<string> {
		START, PERSONALITY_TEST, COLLECT_ITEM, MENU
	};
}
