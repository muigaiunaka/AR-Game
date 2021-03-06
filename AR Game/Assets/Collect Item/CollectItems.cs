﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Kudan.AR
{
	public class CollectItems : MonoBehaviour {
		public GameObject canvas;
		public GameObject textbox;
		public Text narTxt;
		public Button nxtBtn;
		public Button trackBtn;
		public Text nxtBtnTxt;
		public Button tracker;
		public Companion companion;
		public Item item;
		private string[] dialogue;       // The textbox dialogue
		private int counter = 0;         // Used for getting the line in the dialoge array
		private int trigger = 4;
		private Inventory inv;
		private GameObject persistent;
		private Persistent persistentScript;

		public KudanTracker _kudanTracker;	// The tracker to be referenced in the inspector. This is the Kudan Camera object.
	    public TrackingMethodMarkerless _markerlessTracking;	// The reference to the markerless tracking method that lets the tracker know which method it is using


		// Use this for initialization
		void Start () {
			// Get persistent data.
			persistent = GameObject.Find ("Persistent");
			persistentScript = persistent.GetComponent<Persistent> ();

			inv = GameObject.Find("Inventory").GetComponent<Inventory>();


			nxtBtn.onClick.AddListener(Next);
			//nxtBtn.onClick.AddListener(MarkerlessClicked);
			//nxtBtn.onClick.AddListener(StartClicked);
			//MarkerlessClicked();
			//GameObject.Find("Markerless").SetActive(true);

			// Add dialogue to the string array
			dialogue = new string[] {
				"Ya got yer companion here",
				"But yer companion need some stuff, ya know?",
				"Like bread.",
				"Some nice buttered bread.",
				"So press dat thar 'Find Stuff' button.",
				"Oh look!  There's our buddy, and a cool cat over there!",
				"Maybe dat cat will turn into bread.",
				"Because that's how owl cats work.",
				"Obviously.",
				"Anyway, go on and click the bread to add it to yer inventory.",
				"If the item disappears, press 'Find Stuff' to find it again."
			};

			//StartClicked();
			trackBtn.onClick.Invoke();

		}
		
		// Update is called once per frame
		void Update () {
			//Check if item has been added to inventory, if yes, load next scene
			if (textbox == null) {
				item.OnMouseOver();
				tracker.gameObject.transform.GetChild(0).GetComponent<Text>().text = "Next";
				tracker.onClick.RemoveListener(StartClicked);
				tracker.onClick.AddListener(loadNextScene);
				;
			}
		}

		void loadNextScene() {
			persistentScript.loadNextScene ();
		}

		// Gets the next string in the dialogue array
		void Next() {
			if (counter < dialogue.Length) {
				if (counter == 4) {

					_kudanTracker = GameObject.Find("Kudan Camera").GetComponent<KudanTracker>();
					_markerlessTracking = GameObject.Find("MarkerlessTracking").GetComponent<TrackingMethodMarkerless>();

					tracker.gameObject.SetActive(true);
					nxtBtn.gameObject.SetActive(false);
				}
				narTxt.text = dialogue[counter];
				counter++;
			} else {
				Destroy(textbox);
				textbox = null;
			}
		}

		public void MarkerlessClicked()
        {
            _kudanTracker.ChangeTrackingMethod(_markerlessTracking);	// Change the current tracking method to markerless tracking
        }

		public void StartClicked()
        {
			if (counter == 5) {
				nxtBtn.gameObject.SetActive(true);
			}

            // from the floor placer.
            Vector3 floorPosition;			// The current position in 3D space of the floor
            Quaternion floorOrientation;	// The current orientation of the floor in 3D space, relative to the device


            _kudanTracker.FloorPlaceGetPose(out floorPosition, out floorOrientation);	// Gets the position and orientation of the floor and assigns the referenced Vector3 and Quaternion those values
            _kudanTracker.ArbiTrackStart(floorPosition, floorOrientation);				// Starts markerless tracking based upon the given floor position and orientations
        	
		}
	}
}