using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UnderwaterEffect : MonoBehaviour {

    
    public Transform Player;
    public float waterLevel;
    public bool isUnderwater;
    FirstPersonController fpsController;
    private bool clipIsPlaying = true;

    void Update ()
    {
        if (Player.position.y < waterLevel)
        {
            isUnderwater = true;
            if (clipIsPlaying==true)
            {
                GameObject.Find("Player").GetComponent<AudioSource>().mute = true;
                GameObject.Find("UnderwaterEffectController").GetComponent<AudioSource>().Play();
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 3f;
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_RunSpeed = 3f;
                clipIsPlaying = false;
            }
 

        }
        if (Player.position.y > waterLevel)
        {
          
            isUnderwater = false;
            GameObject.Find("UnderwaterEffectController").GetComponent<AudioSource>().Stop();
            GameObject.Find("Player").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 5f;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_RunSpeed = 10f;
            clipIsPlaying = true;

        }
    }



}
