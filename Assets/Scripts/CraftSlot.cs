using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IPointerClickHandler
{

    public int itemIdToCraft;

    [Space]
    [Space]

    public int slotid;
    public Crafting craft;
    public int[] Wymagania = new int[10];
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            craft.IdToCraft = slotid;
            craft.itemIdToCraft = itemIdToCraft;
            craft.WymaganiaDoCraftu = Wymagania;
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
