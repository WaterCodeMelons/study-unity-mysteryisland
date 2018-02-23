using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public Crafting CraftingPanel;
    public Inventory inv;
    public GameObject CPanel;
    //public Inventory invent;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* 
    <summary>
    Metoda włącza, bądz wyłącza Panel craftingu po wczesniejszym
    naciśnięciu przycisku;
    </summary>
    */
    public void CraftPanel()
    {
        if (CPanel.activeSelf == false)
        {
            CPanel.SetActive(true);
        }
        else
        {
            CPanel.SetActive(false);
        }
    }

    public void CraftItem()
    {
        if (CraftingPanel.CzySpelniaWymagania(CraftingPanel.IdToCraft))
        {
           CraftingPanel.UsunZinventory(CraftingPanel.IdToCraft);
           //CraftingPanel.DodajPrzedmiot(CraftingPanel.IdToCraft, 1);
           inv.DodajPrzedmiot(CraftingPanel.itemIdToCraft, 1);

        }
    }

}
