using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Object: MonoBehaviour {
    public int M_ID;

    // Update is called once per frame
    protected virtual void Update() {
        if (this.transform.position.x < -20.0f)
            Destroy(this.gameObject);
    }
}
