using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crafting : MonoBehaviour {

    public GameObject CPanel;
    public Inventory inv;
    public int IdToCraft;
    public int[] WymaganiaDoCraftu = new int[10]; 
    GameObject CraftSlot1;
    GameObject CraftSlot2;
    GameObject CraftSlot3;
    GameObject CraftSlot4;
    GameObject CraftSlot5;
    GameObject CraftSlot6;
    GameObject CraftSlot7;
    GameObject CraftSlot8;
    GameObject CraftSlot9;
    GameObject CraftSlot10;

    // Use this for initialization
    void Start () {

        CraftSlot1 = GameObject.Find("CraftSlot1");
        CraftSlot2 = GameObject.Find("CraftSlot2");
        CraftSlot3 = GameObject.Find("CraftSlot3");
        CraftSlot4 = GameObject.Find("CraftSlot4");
        CraftSlot5 = GameObject.Find("CraftSlot5");
        CraftSlot6 = GameObject.Find("CraftSlot6");
        CraftSlot7 = GameObject.Find("CraftSlot7");
        CraftSlot8 = GameObject.Find("CraftSlot8");
        CraftSlot9 = GameObject.Find("CraftSlot9");
        CraftSlot10 = GameObject.Find("CraftSlot10");

    }
	
	// Update is called once per frame
	void Update () {
        if(IdToCraft!=0)
        {
            PokazWybranySlot(IdToCraft);
        }
        if (CPanel.activeSelf == true)
        { 

            UstawIkone(CraftSlot1);
            UstawIkone(CraftSlot2);
            UstawIkone(CraftSlot3);
            UstawIkone(CraftSlot4);
            UstawIkone(CraftSlot5);
            UstawIkone(CraftSlot6);
            UstawIkone(CraftSlot7);
            UstawIkone(CraftSlot8);
            UstawIkone(CraftSlot9);
            UstawIkone(CraftSlot10);
        }

        else
        {
            print("brak");
        }
        

	}

    public Image WybierzZdjecieSlota(int id)
    {
        Image ikona = CraftSlot1.GetComponentInChildren<Image>();
        switch (id)
        {

            case 1:
                ikona = CraftSlot1.GetComponentInChildren<Image>();
                break;

            case 2:
                ikona = CraftSlot2.GetComponentInChildren<Image>();
                break;

            case 3:
                ikona = CraftSlot3.GetComponentInChildren<Image>();
                break;

            case 4:
                ikona = CraftSlot4.GetComponentInChildren<Image>();
                break;

            case 5:
                ikona = CraftSlot5.GetComponentInChildren<Image>();
                break;

            case 6:
                ikona = CraftSlot6.GetComponentInChildren<Image>();
                break;

            case 7:
                ikona = CraftSlot7.GetComponentInChildren<Image>();
                break;

            case 8:
                ikona = CraftSlot8.GetComponentInChildren<Image>();
                break;

            case 9:
                ikona = CraftSlot9.GetComponentInChildren<Image>();

                break;

            case 10:
                ikona = CraftSlot10.GetComponentInChildren<Image>();
                break;

        }
        return ikona;
    }

    public void PokazWybranySlot(int id)
    {
        Image obraz = WybierzZdjecieSlota(id);
        Image obraz1 = WybierzZdjecieSlota(1);
        Image obraz2 = WybierzZdjecieSlota(2);
        Image obraz3 = WybierzZdjecieSlota(3);
        Image obraz4 = WybierzZdjecieSlota(4);
        Image obraz5 = WybierzZdjecieSlota(5);
        Image obraz6 = WybierzZdjecieSlota(6);
        Image obraz7 = WybierzZdjecieSlota(7);
        Image obraz8 = WybierzZdjecieSlota(8);
        Image obraz9 = WybierzZdjecieSlota(9);
        Image obraz10 = WybierzZdjecieSlota(10);
        Color c = Color.white;
        c.a = 0.4f;
        obraz1.color = c;
        obraz2.color = c; 
        obraz3.color = c;
        obraz4.color = c;
        obraz5.color = c;
        obraz6.color = c;
        obraz7.color = c;
        obraz8.color = c;
        obraz9.color = c;
        obraz10.color = c;
        c.r = 0.1f;
        obraz.color = c;

    }

    public bool CzySpelniaWymagania(int id)
    {
        bool wynik=false;
        int liczba = 0;
        if (id == 0)
        {
            wynik = false;
        }
        else
        {
            for (int i = 0; i < WymaganiaDoCraftu.Length; i++)
            {
                if (WymaganiaDoCraftu[i] <= inv.iloscPrzedmiotow(i, true))
                {
                    liczba++;
                }
            }
            if (liczba == 10)
            {
                wynik = true;
            }
        }
        return wynik;
    }

    public void UsunZinventory(int id)
    {
        for (int i = 0; i < WymaganiaDoCraftu.Length; i++)
        {
            inv.UsunPrzedmiot(i,WymaganiaDoCraftu[i],true);
        }
    }

    public void UstawIkone(GameObject slot)
    {
        Text ilosc = slot.GetComponentInChildren<Text>();
        Image obraz = slot.GetComponentInChildren<Image>();
        int amount = int.Parse(ilosc.text);
        Color c = Color.white;
        if (amount == 0)
        {
            c.a = 0.4f;
        }
        else
        {
            c=Color.black;
            c.a = 1f;
        }
        obraz.color = c;

    }

    public bool DodajPrzedmiot(int id, int amount)
    {
        Text ilosc = PrzypiszSlot(id);
        int PoprzedniaWartosc;
        int NowaWartosc;
        PoprzedniaWartosc = int.Parse(ilosc.text);
        NowaWartosc = PoprzedniaWartosc + amount;
        if (NowaWartosc > 20)
        {
            return false;
        }
        else

        {
            ilosc.text = NowaWartosc.ToString();
            return true;
        }

    }

    public Text PrzypiszSlot(int id)
    {
        Text ilosc = CraftSlot1.GetComponentInChildren<Text>();
        switch (id)
        {

            case 1:
                ilosc = CraftSlot1.GetComponentInChildren<Text>();
                break;

            case 2:
                ilosc = CraftSlot2.GetComponentInChildren<Text>();
                break;

            case 3:
                ilosc = CraftSlot3.GetComponentInChildren<Text>();
                break;

            case 4:
                ilosc = CraftSlot4.GetComponentInChildren<Text>();
                break;

            case 5:
                ilosc = CraftSlot5.GetComponentInChildren<Text>();
                break;

            case 6:
                ilosc = CraftSlot6.GetComponentInChildren<Text>();
                break;

            case 7:
                ilosc = CraftSlot7.GetComponentInChildren<Text>();
                break;

            case 8:
                ilosc = CraftSlot8.GetComponentInChildren<Text>();
                break;

            case 9:
                ilosc = CraftSlot9.GetComponentInChildren<Text>();

                break;

            case 10:
                ilosc = CraftSlot10.GetComponentInChildren<Text>();
                break;

        }
        return ilosc;
    }




}
