using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    float endPosition = -20.0f;
    float startPosition = 20.0f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate() {
        this.transform.Translate(SceneCtrl.context.Elephant.Speed * new Vector3(-1.0f, 0.0f, 0.0f));

        if (this.transform.position.x < endPosition)
            this.transform.position = new Vector2(this.transform.position.x - endPosition + startPosition, this.transform.position.y);
    }
}
