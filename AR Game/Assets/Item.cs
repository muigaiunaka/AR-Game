using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour {
	public string name;
	public int primaryKey;

	public Item(string name, int primaryKey) {
		this.name = name;
		this.primaryKey = primaryKey;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
