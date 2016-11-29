using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class TestResults : MonoBehaviour {
	public static int TEXT_BOX_LENGTH = 100;
	private static string TEST_RESULTS_FILE_NAME = "FakeTestResults";

	public GameObject bulbasaur;

	private ArrayList textAfterPersonalityTest = new ArrayList();

	void Start () {
		textAfterPersonalityTest = loadFromTextFile (TEST_RESULTS_FILE_NAME);
	}

	public ArrayList getTextAfterPersonalityTest() {
		return textAfterPersonalityTest;
	}

	public IEnumerator getIter(ArrayList list) {
		IEnumerator iter = list.GetEnumerator ();
		iter.Reset ();
		iter.MoveNext ();
		return iter;
	}

	private ArrayList loadFromTextFile(string fileName) {
		TextAsset testResults = Resources.Load (fileName) as TextAsset;
		string[] lines = testResults.text.Split ('\n');
		ArrayList textContents = new ArrayList ();

		foreach (string line in lines) {
			int offset = 0;

			while (line.Length - offset > TEXT_BOX_LENGTH) {
				string partialLine = line.Substring (offset, TEXT_BOX_LENGTH);
				textContents.Add (partialLine);
				offset += TEXT_BOX_LENGTH;
			}

			textContents.Add (line.Substring (offset));
		}

		return textContents;
	}

	// Update is called once per frame
	void Update () {
	}
}
