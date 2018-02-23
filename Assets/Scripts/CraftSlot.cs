using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftSlot : MonoBehaviour, IPointerClickHandler
{

    // Obiekt podpowiedzi do craftu
    private GameObject tooltipPanel;

    // Text, który ma zostać wyświetlony
    private Text tooltipNazwaItemu;

    // Prefab wymaganego itemu
    public GameObject prefabWymaganyItem;

    // Miejsce, gdzie zostaną pokazane wymagania
    private GameObject tooltipCraftRequirements;

    
    // Nazwa przedmiotu, który zostanie wycraftowany
    public string nazwaPrzedmiotu;
    public int itemIdToCraft;

    [Space]
    [Space]

    public int slotid;
    public Crafting craft;
    public int[] Wymagania = new int[24];
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            craft.IdToCraft = slotid;
            craft.itemIdToCraft = itemIdToCraft;
            craft.WymaganiaDoCraftu = Wymagania;
            tooltipPanel.SetActive(true);
            killAllKids();
            tooltipNazwaItemu.text = gameObject.GetComponent<CraftSlot>().nazwaPrzedmiotu.ToString();
            for (int i = 0; i < Wymagania.Length; i++)
            {
                if (Wymagania[i] != 0) {
                    GameObject itemUtworzony = Instantiate(prefabWymaganyItem, tooltipCraftRequirements.transform);
                    itemUtworzony.transform.SetParent(tooltipCraftRequirements.transform, false);
                    GameObject itemInventory = findKidWithName("Slot"+(i+1));
                    itemUtworzony.transform.Find("PanelSlot/Slot/Amount").gameObject.GetComponent<Text>().text = Wymagania[i].ToString();
                    itemUtworzony.transform.Find("PanelSlot/Slot/ItemIcon").gameObject.GetComponent<Image>().sprite = itemInventory.transform.Find("ItemIcon").gameObject.GetComponent<Image>().sprite;
                }
                
            }
        }
    }


    

    // Use this for initialization
    void Awake () {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
        tooltipPanel = GameObject.Find("Canvas/ResolutionControl/CraftTipPanel");
        tooltipNazwaItemu = GameObject.Find("Canvas/ResolutionControl/CraftTipPanel/CraftItemName").GetComponent<Text>();
        tooltipCraftRequirements = GameObject.Find("Canvas/ResolutionControl/CraftTipPanel/CraftRequirements");
	}



    // Zabij dzieci gameobject
    void killAllKids() {
        if (tooltipCraftRequirements.transform.childCount!=0) {
            foreach (Transform child in tooltipCraftRequirements.transform) {
            GameObject.Destroy(child.gameObject);
            }
        }
        
    }

    // Szuka dziecka w Inventory
    GameObject findKidWithName(string name) {
        GameObject[] arrayOfRequirements = GameObject.FindGameObjectsWithTag("Item");
        foreach (var requirement in arrayOfRequirements)
        {
            if (requirement.transform.name == name) {
                return requirement;
            }
        }
        return null;
    }


}
