using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class User : MonoBehaviour {
	int id, storyProgress;
	string name, email, password;
	Companion companion;
	Inventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// add the item to this User's inventory
	void addToInventory(Item i) {
		// on touch 
		this.inventory.addItem (i);
	}

	// removes this item from the User's inventory
	void removeFromInventory(Item i) {
		this.inventory.removeItem (i);
	}
}
