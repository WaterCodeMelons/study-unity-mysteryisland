using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIController : MonoBehaviour {

    public GameObject Inv;
    public bool show;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.I))
        {
            show = !show;
            if (show)
            {
                ShowPanel(Inv);
            }
            else
            {
                HidePanel(Inv);
            }

        }


	}

    public void ShowPanel(GameObject smth)
    {
        if(smth.activeSelf==false)
        {
            smth.SetActive(true);
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HidePanel(GameObject smth)
    {
        if (smth.activeSelf)
        {
            smth.SetActive(false);
            GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
        }
    }
}
