using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	[SerializeField]
	AudioSource opMenu;
	void Update(){
		if(Input.GetKeyDown(KeyCode.Return)){
			opMenu.Play();
			SceneManager.LoadScene("t");
		}
	}
				
}
