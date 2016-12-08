using UnityEngine;
using System.Collections;

public class SomTeste : MonoBehaviour {

	[SerializeField]
	AudioSource roda;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			roda.Play ();
		}
	
	}
}
