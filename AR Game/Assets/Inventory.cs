using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private Dictionary<string, int> items;
	private int size;


	// constructor for the Inventory
	public Inventory(Dictionary<string, int> items, int size) {
		this.items = new Dictionary <string, int> ();
		this.size = size;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	// adds an item to the inventory
	public void addItem(Item item) {
		// check if the inventory contains the item already
		if (items.ContainsKey (item.name)) {
			this.items[item.name] += 1;
		} else {
			this.items.Add (item.name, ++item.count);
		}
	}

	// removes an item from the inventory
	public void removeItem(Item item) {
		if (items.ContainsKey(item.name) ) {
			if (items [item.name] > 1) {
				this.items [item.name] -= 1;
			} else {
				items.Remove (item.name);
			}
		} else {
			// throw an exception?
			Debug.Log("that item is not in this inventory");
		}
	}

	// returns the total count for the inventory
	public int getCount() {
		int count = 0;
		foreach (string item in items.Keys) {
			count += items [item];
		}
		return count;
	}

	// returns all of the items as a list
	public ArrayList getItems() {
		ArrayList loi = new ArrayList ();

		foreach (string item in items.Keys) {
			for (int i = 0; i < items [item]; i++) {
				loi.Add (item);
			}
		}
		this.size = loi.Count;
		return loi;
	}

}
