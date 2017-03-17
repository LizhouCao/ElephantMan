using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public GameObject Block_Prefab;
   
	// Use this for initialization
	void Start () {
        Invoke("CreateOne", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void CreateOne() {
        Instantiate(Block_Prefab);
        Invoke("CreateOne", 3.0f);
    }
}
