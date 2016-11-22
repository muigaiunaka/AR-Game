using UnityEngine;
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
		private string[] dialogue;       // The textbox dialogue
		private int counter = 0;         // Used for getting the line in the dialoge array
		private int trigger = 4;

		public KudanTracker _kudanTracker;	// The tracker to be referenced in the inspector. This is the Kudan Camera object.
	    public TrackingMethodMarkerless _markerlessTracking;	// The reference to the markerless tracking method that lets the tracker know which method it is using


		// Use this for initialization
		void Start () {
			nxtBtn.onClick.AddListener(Next);
			//nxtBtn.onClick.AddListener(MarkerlessClicked);
			//nxtBtn.onClick.AddListener(StartClicked);
			//MarkerlessClicked();

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
				"Anyway, go on and click the bread to add it to yer inventory."
			};

			//StartClicked();
			trackBtn.onClick.Invoke();

		}
		
		// Update is called once per frame
		void Update () {
		}

		// Gets the next string in the dialogue array
		void Next() {
			if (counter < dialogue.Length) {
				narTxt.text = dialogue[counter];
				counter++;
			} else {
				Destroy(textbox);
			}
		}

		public void MarkerlessClicked()
        {
            _kudanTracker.ChangeTrackingMethod(_markerlessTracking);	// Change the current tracking method to markerless tracking
        }

		public void StartClicked()
        {
			Debug.Log("Started!");

            // from the floor placer.
            Vector3 floorPosition;			// The current position in 3D space of the floor
            Quaternion floorOrientation;	// The current orientation of the floor in 3D space, relative to the device


            _kudanTracker.FloorPlaceGetPose(out floorPosition, out floorOrientation);	// Gets the position and orientation of the floor and assigns the referenced Vector3 and Quaternion those values
            _kudanTracker.ArbiTrackStart(floorPosition, floorOrientation);				// Starts markerless tracking based upon the given floor position and orientations
        	
		}
	}
}