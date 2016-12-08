using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	float posicaoX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.position+= new Vector3(1,0,0);
			posicaoX = transform.position.x;
			if(posicaoX>=7){
				transform.position+= new Vector3(-1,0,0);
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.position+= new Vector3(-1,0,0);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			transform.position+= new Vector3(0,-1,0);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			transform.Rotate (0,0,90);
		}

	
	}
}
