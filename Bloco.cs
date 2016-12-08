using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bloco : MonoBehaviour {

	float ultimaQueda = 0;
	int velocidade = 0;
	GameObject objetoComScriptGrade;
	float aumento;

	// Use this for initialization
	void Start () {
		objetoComScriptGrade = GameObject.FindGameObjectWithTag("batata");
		if ( !posicaoValida ( ) ) { 
			SceneManager.LoadScene("Menu");
			Debug . Log ( "GAME OVER" ) ;
			Time.timeScale = 0;
			Destroy ( gameObject ) ; 
		} 
	}

	void FixedUpdate(){
		//Atribuindo a variavel pontos do script GRADE para a variavel velocidade para poder manipula-la mais facilmente
		velocidade = objetoComScriptGrade.GetComponent<Grade>().getPontos();
		/*if (velocidade > 1000) {
			Time.timeScale += 0.1f;
		}*/
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 0);

			if (posicaoValida())
				gradeAtualizada();
			else
				transform.position += new Vector3(1, 0, 0);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.position += new Vector3(1, 0, 0);
			if (posicaoValida())
				gradeAtualizada();
			else
				transform.position += new Vector3(-1, 0, 0);
		}

		else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, -90);

			if (posicaoValida())
				gradeAtualizada();
			else
				transform.Rotate(0, 0, 90);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)|| 
			Time . time - ultimaQueda >= 1 ) {

				if(velocidade>=1000){
					transform.position += new Vector3(0, -1/**(velocidade/500)*Time.deltaTime*30*/, 0);

					/*aumento=velocidade/10000;
					Time.timeScale+=aumento;*/
					
				}
				else
					transform.position += new Vector3(0, -1, 0);

				if (posicaoValida()) {
					gradeAtualizada();
				} 
				else {
					transform.position += new Vector3(0, 1, 0);

					Grade.deletarLinhaCheia();

					FindObjectOfType<Spawn>().SpawnarProxima();

					enabled = false;
				}
				ultimaQueda = Time.time;
			}
	}
	bool posicaoValida() {        
		foreach (Transform child in transform) {
			Vector2 v = Grade.arredondarVetor(child.position);

			//se nao estiver entre as bordas...
			if (!Grade.naBorda(v))
				return false;

			if (Grade.grade[(int)v.x, (int)v.y] != null &&
				Grade.grade[(int)v.x, (int)v.y].parent != transform)
					return false;
		}
		return true;
	}
	void gradeAtualizada() {
		//limpando antigos filhos da grade
		for (int y = 0; y < Grade.h; ++y)
			for (int x = 0; x < Grade.w; ++x)
				if (Grade.grade[x, y] != null)
					if (Grade.grade[x, y].parent == transform)
						Grade.grade[x, y] = null;
		
		//adicionando novos filhos a grade
		foreach (Transform child in transform) {
			Vector2 v = Grade.arredondarVetor(child.position);
			Grade.grade[(int)v.x, (int)v.y] = child;
		}        
	}
}
