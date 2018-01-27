using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIController : MonoBehaviour {
    

    public void ShowPanel(string nazwa)
    {
        GameObject panel;
        panel = GameObject.Find(nazwa);
        if(panel.activeInHierarchy==false)
        {
            panel.SetActive(true);
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HidePanel(string nazwa)
    {
        GameObject panel;
        panel = GameObject.Find(nazwa);
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
        }
    }
}
