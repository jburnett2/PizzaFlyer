using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour {
	// Use this for initialization
	public List<int> toppingCounts;
	public List<string> toppingNames;
	public List<int> toppingsNeeded;
    public SpriteRenderer[] sprites;
	public Text nameText;
	public Text amountText;
	public Text titleText;

	void Start () {
		for (int i = 0; i < toppingNames.Count; i++) {
			toppingCounts.Add (0);
			toppingsNeeded.Add (Random.Range (0, 4));
		}

		Cursor.visible = false;
        
        
	}
	
	// Update is called once per frame
	void Update () {
		nameText.text = "";
		amountText.text = "";
		for (int i = 0; i < toppingNames.Count; i++) {
			nameText.text += toppingNames [i].ToUpper() + ":\n";
			amountText.text += toppingCounts [i].ToString () + "/" + toppingsNeeded [i].ToString () + "\n";
		}

		if (Input.GetAxisRaw ("Jump") != 0) {
			nameText.color = Color.white;
			amountText.color = Color.white;
			titleText.color = Color.white;
		} else {
			nameText.color = Color.clear;
			amountText.color = Color.clear;
			titleText.color = Color.clear;
		}
		
	}

	public void AddTopping(string ingredient){
		for (int i = 0; i < toppingNames.Count; i++) {
			if (ingredient == toppingNames [i]) {
				toppingCounts [i] += 1;
                sprites[i].enabled = true;
            }
		}


	}

	public bool PerfectToppings(){
		for(int i = 0; i<toppingCounts.Count; i++){
			if (toppingCounts [i] != toppingsNeeded [i]) {
				return false;
			}
		}
		return true;
	}
}
