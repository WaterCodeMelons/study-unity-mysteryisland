using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWorld : MonoBehaviour {

    PlayerStatsController player;
    private float playerHealth;
    public float EndWorldEnterHealthDecay;
    public float EndWorldStayHealthDecay;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="EndWorldTrigger")
        {
            GameObject.Find("Canvas/ResolutionControl/MessageSystem").GetComponent<MessageSystem>().showMessage("Uważaj!", "Oddalając się od lądu narażasz się na niebezpieczeństwo!", 5);
            GameObject.Find("Player").GetComponent<PlayerStatsController>().Health(GameObject.Find("Player").GetComponent<PlayerStatsController>().Health() - EndWorldEnterHealthDecay);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "EndWorldTrigger")
        {
            GameObject.Find("Player").GetComponent<PlayerStatsController>().Health(GameObject.Find("Player").GetComponent<PlayerStatsController>().Health() - EndWorldStayHealthDecay);
        }
    }
   


    
}
