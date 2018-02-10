using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour {
	// Use this for initialization
	public List<int> toppingCounts;
	public List<string> toppingNames;
	public List<int> toppingsNeeded;

	public Text nameText;
	public Text amountText;


	void Start () {
		for (int i = 0; i < toppingNames.Count; i++) {
			toppingCounts.Add (0);
			toppingsNeeded.Add (Random.Range (0, 4));
		}
	}
	
	// Update is called once per frame
	void Update () {
		nameText.text = "";
		amountText.text = "";
		for (int i = 0; i < toppingNames.Count; i++) {
			nameText.text += toppingNames [i].ToUpper() + ":\n";
			amountText.text += toppingCounts [i].ToString () + "/" + toppingsNeeded [i].ToString () + "\n";
		}
		
	}

	public void AddTopping(string ingredient){
		for (int i = 0; i < toppingNames.Count; i++) {
			if (ingredient == toppingNames [i]) {
				toppingCounts [i] += 1;
			}
		}

	}
}
