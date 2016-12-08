using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Grade : MonoBehaviour {

	[SerializeField]
	AudioSource somRecorde;

	public GameObject obj;
	public static AudioSource Explosao;
	
	/*[SerializeField]
	AudioSource soundtrack;*/
	[SerializeField]
	Text Pontos,record;
	
	static int pontos, recorde,contador;
	//[SerializeField]
	public static int w=10;
	//[SerializeField]
	public static int h=16;

	public static Transform [,] grade = new Transform[w,h];


	// Use this for initialization
	void Start () {
		contador = 0;
		Explosao = obj.GetComponent<AudioSource> ();
		//soundtrack.Play();
		pontos = 0;
		//recorde = 0;
	}
	void FixedUpdate(){
		/*if(pontos > recorde){
			recorde=pontos;
		}*/
		if (pontos > PlayerPrefs.GetInt ("hs")) {
			PlayerPrefs.SetInt ("hs", pontos);
			somRecorde.Play ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		//record.text = "HS: " +recorde.ToString();
		//Condicao que salva o recorde mesmo após o fim do jogo
		record.text = " "+PlayerPrefs.GetInt("hs").ToString();
		//Atribuindo o valor da variavel pontos para o texto
		Pontos.text = " " + pontos.ToString();
	}

	public static Vector2 arredondarVetor(Vector2 v){
		return new Vector2 (Mathf.Round(v.x),Mathf.Round(v.y));
	}
	
	//funcao para verificar se a peca esta entre as bordas
	public static bool naBorda(Vector2 pos){
		return((int)pos.x >= 0 &&
			(int)pos.x < w &&
			(int)pos.y >= 0);
	}

	public static void deletarLinha(int y){
		for (int x = 0; x < w; x++) {
			Explosao.Play();
			pontos+=10;
			contador+=100;
			if(contador>=1000){
				Time.timeScale+=0.1f;
				contador=0;
			}
			Destroy (grade [x, y].gameObject);
			grade [x, y] = null;
		}
	}
	public static void diminuirLinha(int y){
		for (int x = 0; x < w; x++) {
			if (grade [x, y] != null) {
				grade [x, y - 1] = grade [x, y];
				grade [x, y] = null;

				grade [x, y - 1].position += new Vector3 (0, -1, 0);
			}
		}
	}

	public static void diminuirLinhaAcima(int y){
		for (int i = y; i < h; i++) {
			diminuirLinha (i);
		}
	}

	public static bool linhaTaCheia(int y){
		for (int x = 0; x < w; x++) 
			if(grade[x,y]==null)
				return false;
			return true;
	}

	public static void deletarLinhaCheia(){
		for (int y = 0; y < h; y++) {
			if(linhaTaCheia(y)){
				deletarLinha (y);
				diminuirLinhaAcima (y + 1);
				y--;
			}
		}
	}
	//funcao para retornar a variavel pontos
	public int getPontos()
	{
		return pontos;
	}
}
