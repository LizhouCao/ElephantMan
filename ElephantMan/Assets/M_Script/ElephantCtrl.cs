using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElephantCtrl : MonoBehaviour {

    float m_jumpForce = 500.0f;
    float m_flyForce = 60.0f;
    bool m_isGrounded = false;

    int m_life = 5;

    public Text lifeText;

    public GameObject Bullet_Prefab;

	// Use this for initialization
	void Start () {
        lifeText.text = m_life.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space) && m_isGrounded) {
            this.GetComponent<Rigidbody2D>().AddForce(m_jumpForce * new Vector2(0.0f, 1.0f));
            m_isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.F)) {
            Fire();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded == false) {
            this.GetComponent<Rigidbody2D>().AddForce(m_flyForce * new Vector2(0.0f, 1.0f));
        }
        */
	}

    void Fire() {
        GameObject obj = Instantiate(Bullet_Prefab);
        obj.transform.position = this.transform.position;
    }

    void LoseLife () {
        m_life--;
        lifeText.text = m_life.ToString();
        if (m_life == 0) {
            Lose();
        }
    }

    void Lose() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            m_isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            m_isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            LoseLife();
        }
    }
}
