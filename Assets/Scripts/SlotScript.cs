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
    private Inventory plecak;
    private BuildController builder;
    private PlayerStatsController playerStats;
    public int PrzedmiotID;
    public GameObject ModelPrzedmiotu;
    public bool droppable;
    public bool edible;
    public bool buildable;
    public bool equipable;
    GameObject Player;
    /*
    <summary>
    Metoda ta sprawdza czy został gracz kliknął na pole obiektu.
    W zalezności od klawisza wykonuje okreslone funkcje
    </summary>
    */
    public void OnPointerClick(PointerEventData eventData)
    {    
        if (eventData.button == PointerEventData.InputButton.Right)
        {

            if (droppable) {
                drop();
            } else if (edible) {
                eat();
            } else if (buildable) {
                build();
            } else if (equipable) {
                equip();
            }
        }
    }

    void drop () {
        if(plecak.UsunPrzedmiot(PrzedmiotID, 1))
        {
            Instantiate(ModelPrzedmiotu, Player.transform.position + (Player.transform.forward * 2), Player.transform.rotation);
        }
    }
    void eat () {
        if(plecak.UsunPrzedmiot(PrzedmiotID, 1))
        {
            switch (PrzedmiotID) {
                case 2:
                    playerStats.Thirst(playerStats.Thirst() +  2);
                    playerStats.Hunger(playerStats.Hunger() +  2);
                    playerStats.Health(playerStats.Health() + 10);
                    break;
                case 16:
                    playerStats.Thirst(playerStats.Thirst() +  2);
                    playerStats.Hunger(playerStats.Hunger() + 10);
                    playerStats.Health(playerStats.Health() +  2);
                    break;
                case 17:
                    playerStats.Thirst(playerStats.Thirst() + 10);
                    playerStats.Hunger(playerStats.Hunger() +  2);
                    playerStats.Health(playerStats.Health() +  2);
                    break;
            }
        }
    }
    void build () {
        if(plecak.UsunPrzedmiot(PrzedmiotID, 1))
        {
            switch (PrzedmiotID) {
                case 18:
                    builder.build(0);
                    break;
                case 19:
                    builder.build(1);
                    break;
                case 20:
                    builder.build(2);
                    break;
                case 24:
                    builder.build(3);
                    break;
            }
            GameObject.Find("WorldController/InputController").GetComponent<InputControllerScript>().toggleInventory();
        }
    }

    void equip () {
        if(plecak.UsunPrzedmiot(PrzedmiotID, 1))
        {
            plecak.DodajPrzedmiot(PrzedmiotID, 1);
            switch (PrzedmiotID) {
                case 21:
                    Player.GetComponent<PlayerController>().weaponType = 1;
                    break;
                case 22:
                    Player.GetComponent<PlayerController>().weaponType = 2;
                    break;
                case 23:
                    Player.GetComponent<PlayerController>().weaponType = 3;
                    break;
            }
        }
    }

    // Use this for initialization
    void Start () {
        plecak = GameObject.Find("Inventory").GetComponent<Inventory>();
        Player = GameObject.Find("Player");
        builder = GameObject.Find("WorldController/BuildController").GetComponent<BuildController>();
        playerStats = Player.GetComponent<PlayerStatsController>();
	}
}
