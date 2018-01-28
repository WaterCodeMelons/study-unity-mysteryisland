using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaBite : MonoBehaviour {

    PlayerStatsController player;
    private float playerHealth;
    public float PiranhaBiteHealthDecay;

    void OnControllerColliderHit(ControllerColliderHit col)
    {

        playerHealth = GameObject.Find("Player").GetComponent<PlayerStatsController>().health;
        if (col.gameObject.tag == "Piranha")
        {
            playerHealth = playerHealth - PiranhaBiteHealthDecay;
            GameObject.Find("Player").GetComponent<PlayerStatsController>().health = playerHealth;
        }
    }
}
