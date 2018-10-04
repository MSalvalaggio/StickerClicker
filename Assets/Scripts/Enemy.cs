using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private int startingHealth = 10;

    public int Health;
    public int EnemiesKilled;

    public Text EnemyHealth;
    public Text EnemiesDied;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health <= 0)
        {
            RespawnStrongerEnemy();
        }
        if (TimeManager.Instance.LevelTimer <= 0)
        {
            ResetEnemyAndTimer();
        }
        EnemyHealth.text = Health.ToString();
        EnemiesDied.text = EnemiesKilled.ToString();
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
    }

    public void RespawnStrongerEnemy()
    {
        float tempHealth = startingHealth;
        tempHealth *= 1.2f;
        startingHealth = (int)tempHealth;
        Health = startingHealth;
        EnemiesKilled++;
        TimeManager.Instance.ResetTimer();
    }

    public void ResetEnemyAndTimer()
    {
        Health = startingHealth;
        TimeManager.Instance.ResetTimer();
    }
}
