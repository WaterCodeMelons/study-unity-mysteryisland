using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTree : MonoBehaviour {

    public float GrowingSpeed;
    public float MaxScale;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.x < MaxScale)
        {
            transform.localScale += Vector3.one * Time.deltaTime * GrowingSpeed;
        }

    }
}
