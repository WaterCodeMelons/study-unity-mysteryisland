using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class Inventory : MonoBehaviour
{

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
    GameObject Slot11;
    GameObject Slot12;
    GameObject Slot13;
    GameObject Slot14;
    GameObject Slot15;
    GameObject Slot16;
    GameObject Slot17;
    GameObject Slot18;
    GameObject Slot19;
    GameObject Slot20;
    GameObject Slot21;
    GameObject Slot22;
    GameObject Slot23;
    GameObject Slot24;


    // Use this for initialization
    public void Start()
    {
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
        Slot11 = GameObject.Find("Slot11");
        Slot12 = GameObject.Find("Slot12");
        Slot13 = GameObject.Find("Slot13");
        Slot14 = GameObject.Find("Slot14");
        Slot15 = GameObject.Find("Slot15");
        Slot16 = GameObject.Find("Slot16");
        Slot17 = GameObject.Find("Slot17");
        Slot18 = GameObject.Find("Slot18");
        Slot19 = GameObject.Find("Slot19");
        Slot20 = GameObject.Find("Slot20");
        Slot21 = GameObject.Find("Slot21");
        Slot22 = GameObject.Find("Slot22");
        Slot23 = GameObject.Find("Slot23");
        Slot24 = GameObject.Find("Slot24");
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.activeSelf == true)
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
            UstawIkone(Slot11);
            UstawIkone(Slot12);
            UstawIkone(Slot13);
            UstawIkone(Slot14);
            UstawIkone(Slot15);
            UstawIkone(Slot16);
            UstawIkone(Slot17);
            UstawIkone(Slot18);
            UstawIkone(Slot19);
            UstawIkone(Slot20);
            UstawIkone(Slot21);
            UstawIkone(Slot22);
            UstawIkone(Slot23);
            UstawIkone(Slot24);
        }


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
        if (amount == 0)
        {
            c.a = 0.4f;
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

    public bool UsunPrzedmiot(int id, int amount, bool craft)
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
        bool wynik = false;
        Text ilosc = PrzypiszSlot(id);

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

            case 11:
                ilosc = Slot11.GetComponentInChildren<Text>();
                break;

            case 12:
                ilosc = Slot12.GetComponentInChildren<Text>();
                break;

            case 13:
                ilosc = Slot13.GetComponentInChildren<Text>();
                break;

            case 14:
                ilosc = Slot14.GetComponentInChildren<Text>();
                break;

            case 15:
                ilosc = Slot15.GetComponentInChildren<Text>();
                break;

            case 16:
                ilosc = Slot16.GetComponentInChildren<Text>();
                break;

            case 17:
                ilosc = Slot17.GetComponentInChildren<Text>();
                break;

            case 18:
                ilosc = Slot18.GetComponentInChildren<Text>();
                break;

            case 19:
                ilosc = Slot19.GetComponentInChildren<Text>();
                break;

            case 20:
                ilosc = Slot20.GetComponentInChildren<Text>();
                break;

            case 21:
                ilosc = Slot21.GetComponentInChildren<Text>();
                break;

            case 22:
                ilosc = Slot22.GetComponentInChildren<Text>();
                break;

            case 23:
                ilosc = Slot23.GetComponentInChildren<Text>();
                break;

            case 24:
                ilosc = Slot24.GetComponentInChildren<Text>();
                break;

        }
        return ilosc;
    }

    public int iloscPrzedmiotow(int id)
    {
        Text text = PrzypiszSlot(id);
        int wynik = int.Parse(text.text);
        return wynik;
    }

    public int iloscPrzedmiotow(int id, bool craft)
    {
        id++;
        Text text = PrzypiszSlot(id);
        int wynik = int.Parse(text.text);
        return wynik;
    }
}
