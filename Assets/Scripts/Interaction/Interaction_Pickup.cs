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

	// Ilość podnoszonego przedmiotu do inventory
	public int count;

	// Interakcja z PlayerController TODO
	public void interaction () {
		Destroy(gameObject);
	}

}
