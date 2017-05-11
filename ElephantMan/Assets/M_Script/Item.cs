using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (this.transform.position.x < -15.0f)
            Destroy(this.gameObject);
    }

    void FixedUpdate() {
        this.transform.Translate(SceneCtrl.context.Elephant.Speed * new Vector3(-1.0f, 0.0f, 0.0f));
    }

    // What happen after Eated by Elephant, called by ElephantCtrl. 
    public void Eated() {
        SceneCtrl.context.Elephant.GainScore();
        Destroy(this.gameObject);
    }
}
