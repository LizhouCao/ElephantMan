using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    public M_Object[] Prefab_List;
    public float Start_Position = 12.0f;

    private Dictionary<int, GameObject> m_prefabDictionary = new Dictionary<int, GameObject>();

    private float m_distance = 0;
    public float Distance {
        get {
            return m_distance;
        }
    }

    int m_current_mapNum = 0;
    int[] m_mapID;
    float[] m_mapX;
    float[] m_mapY;
   
	// Use this for initialization
	void Start () {
        foreach (M_Object m_obj in Prefab_List) {
            m_prefabDictionary.Add(m_obj.M_ID, m_obj.gameObject);
        }

        LoadMap();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void LoadMap() {
        TextAsset mapText = Resources.Load("map0", typeof(TextAsset)) as TextAsset;

        string[] mapStrings = mapText.text.Split(new char[] { ' ', '\t', '\r', '\n' },
            System.StringSplitOptions.RemoveEmptyEntries);

        m_mapID = new int[mapStrings.Length / 3];
        m_mapX = new float[mapStrings.Length / 3];
        m_mapY = new float[mapStrings.Length / 3];

        for (int i = 0; i < mapStrings.Length; i += 3) {
            m_mapID[i / 3] = int.Parse(mapStrings[i]);
            m_mapX[i / 3] = float.Parse(mapStrings[i + 1]);
            m_mapY[i / 3] = float.Parse(mapStrings[i + 2]);
        }
    }


    private void FixedUpdate() {
        m_distance += SceneCtrl.context.Elephant.Speed;

        // check if reach next map
        while (m_current_mapNum < m_mapID.Length && m_distance > m_mapX[m_current_mapNum]) {
            CreateOne(m_mapID[m_current_mapNum]);
            m_distance -= m_mapX[m_current_mapNum];
            m_current_mapNum++;
        }
    }

    void CreateOne(int id) {
        GameObject obj = Instantiate(m_prefabDictionary[id]);
        obj.transform.position = new Vector2(12.0f, m_mapY[m_current_mapNum] - 4.0f);
    }
}
