using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTime : MonoBehaviour {

	GameObject timeController;
	// Use this for initialization
	void Start () {
		timeController = GameObject.Find("TimeController");
		timeController.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		timeController.SetActive(false);
	}
}
