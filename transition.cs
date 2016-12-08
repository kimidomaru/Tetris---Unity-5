using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene("t");
		}
	
	}
}
