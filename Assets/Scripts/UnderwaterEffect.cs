using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UnderwaterEffect : MonoBehaviour {

    
    public Transform Player;
    public float waterLevel;
    public bool isUnderwater;
    public AudioSource underwaterAmbience;
    FirstPersonController fpsController;


	void Update ()
    {
        if (Player.position.y < waterLevel)
        {
            isUnderwater = true;
 

        }
        if (Player.position.y > waterLevel)
        {
          
            isUnderwater = false;

        }
    }




}
