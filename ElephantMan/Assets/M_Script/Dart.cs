using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {
    bool m_isShooted = false;
    float m_speed = 0.1f;
    Vector2 m_forward = new Vector2(-1.0f, 0.0f);

    float m_leftX = -9.0f;
    float m_rightX;

    Boss m_Ninja;

	// Use this for initialization
	void Start () {
        m_Ninja = this.transform.parent.GetComponent<Boss>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot() {
        this.transform.SetParent(null);
        m_rightX = this.transform.position.x;
        m_isShooted = true;
    }

    void BackToNinja() {
        m_isShooted = false;
        m_forward = new Vector2(-1.0f, 0.0f);
        m_Ninja.DartBack();
    }

    void U_Turn() {
        m_forward = new Vector2(1.0f, 0.0f);
    }

    private void FixedUpdate() {
        if (m_isShooted == true) {
            this.transform.Translate(m_speed * m_forward);
            if (m_forward.x > 0.0f && this.transform.position.x > m_rightX) {
                BackToNinja();
            }
            else if (m_forward.x < 0.0f && this.transform.position.x < m_leftX) {
                U_Turn();
            }
        }
    }
}
