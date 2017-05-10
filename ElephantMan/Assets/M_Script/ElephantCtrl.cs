using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElephantCtrl : MonoBehaviour {

    float m_jumpForce = 500.0f;
    float m_flyForce = 200.0f;
    bool m_isGrounded = false;

    int m_life = 5;

    public Text lifeText;
    public GameObject Bullet_Prefab;
    public float Speed = 0.1f;


    float m_lastY;
    bool is_Jump = false;
    bool is_Fly = false;


    Transform m_groundCheck;

    // Use this for initialization
    void Start () {
        lifeText.text = m_life.ToString();
        m_lastY = this.transform.position.y;
        m_groundCheck = this.transform.FindChild("GroundCheck");
    }
	
	// Update is called once per frame
	void Update () {
        m_isGrounded = Physics2D.Linecast(transform.position, m_groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded) {
            is_Jump = true;
        }
        if (m_lastY > this.transform.position.y && Input.GetKeyDown(KeyCode.Space) && m_isGrounded == false) {
            is_Fly = true;
        }

        m_lastY = this.transform.position.y;

        if (Input.GetKeyDown(KeyCode.F)) {
            Fire();
        } 
	}

    private void FixedUpdate() {
        if (is_Jump) {
            this.GetComponent<Rigidbody2D>().AddForce(m_jumpForce * new Vector2(0.0f, 1.0f));
            is_Jump = false;
        }
        if (is_Fly) {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (Random.Range(0, 8) < 1)
                this.GetComponent<Rigidbody2D>().AddForce(m_flyForce * new Vector2(0.0f, 1.0f));
            is_Fly = false;
        }
    }

    void Fire() {
        GameObject obj = Instantiate(Bullet_Prefab);
        obj.transform.position = this.transform.position;
    }

    void LoseLife () {
        m_life--;
        lifeText.text = m_life.ToString();
        if (m_life == 0) {
            LoseGame();
        }
    }

    void LoseGame() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            LoseLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            LoseLife();
        }
    }
}
