using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text Golds;

    public int Gold;
    public int GoldMultiplier;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Golds.text = Gold.ToString();
	}

    public void GainGold(int goldToAdd)
    {
        Gold += goldToAdd * GoldMultiplier;
    }

    public void SpendGold(int goldToSub)
    {
        Gold -= goldToSub;
    }
}
