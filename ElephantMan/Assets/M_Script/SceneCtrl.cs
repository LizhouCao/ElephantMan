using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    public static SceneCtrl context;
    public ElephantCtrl Elephant;

    // Use this for initialization
    private void Awake() {
        context = this;
        if (Elephant == null) {
            Elephant = GameObject.Find("Elephant").GetComponent<ElephantCtrl>();
        }
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
