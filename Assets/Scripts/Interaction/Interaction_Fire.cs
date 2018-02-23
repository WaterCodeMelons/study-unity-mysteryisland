using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


	/*
	<summary>
	Klasa specyficznie stworzona dla interakcji ogniska, wymaga rozszerzenia
	o pobieranie drewna podczas rozpalania
	</summary>
	*/
public class Interaction_Fire : MonoBehaviour {
	
	// Klasa potrzebuje dostępu do włączania i wyłączania ognia
	public GameObject particle;
	// Czas palenia
	public float time;

	void Start() {
		
	}

	void Update () {
		time -= Time.deltaTime * 1;
		time = Mathf.Clamp(time, 0, 8 * 60);

		if (time <= 0) {
			particle.SetActive(false);
		} else {
			particle.SetActive(true);
		}
	}

	// Metoda dostępna z poziomu klasy PlayerController do interakcji
	public void interaction () {
		if (GameObject.Find("Canvas/ResolutionControl/Inventory").GetComponent<Inventory>().UsunPrzedmiot(1, 1)) {
			GameObject.FindObjectOfType<PlayerStatsController>().Stamina(GameObject.FindObjectOfType<PlayerStatsController>().Stamina() - 5);
			time += 5;
		}
	}

}
