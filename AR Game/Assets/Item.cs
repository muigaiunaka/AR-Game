using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {
	private string name;

	public Item(string name) {
		this.name = name;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	// returns the name of the item
	public string getName() {
		return this.name;
	}

}
