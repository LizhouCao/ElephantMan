using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public GameObject[] Prefab_List;
    public GameObject Block_Prefab;
    public float Start_Position = 12.0f;

    private float m_distance = 0;
    public float Distance {
        get {
            return m_distance;
        }
    }

    int m_current_mapNum = 0;
    int[] m_map;
   
	// Use this for initialization
	void Start () {
        LoadMap();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    static int[] ParseNumberFromText(string text) {
        string[] integerStrings = text.Split(new char[] { ' ', '\t', '\r', '\n' },
            System.StringSplitOptions.RemoveEmptyEntries);
        int[] integers = new int[integerStrings.Length];

        for (int i = 0; i < integerStrings.Length; i++)
            integers[i] = int.Parse(integerStrings[i]);

        return integers;
    }


    void LoadMap() {
        TextAsset mapText = Resources.Load("map0", typeof(TextAsset)) as TextAsset;
        m_map = ParseNumberFromText(mapText.text);
    }


    private void FixedUpdate() {
        m_distance += SceneCtrl.context.Elephant.Speed;

        // check if reach next map
        while (m_current_mapNum * 3 < m_map.Length && m_distance > m_map[m_current_mapNum * 3]) {
            CreateOne(m_map[m_current_mapNum * 3 + 1]);
            m_distance -= m_map[m_current_mapNum * 3];
            m_current_mapNum++;
        }
    }

    void CreateOne(int id) {
        print(id);
        GameObject obj = Instantiate(Prefab_List[id]);
        obj.transform.position = new Vector2(12.0f, obj.transform.position.y + m_map[m_current_mapNum * 3 + 2]);
    }
}
