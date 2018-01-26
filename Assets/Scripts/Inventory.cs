using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Inventory : MonoBehaviour {

    GameObject InventoryPanel;
    GameObject Slot1;
    GameObject Slot2;
    GameObject Slot3;
    GameObject Slot4;
    GameObject Slot5;
    GameObject Slot6;
    GameObject Slot7;
    GameObject Slot8;
    GameObject Slot9;
    GameObject Slot10;
    

    // Use this for initialization
    void Start()
    {
        InventoryPanel = GameObject.Find("Inventory");
        Slot1 = GameObject.Find("Slot1");
        Slot2 = GameObject.Find("Slot2");
        Slot3 = GameObject.Find("Slot3");
        Slot4 = GameObject.Find("Slot4");
        Slot5 = GameObject.Find("Slot5");
        Slot6 = GameObject.Find("Slot6");
        Slot7 = GameObject.Find("Slot7");
        Slot8 = GameObject.Find("Slot8");
        Slot9 = GameObject.Find("Slot9");
        Slot10 = GameObject.Find("Slot10");

    }

    // Update is called once per frame
    void Update () {

        if (InventoryPanel.activeSelf==true)
        {
            UstawIkone(Slot1);
            UstawIkone(Slot2);
            UstawIkone(Slot3);
            UstawIkone(Slot4);
            UstawIkone(Slot5);
            UstawIkone(Slot6);
            UstawIkone(Slot7);
            UstawIkone(Slot8);
            UstawIkone(Slot9);
            UstawIkone(Slot10);
        }
        DodajPrzedmiot(1, 1);

    }

    /* 
    <summary>
    Metoda pozwala na dodanie przedmiotu/przedmiotów do ekwipunku.
    Parametr "id" określa który przedmiot ma zostać dodany.
    Parametr "amount" określa ile takich samych przedmiotów ma zostać dodanych. 
    Zwraca true gdy plecak po dodaniu nie jest pełny ( gdy jest <= 20 przedmiotów)
    Zwraca false gdyby po dodaniu plecak był pełny 
    </summary>
    */

    public bool DodajPrzedmiot(int id, int amount)
    {
        Text ilosc = PrzypiszSlot(id);
        int PoprzedniaWartosc;
        int NowaWartosc;
        PoprzedniaWartosc = int.Parse(ilosc.text);
        NowaWartosc = PoprzedniaWartosc + amount;
        if (NowaWartosc>20)
        {
            return false;
        }
        else

        {
            ilosc.text = NowaWartosc.ToString();
            return true;
        }
                
    }
    /* 
    <summary>
    Metoda ta sprawdza aktualną ilość posiadanych przez nas przedmiotów.
    Jeżeli wynosi 0, to wczytuje "szarą" ikonę przedmiotu (niedostępny przedmiot),
    A w przeciwnym wypadku wczytuje "normalną" ikonę (dostępny przedmiot).
    Parametr "slot" przyjmuje wartość slotu który ma być sprawdzany,
    </summary>
*/
    public void UstawIkone(GameObject slot)
    {
        Text ilosc = slot.GetComponentInChildren<Text>();
        Image obraz = slot.GetComponentInChildren<Image>();
        int amount = int.Parse(ilosc.text);
        Color c = obraz.color;
        if (amount==0)
        {
            c.a = 0.35f;
        }
        else
        {
            c.a = 1f;
        }
        obraz.color = c;

    }
    /* 
    <summary>
    Metoda pozwala na usunięciu przedmiotu/ów z ekwipunku.
    Parametr "id" określa który przedmiot ma zostać usunięty.
    Parametr "amount" określa ilość usuwanego przedmiotu. 
    Parametr zwraca true gdy może usunąć przedmiot 
    (posiadana ilosc jest >= od ilosci do usuniecia).
    </summary>
    */
    public bool UsunPrzedmiot(int id, int amount)  
    {
        Text ilosc = PrzypiszSlot(id);
        int PoprzedniaWartosc;
        int NowaWartosc;
        PoprzedniaWartosc = int.Parse(ilosc.text);
        if (PoprzedniaWartosc >= amount)
        {
            NowaWartosc = PoprzedniaWartosc - amount;
            ilosc.text = NowaWartosc.ToString();
            return true;
        }
        else
        {
            return false;
        }
    }
    /* 
    <summary>
    Metoda ta pozwala sprawdzić czy gracz posiada określoną ilość przedmiotu.
    Parametr "id" określa który przedmiot ma być sprawdzony;
    Parametr "amount" określa wymaganą liczbę przedmiotu
    Metoda zwraca true gdy wymagana ilość jest spełniona,
    a zwraca false, gdy wymagana ilość nie jest spełniona.
    </summary>
    */
    public bool CzyPosiadaIlosc(int id, int amount)
    {
        bool wynik=false;
        Text ilosc= PrzypiszSlot(id);

        if (amount <= int.Parse(ilosc.text))
        {
            wynik = true;
        }
        else
        {
            wynik = false;
        }

        return wynik;
 
    }

    /* 
    <summary>
    Metoda ta przypisuje id do slotu.
    Parametr "id" określa id przedmiotu który zostaje przypisany do odpowiedniego slotu.
    Metoda zwraca pole TEXT które przechowuje odpowiedni slot
    </summary>
    */

    public Text PrzypiszSlot(int id)
    {
        Text ilosc = Slot1.GetComponentInChildren<Text>();
        switch (id)
        {
          
            case 1:
                ilosc = Slot1.GetComponentInChildren<Text>();
                break;

            case 2:
                ilosc = Slot2.GetComponentInChildren<Text>();
                break;

            case 3:
                ilosc = Slot3.GetComponentInChildren<Text>();
                break;

            case 4:
                ilosc = Slot4.GetComponentInChildren<Text>();
                break;

            case 5:
                ilosc = Slot5.GetComponentInChildren<Text>();
                break;

            case 6:
                ilosc = Slot6.GetComponentInChildren<Text>();
                break;

            case 7:
                ilosc = Slot7.GetComponentInChildren<Text>();
                break;

            case 8:
                ilosc = Slot8.GetComponentInChildren<Text>();
                break;

            case 9:
                ilosc = Slot9.GetComponentInChildren<Text>();

                break;

            case 10:
                ilosc = Slot10.GetComponentInChildren<Text>();
                break;
                
        }
        return ilosc;
    }
}
