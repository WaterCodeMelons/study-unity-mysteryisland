using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
/*
<summary>
Klasa która ma za zadanie reagować na eventy.
Dodawanie hp/ wyrzucanie przedmiotu/ów/
</summary>
 */

public class SlotScript : MonoBehaviour, IPointerClickHandler
{
    public Inventory plecak;
    public int PrzedmiotID;
    public GameObject ModelPrzedmiotu;
    public bool Jadalne;
    GameObject Player;
    /*
    <summary>
    Metoda ta sprawdza czy został gracz kliknął na pole obiektu.
    W zalezności od klawisza wykonuje okreslone funkcje
    </summary>
    */
    public void OnPointerClick(PointerEventData eventData)
    {    
        if (eventData.button == PointerEventData.InputButton.Right && Jadalne)
        {
            if(plecak.UsunPrzedmiot(PrzedmiotID, 10))
            {
                // dodajHP;
            }
        }
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(plecak.UsunPrzedmiot(PrzedmiotID, 10))
            {
                Instantiate(ModelPrzedmiotu, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
            }
            
        }
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Player = GameObject.Find("Player");
    }
}
