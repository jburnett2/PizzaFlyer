using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour {
	public ParticleSystem ps;
	public float toppingDeployTime = 1;
	public string topping;
	LevelController lc;
	// Use this for initialization
	void Start () {
		ps.Stop ();
		lc = GameObject.Find ("LevelController").GetComponent<LevelController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log ("ENTERED");
		StartCoroutine(DeployToppings());
	}

	IEnumerator DeployToppings(){
		ps.Play ();
		lc.AddTopping (topping);
		yield return new WaitForSeconds (toppingDeployTime);
		ps.Stop();
	}
}
