using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    int m_life = 3;
	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
            LoseLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        print("aoao " + collision.gameObject.name);
    }

    private void LoseLife() {
        m_life--;
        if (m_life == 0) {
            Destroy(this.gameObject);
        }
    }
}
