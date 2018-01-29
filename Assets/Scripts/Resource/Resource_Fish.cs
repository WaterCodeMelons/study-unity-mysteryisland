using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Fish : MonoBehaviour
{
    void damage (int weaponType) {
		PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        Inventory inv = GameObject.Find("Canvas/ResolutionControl/Inventory").GetComponent<Inventory>();
		AudioSource audio = player.hitSoundEffect;
		switch (weaponType) {
			case 0:
				audio.clip = player.punch;
				break;
			case 1:
				audio.clip = player.punch;
				break;
			case 2:
				audio.clip = player.punch;
				break;
			case 3:
				audio.clip = player.punch;
				break;
		}
		audio.Play();
        inv.DodajPrzedmiot(16, 1);
        Destroy(gameObject);
	}

	
}
