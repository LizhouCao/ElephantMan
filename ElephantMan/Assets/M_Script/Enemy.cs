using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int Life = 3;
    public bool HitAble = true;

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < -15.0f)
            Destroy(this.gameObject);
	}

    void FixedUpdate() {
        this.transform.Translate(SceneCtrl.context.Elephant.Speed * new Vector3(-1.0f, 0.0f, 0.0f));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (HitAble) {
            if (collision.gameObject.tag == "Bullet") {
                Destroy(collision.gameObject);
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
