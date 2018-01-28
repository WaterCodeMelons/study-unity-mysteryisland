using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    

    public void ShowPanel(string nazwa)
    {
        GameObject panel;
        panel = GameObject.Find(nazwa);
        if(panel.activeInHierarchy==false)
        {
            panel.SetActive(true);
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void HidePanel(string nazwa)
    {
        GameObject panel;
        panel = GameObject.Find(nazwa);
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

	public void LoadScene(string nazwaSceny) {
		SceneManager.LoadScene(nazwaSceny);
	}


    public void Quit()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

}
