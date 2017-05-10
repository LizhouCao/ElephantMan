using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public GameObject[] Prefab_List;
    public GameObject Block_Prefab;
    public float Start_Position = 12.0f;
   
	// Use this for initialization
	void Start () {
        Invoke("CreateOne", 3.0f);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void CreateOne() {
        int num = Random.Range(0, Prefab_List.Length);
        GameObject obj = Instantiate(Prefab_List[num]);
        obj.transform.position = new Vector2(12.0f, obj.transform.position.y);

        Invoke("CreateOne", 3.0f);
    }
}
