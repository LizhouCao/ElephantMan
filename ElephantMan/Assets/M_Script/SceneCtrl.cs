using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void BossDie() {
        Invoke("Win", 2.0f);
    }

    public void ElephantDie() {
        Invoke("Lose", 2.0f);
    }

    void Win() {
        SceneManager.LoadScene("Win");
    }

    void Lose() {
        SceneManager.LoadScene("Lose");
    }
}
