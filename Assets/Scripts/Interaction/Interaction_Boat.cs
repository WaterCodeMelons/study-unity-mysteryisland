using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Boat : MonoBehaviour {
	public void interaction () {
		GameObject.Find("WorldController/UIController").GetComponent<UIController>().LoadScene("EndScreen");
	}
}
