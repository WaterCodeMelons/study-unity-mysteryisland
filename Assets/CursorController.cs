using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CursorController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindObjectOfType<FirstPersonController>().m_MouseLook.lockCursor = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
