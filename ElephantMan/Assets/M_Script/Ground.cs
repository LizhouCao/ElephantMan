using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate() {
        this.transform.Translate(new Vector3(-0.1f, 0.0f, 0.0f));
    }
}
