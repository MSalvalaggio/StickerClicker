using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public static TimeManager Instance;

    public Text Timer;

    public float StartingTimer;
    public float LevelTimer;
    public bool IsGameNotPaused;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        LevelTimer = StartingTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsGameNotPaused)
        {
            LevelTimer -= Time.deltaTime;
            Timer.text = LevelTimer.ToString();
        }
	}

    public void ResetTimer()
    {
        LevelTimer = StartingTimer;
    }

    public void ChangeTimerBool()
    {
        if (IsGameNotPaused)
        {
            IsGameNotPaused = false;
        }
        else
        {
            IsGameNotPaused = true;
        }
    }
}
