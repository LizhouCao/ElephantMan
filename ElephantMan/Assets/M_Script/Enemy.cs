using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: M_Object{
    public int Life = 3;
    public bool HitAble = true;
    public float SelfSpeed = 0.0f;

	// Use this for initialization
	void Start () {
        	
	}

    void FixedUpdate() {
        this.transform.Translate((SceneCtrl.context.Elephant.Speed + this.SelfSpeed) * new Vector3(-1.0f, 0.0f, 0.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision) {     
        if (collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
            if (HitAble) {
                LoseLife();
            }
        }
    }

    private void LoseLife() {
        Life--;
        if (Life == 0) {
            Destroy(this.gameObject);
        }
    }
}
