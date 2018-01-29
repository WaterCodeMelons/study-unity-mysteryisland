using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerScript : MonoBehaviour {

	bool pokazInv;
	bool pokazMap;
	bool pokazMenu;


	public UIController kontroler;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InventoryClick();
		MapClick();
		MenuClick();
	}

	void InventoryClick() {	
		if (Input.GetKeyDown(KeyCode.I)) {
			pokazInv = !pokazInv;
			if (pokazInv) {
				kontroler.ShowPanel("Canvas/ResolutionControl/Inventory");
			}
			else {
				kontroler.HidePanel("Canvas/ResolutionControl/Inventory");
				kontroler.HidePanel("Canvas/ResolutionControl/Craft");
			}
		}
	}

	void MapClick() {	
		if (Input.GetKeyDown(KeyCode.M)) {
			pokazMap = !pokazMap;
			if (pokazMap) {
				kontroler.ShowPanel("Canvas/ResolutionControl/MapMenu");
			}
			else {
				kontroler.HidePanel("Canvas/ResolutionControl/MapMenu");
			}
		}
	}

	void MenuClick() {	
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pokazMenu = !pokazMenu;
			if (pokazMenu) {
				kontroler.ShowPanel("Canvas/ResolutionControl/Menu");
			}
			else {
				kontroler.HidePanel("Canvas/ResolutionControl/Menu");
			}
		}
	}

	public void toggleInventory () {
		pokazInv = !pokazInv;
		if (pokazInv) {
			kontroler.ShowPanel("Canvas/ResolutionControl/Inventory");
		}
		else {
			kontroler.HidePanel("Canvas/ResolutionControl/Inventory");
			kontroler.HidePanel("Canvas/ResolutionControl/Craft");
		}
	}
	public void toggleMap () {
		pokazMap = !pokazMap;
		if (pokazMap) {
			kontroler.ShowPanel("Canvas/ResolutionControl/MapMenu");
		}
		else {
			kontroler.HidePanel("Canvas/ResolutionControl/MapMenu");
		}
	}
	public void toggleMenu () {
		pokazMenu = !pokazMenu;
		if (pokazMenu) {
			kontroler.ShowPanel("Canvas/ResolutionControl/Menu");
		}
		else {
			kontroler.HidePanel("Canvas/ResolutionControl/Menu");
		}
	}



}
