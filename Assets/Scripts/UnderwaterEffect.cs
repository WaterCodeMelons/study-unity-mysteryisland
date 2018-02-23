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
            Physics.gravity = new Vector3(0, -9.81f/4, 0);
            if (clipIsPlaying==true)
            {
                GameObject.Find("Player").GetComponent<AudioSource>().mute = true;
                GameObject.Find("UnderwaterEffectController").GetComponent<AudioSource>().Play();
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 3f;
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_RunSpeed = 3f;
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_JumpSpeed = 2f;
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_StickToGroundForce = 0.1f;
                GameObject.Find("Player").GetComponent<FirstPersonController>().m_GravityMultiplier = 0.1f;
                clipIsPlaying = false;
            }
 

        }
        if (Player.position.y > waterLevel)
        {
          
            isUnderwater = false;
            Physics.gravity = new Vector3(0, -9.81f, 0);
            GameObject.Find("UnderwaterEffectController").GetComponent<AudioSource>().Stop();
            GameObject.Find("Player").GetComponent<AudioSource>().mute = false;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_WalkSpeed = 5f;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_RunSpeed = 10f;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_JumpSpeed = 10f;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_StickToGroundForce = 10f;
            GameObject.Find("Player").GetComponent<FirstPersonController>().m_GravityMultiplier = 2f;
            clipIsPlaying = true;

        }
    }



}
