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
	public float health = 500;
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
	void damage (int weaponType) {
		GameObject.FindObjectOfType<PlayerStatsController>().Stamina(GameObject.FindObjectOfType<PlayerStatsController>().Stamina() - 20);
		PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
		AudioSource audio = player.hitSoundEffect;
		switch (weaponType) {
			case 0:
				audio.clip = player.punch;
				health -= 10;
				break;
			case 1:
				audio.clip = player.pick;
				health -= 10;
				break;
			case 2:
				audio.clip = player.pick;
				health -= 100;
				break;
			case 3:
				audio.clip = player.burn;
				health -= 10;
				break;
		}
		audio.Play();
	}
}
