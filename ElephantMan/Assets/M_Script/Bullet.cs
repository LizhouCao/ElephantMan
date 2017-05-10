using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float m_speed = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x > 11.0f)
            Destroy(this.gameObject);
    }

    void FixedUpdate() {
        this.transform.Translate(m_speed * new Vector3(1.0f, 0.0f, 0.0f));
    }
}
