using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	/*
	<summary>
	Klasa surowca dla drzew, pozwala na interakcje z PlayerController,
	niszczenie drzew oraz wyrzucanie z nich przedmiotów
	</summary>
	*/
public class Resource_Tree : MonoBehaviour {

	// HP drzewa, które PlayerController musi zbić aby zniszczyć drzewo
	public float health = 50;
	// Przedmiotm który ma wypadać z drzewa
	public GameObject resource;
	// Ilość wypadanego przedmiotu
	public int dropCount = 3;
	// Kontrolka blokująca metodę Update() jeśli drzewo ma < 0 hp
	private bool destroyed = false;
	
	// Drzewo najpierw upada otrzymując rigid body, uruchamia wątek dropu i usunięcia obiektu gry oraz blokuje dalsze wykonywanie metody Update
	void Update () {
		if (health <= 0 && !destroyed) {
			gameObject.AddComponent<Rigidbody>();
			StartCoroutine(Spawn(dropCount));
			destroyed = true;
		}
	}

	// Wątek odpowiadający za spawn przedmiotu i usunięcie obiektu asynchronicznie 10s po zniszczeniu drzewa
	IEnumerator Spawn (int dropCount)
    {
        yield return new WaitForSeconds(10);
		
		for (int i = 0; i < dropCount; i++) {
			GameObject tmp = Instantiate(resource, new Vector3(gameObject.transform.position.x + i - 1, gameObject.transform.position.y + 3, gameObject.transform.position.z), Quaternion.identity);
			tmp.AddComponent<Rigidbody>();
			tmp.AddComponent<BoxCollider>();
		}
		Destroy(gameObject);
    }

	// Metoda interakcji dla PlayerController [hit.sendMessage("damage", damage)] wiecie o co chodzi
	void damage (int damage) {
		health -= damage;
	}
}
