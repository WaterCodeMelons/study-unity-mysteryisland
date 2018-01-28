using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Berry : MonoBehaviour {

	// Klasa potrzebuje dostępu do włączania i wyłączania widoczności jagód
	private Transform berries;
	private Inventory inv;
	// Czas palenia
	private float time;

	void Start() {
		inv = GameObject.Find("Canvas/ResolutionControl/Inventory").GetComponent<Inventory>();
		berries = transform.GetChild(0);
		time = 0;
	}

	void Update () {
		time -= Time.deltaTime * 1;
		time = Mathf.Clamp(time, 0, 8 * 60);

		if (time == 0) {
			berries.gameObject.SetActive(true);
		} else {
			berries.gameObject.SetActive(false);
		}
	}

	// Metoda dostępna z poziomu klasy PlayerController do interakcji
	public void interaction () {
		if (time == 0 && inv.DodajPrzedmiot(2, 1)) {
			time = 8 * 60;
		}
	}

}
