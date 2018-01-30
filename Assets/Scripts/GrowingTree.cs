using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingTree : MonoBehaviour {

    public float daysToFullGrowth;
    private float scale;
    private bool growing = false;

    void Start () {
        scale = transform.localScale.x;
    }
	
	void Update () {
        if (growing) {
            scale += Time.deltaTime / (TimeController.minutesInAFullDayDisplay * 60) / daysToFullGrowth;
            scale = Mathf.Clamp01(scale);
            transform.localScale = new Vector3(scale, scale, scale);
        }

        if (Input.GetKey(KeyCode.Mouse0))
            growing = true;

        if (scale == 1)
            transform.tag = "resource";
        
    }
}
