using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text Golds;

    public int Gold;
    public int GoldMultiplier;

    private Animator Player_Anim;

    // Use this for initialization
    void Start () {
        Player_Anim = GetComponentInChildren<Animator>();
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

    public void AttackAnimation001()
    {
        Player_Anim.Play("Player_Attack_001");
    }
}
