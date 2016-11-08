using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	Dictionary<string, ArrayList> items;
	int size;

	// constructor for the Inventory
	public Inventory(Hashtable items, int size) {
		this.items = new Dictionary <string, ArrayList> ();
		this.size = size;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	// adds an item to the inventory
	void addItem(Item item) {
		ArrayList pks = new ArrayList ();
		// check if the inventory contains the item already
		if (items.ContainsKey (item.name)) {
			// adds to the List of primary key that the item has
			items [item.name].Add (item.primaryKey);
		} else {
			// add a new List as a value of the 
			items.Add (item.name, pks.Add(item.primaryKey) );
			items [item.name].Add (item.primaryKey);
		}
	}

	// removes an item from the inventory
	void removeItem(Item item) {
		if (items.ContainsKey(item.name) ) {
			items [item.name].Remove (item.primaryKey);
		} else {
			// throw an exception?
			Debug.Log("that item is not in this inventory");
		}
	}

	// returns the total count for the inventory
	int getCount() {
		int count = 0;
		foreach (string item in items) {
			count += items [item].Count;
		}
		return count;
	}

}
