using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawn : MonoBehaviour {
	[SerializeField] int proxPeca;
	//Vetor de Pecas
	[SerializeField]GameObject[] pecas;
	
	[SerializeField]List<GameObject>mostrarPecas;

	// Use this for initialization
	void Start () {
		proxPeca = Random.Range (0, pecas.Length);
		//peca inicial do jogo
		SpawnarProxima();
	}
	
	
	public void SpawnarProxima(){
		//Randomizando a peca
		//int i=Random.Range(0,pecas.Length);
		
		//Spawnar peca na posicao atual
		Instantiate(pecas[proxPeca],transform.position,Quaternion.identity);
		proxPeca = Random.Range (0, pecas.Length);
		for (int i = 0; i < mostrarPecas.Count; i++) {
			mostrarPecas [i].SetActive (false);
		}
		mostrarPecas [proxPeca].SetActive (true);
	}
}
