using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour {

    public Transform[] Target;
    public bool isSwimming = false;
    public float fish_speed = 5.0f;
    private Transform newTarget;


  

    

	
	void Update () {

        if (isSwimming == false)
        {
            newTarget = Target[Random.Range(0, Target.Length)];
            isSwimming = true;
        }

       
        transform.position = Vector3.MoveTowards(transform.position, newTarget.position, fish_speed * Time.deltaTime);
        transform.LookAt(newTarget);
        

        if (transform.position == newTarget.position)
        {
            isSwimming = false;
        }
    }
}
