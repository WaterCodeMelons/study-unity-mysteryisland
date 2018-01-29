using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenController : MonoBehaviour {



	// Use this for initialization
	void Start () {
		GameObject.Find("dayValue").GetComponent<Text>().text = "Przetrwałeś "+PlayerPrefs.GetString("dayCount")+" dni";
	}
}
