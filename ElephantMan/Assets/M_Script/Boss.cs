using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    float m_speed = 0.02f;
    public int Life;
    private bool HitAble = false;
    private float m_startPosition_X = 5.0f;

    private Dart m_dart;
    private float m_dart_localY;

    float m_min_position_time = 0.2f;
    float m_max_position_time = 1.0f;

    float m_min_shoot_time = 2.0f;
    float m_max_shoot_time = 3.0f;

    // Use this for initialization
    void Start () {
        m_dart = this.transform.FindChild("Dart").GetComponent<Dart>();
        m_dart_localY = m_dart.transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        // move into scene
        if (this.transform.position.x > m_startPosition_X) {
            this.transform.Translate(m_speed * new Vector2(-1.0f, 0.0f));
        }

        // boss start
        else if (HitAble == false)
            BossFightStart();
    }

    void BossFightStart() {
        HitAble = true;
        Invoke("ChangePosition", Random.Range(m_min_position_time, m_max_position_time));
        Invoke("ShootDart", Random.Range(m_min_shoot_time, m_max_shoot_time));
    }

    void ChangePosition() {
        this.transform.position = new Vector2(this.transform.position.x, Random.Range(-3.0f, 2.0f));
        Invoke("ChangePosition", Random.Range(m_min_position_time, m_max_position_time));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            Destroy(collision.gameObject);
            if (HitAble) {
                LoseLife();
            }
        }
    }

    void ShootDart() {
        m_dart.Shoot();
    }

    public void DartBack() {
        m_dart.transform.SetParent(this.transform);
        m_dart.transform.localPosition = new Vector2(m_dart.transform.localPosition.x, m_dart_localY);
        Invoke("ShootDart", Random.Range(m_min_shoot_time, m_max_shoot_time));
    }

    private void LoseLife() {
        Life--;
        if (Life == 0) {
            Destroy(m_dart.gameObject);
            SceneCtrl.context.BossDie();
            Destroy(this.gameObject);
        }
    }
}
