using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnder : MonoBehaviour {
	LevelController levelController;
	public GameObject winPanel;
	public GameObject losePanel;
	// Use this for initialization
	void Start () {
		levelController = GameObject.Find ("LevelController").GetComponent<LevelController>();
		winPanel.SetActive (false);
		losePanel.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		
		if (levelController.PerfectToppings ()) {
			winPanel.SetActive(true);
		}else{
			losePanel.SetActive(true);
		}
	}
}
