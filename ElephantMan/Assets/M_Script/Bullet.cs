using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float m_speed = 0.1f;
    private float m_speed_y = 0.01f;

    private float m_y;
    private int m_y_frame_total = 20;
    private int m_y_frame_current = 5;
    private Vector2 m_y_foward = new Vector2(0.0f, 1.0f);

	// Use this for initialization
	void Start () {
        m_y = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x > 11.0f)
            Destroy(this.gameObject);
    }

    void FixedUpdate() {
        if (m_y_frame_current >= m_y_frame_total) {
            m_y_frame_current = 0;
            m_y_foward = -1.0f * m_y_foward;
        }

        this.transform.Translate(m_speed * new Vector2(1.0f, 0.0f) + m_speed_y * m_y_foward);

        m_y_frame_current++;
    }
}
