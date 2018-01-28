using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/*
	<summary>
	Klasa surowca dla drzew, pozwala na interakcje z PlayerController,
	niszczenie drzew oraz wyrzucanie z nich przedmiotów
	</summary>
	*/
public class Resource_Mine : MonoBehaviour {

	// HP drzewa, które PlayerController musi zbić aby zniszczyć drzewo
	public float health = 300;
	// Przedmiotm który ma wypadać z drzewa
	public GameObject resource;
	// Ilość wypadanego przedmiotu
	public int dropCount = 3;
	// Kontrolka blokująca metodę Update() jeśli drzewo ma < 0 hp
	private bool destroyed = false;
	
	// Drzewo najpierw upada otrzymując rigid body, uruchamia wątek dropu i usunięcia obiektu gry oraz blokuje dalsze wykonywanie metody Update
	void Update () {
		if (health <= 0 && !destroyed) {
			Spawn(dropCount);
			destroyed = true;
		}
	}

	// Wątek odpowiadający za spawn przedmiotu i usunięcie obiektu asynchronicznie 10s po zniszczeniu drzewa
	void Spawn (int dropCount)
    {
		for (int i = 0; i < dropCount; i++) {
			GameObject tmp = Instantiate(resource, new Vector3(gameObject.transform.position.x + i - 1, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
		}
		Destroy(gameObject);
    }

	// Metoda interakcji dla PlayerController [hit.sendMessage("damage", damage)] wiecie o co chodzi
	void damage (int damage) {
		health -= damage;
	}
}
