using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	/*
	<summary>
	Klasa dla wszystkich przedmiotów, które można podnieść w grze
	</summary>
	*/
public class Interaction_Pickup : MonoBehaviour {

	private Inventory inv;

	// id przedmiotu do dodania do inventory
	public int id;
	// Ilość podnoszonego przedmiotu do inventory
	public int count;

	// Interakcja z PlayerController TODO
	public void interaction () {
		if (inv.DodajPrzedmiot(id, count)) {
			Destroy(gameObject);
		}
	}

	void Start () {
		GameObject.FindObjectOfType<PlayerStatsController>().Stamina(GameObject.FindObjectOfType<PlayerStatsController>().Stamina() - 10);
		inv = GameObject.Find("Canvas/ResolutionControl/Inventory").GetComponent<Inventory>();
	}
}
