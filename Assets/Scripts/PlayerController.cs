using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

	/*
	<summary>
	Klasa odpowiedzialna za najważniejsze funkcje gracza.
	Odpowiada za zunifikowaną interakcje i wysyłanie wiadomości do metod interaction(), resource() oraz damage().
	Główną zaletą tego skryptu jest to, iż pozwala na zakodowanie interakcji na samym przedmiocie a nie w tym skrypcie.
	Pozwala na lepszą organizację kodu.
	</summary>
	*/
public class PlayerController : MonoBehaviour {

	[Header("Dependencies")]
	FirstPersonController fpsController;
	public Camera playerCamera;
	public Animator playerAnimator;
	public Text raycastTooltip;

	[Space]

	[Header("Raycast data")]
	public float interactionRange = 1.5f;
	private Vector3 rayStart;
	private Vector3 rayDirection;

	[Space]

	[Header("Combat data")]
	public bool combatOn = true;
	public float fistDamage = 10;
	public float attackCooldownInSec = 1; // predefiniowany cooldown
	private float cooldown = 0; // aktualny cooldown, który zmienia się po wykonaniu ataku

	void Update () {
		castRay();
		animate();
    }


	/*
	<summary>
	Metoda wypuszczająca ray, sprawdzająca kolizję z tagami "interactable" lub "resource",
	pozwala na interakcję tylko z nimi. Obiekty "interactable" pozwalają na interakcję klawiszem "F".
	Obiekty "resource" mogą zostać uderzone LMB
	</summary>
	*/
	void castRay () {
		rayStart = playerCamera.transform.position + (playerCamera.transform.forward * 0.5f);

		Debug.DrawRay(rayStart, playerCamera.transform.forward * interactionRange);

		RaycastHit hit;
        if (Physics.Raycast(rayStart, playerCamera.transform.forward, out hit, interactionRange))
        {
			if (hit.transform.tag == "interactable") {
				raycastTooltip.text = "[F] " + hit.transform.GetComponent<Item>().tooltip;
				raycastTooltip.enabled = true;
				if (Input.GetKeyUp(KeyCode.F)) {
					// Wykonujemy metodę interaction() w obiekcie trafionym raycastem
					hit.transform.SendMessage("interaction");
				} else {
					// Lub możemy uderzyć ten przedmiot aby go przesunąć lub wykonać inną akcję, którą można określić na samym przedmiocie
					struck(hit);
				}
			} else if (hit.transform.tag == "resource") {
				struck(hit); // Uderzamy obiekt resource w celu zmniejszenia jego hp aby wydobyć z niego surowce
			} else {
				raycastTooltip.enabled = false;
			}
        } else {
			raycastTooltip.enabled = false;
		}
	}

	// Mała metoda pozwalająca na lepszą organizację kodu między animacjami biegania, interakcji i uderzenia
	void animate () {
		playerAnimator.SetBool("isRunning", !fpsController.m_IsWalking);
	}

	/*
	<summary>
	Metoda wykonująca funkcje uderzenia, korzysta z wątku stopującego animacje po czasie cooldownu
	oraz z wątku aplikującego obrażenia i AddForce dla rigidbody w połowie animacji, tak aby zgrać
	zadanie obrażeń i zaaplikowanie siły z animacją uderzenia.
	</summary>
	*/
	void struck (RaycastHit hit) {
		if (combatOn) {
			if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown == 0) {
				playerAnimator.SetBool("punch" + Random.Range(1, 3), true);
				StartCoroutine(Damage(hit));
				cooldown = 1;
				StartCoroutine(stopAnim(cooldown));
			} else {
				cooldown -= Time.deltaTime;
				cooldown = Mathf.Clamp(cooldown, 0, 10);
			}
		}
	}

	// Wątek stopujący animację w cooldown ataku
	IEnumerator stopAnim (float cooldown) {
		yield return new WaitForSeconds(cooldown);
		playerAnimator.SetBool("punch1", false);
		playerAnimator.SetBool("punch2", false);
	}

	// Wątek aplikujący obrażenia i siłę na rigidbody w odpowiednim czasie trwania animacji
	IEnumerator Damage (RaycastHit hit) {
		yield return new WaitForSeconds(0.5f);
		hit.transform.SendMessage("damage", fistDamage);
		hit.transform.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * 15, ForceMode.Impulse);
	}
}
