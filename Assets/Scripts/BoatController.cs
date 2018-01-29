using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

	public bool canBoat = false;

	void OnTriggerEnter (Collider hit) {
		if (hit.transform.tag == "Player") {
			GameObject.Find("Canvas/ResolutionControl/MessageSystem").GetComponent<MessageSystem>().showMessage("Hmm...", "To wygląda na dogodne miejsce do zbudowania łodzi.", 5);
		}
	}

	void OnTriggerStay (Collider hit) {
		if (hit.transform.tag == "Player") {
			canBoat = true;
		}
	}

	void OnTriggerExit (Collider hit) {
		if (hit.transform.tag == "Player") {
			canBoat = false;
		}
	}

}
