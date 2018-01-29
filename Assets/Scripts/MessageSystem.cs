using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour {


	private GameObject messageSystemPanel;
	private Text messageLabel;

	private Text messageValue;


	// Use this for initialization
	void Awake () {
		messageSystemPanel = GameObject.Find("Canvas/ResolutionControl/MessageSystem");
		messageLabel = GameObject.Find("Canvas/ResolutionControl/MessageSystem/MessageLabel").GetComponent<Text>();
		messageValue = GameObject.Find("Canvas/ResolutionControl/MessageSystem/MessageValue").GetComponent<Text>();
		messageSystemPanel.SetActive(false);
	}
	
	public void showMessage(string label, string value, float time) {
		messageSystemPanel.SetActive(true);
		messageLabel.text = label;
		messageValue.text = value;
		StartCoroutine(closeMessage(time, messageSystemPanel));
	}

	static IEnumerator closeMessage(float time, GameObject messageSystemPanel) {
		yield return new WaitForSeconds(time);
		messageSystemPanel.SetActive(false);
	}
}
