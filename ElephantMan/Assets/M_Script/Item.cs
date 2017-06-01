using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : M_Object {
    void FixedUpdate() {
        this.transform.Translate(SceneCtrl.context.Elephant.Speed * new Vector3(-1.0f, 0.0f, 0.0f));
    }

    // What happen after Eated by Elephant, called by ElephantCtrl. 
    public void Eated() {
        SceneCtrl.context.Elephant.GainScore();
        Destroy(this.gameObject);
    }
}
