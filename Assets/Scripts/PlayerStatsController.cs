using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStatsController : MonoBehaviour {

	[Header("Base stats value")] // Maksymalne wartości statystyk pokazane w inspektorze
	public int maxStamina = 1000;
	public int maxThirst = 100;
	public int maxHunger = 100;
	public int maxHealth = 100;

	[Space]

	[Header("Base stats decay")] // Regeneracja i degeneracja statystyk
	public float staminaDecayPerSecondRunning = 5;
	public float staminaDecayPerJump = 20;
	public float staminaRegenPerDay = 1000;
	public float thirstDecayPerDay = 200;
	public float hungerDecayPerDay = 50;
	public float healthDecayPerSecond = 1;

	[Space]

	[Header("Stat bars")] // Paski statystyk
	public GameObject staminaBar;
	public GameObject thirstBar;
	public GameObject hungerBar;
	public GameObject healthBar;

	// Aktualne wartości statystyk
	private float stamina;
	private float thirst;
	private float hunger;
	private float health;

	private FirstPersonController fpsController;


	void Start () { // Przypisuje statystykom maksymalne wartości, podane powyżej
		fpsController = GetComponent<FirstPersonController>();

		thirst = maxThirst;
		hunger = maxHunger;
		health = maxHealth;
		stamina = fpsController.stamina = fpsController.maxStamina = maxStamina;
		fpsController.staminaDecayPerSecondRunning = staminaDecayPerSecondRunning;
		fpsController.staminaDecayPerJump = staminaDecayPerJump;
		fpsController.staminaRegenPerDay = staminaRegenPerDay;
	}
	
	void Update () {
        updateStats(); // Wywołuje metodę updateStats() w ciągu każdej sekundy

		// Wyciąganie aktualnej wartości staminy z fpscontrollera
		stamina = fpsController.stamina;

		fpsController.minutesInAFullDay = TimeController.minutesInAFullDayDisplay;

		if (thirst > 0) { // Dokładnie tak samo jak hunger
			thirst -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * thirstDecayPerDay;
			thirst = Mathf.Clamp(thirst, 0, maxThirst);
		}

		if (hunger > 0) { // Jeżeli wartość głodu jest >0 zmniejsz wartość głodu o czas rzeczywyisty podzielony przez wartość hungerDecayPerDay * godzina w grze 
			hunger -= Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) * hungerDecayPerDay;
			hunger = Mathf.Clamp(hunger, 0, maxHunger);
		}

		if (hunger == 0 && thirst == 0 && health > 0) { // Jeżeli wartość głodu i pragnienia jest = 0, a wartość HP jest > 0 to hp--
			health -= Time.deltaTime * healthDecayPerSecond;
			health = Mathf.Clamp(health, 0, maxHealth);
		}
	}

	void updateStats () { // Skracanie pasków statystyk
		staminaBar.transform.localScale = new Vector3(stamina/maxStamina, 1, 1);
		thirstBar.transform.localScale = new Vector3(thirst/maxThirst, 1, 1);
		hungerBar.transform.localScale = new Vector3(hunger/maxHunger, 1, 1);
		healthBar.transform.localScale = new Vector3(health/maxHealth, 1, 1); 
	}
}
