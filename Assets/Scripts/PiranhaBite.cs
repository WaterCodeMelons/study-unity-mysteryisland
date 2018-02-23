using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaBite : MonoBehaviour {

    PlayerStatsController player;
    private float playerHealth;
    public float PiranhaBiteHealthDecay;

    void OnControllerColliderHit(ControllerColliderHit col)
    {

        if (col.gameObject.tag == "Piranha")
        {
            GameObject.Find("Player").GetComponent<PlayerStatsController>().Health(GameObject.Find("Player").GetComponent<PlayerStatsController>().Health() - PiranhaBiteHealthDecay);
        }
    }
}
