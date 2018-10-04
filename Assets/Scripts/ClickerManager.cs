using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour {

    public static ClickerManager Instance;

    public int ClickValue;
    public int AutoClickValue;

    public float AutoClickTimer;
    public float AutoClickCheckPoint;
    public int AutoClickerDivider;

    private Player player;
    private Enemy enemy;
    private Touch[] myTouches;

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

    void Start () {
        player = FindObjectOfType<Player>();
        enemy = FindObjectOfType<Enemy>();
    }
                                                                                                                 
	void Update () {                                                                                             
                                                                                                                 
        myTouches = Input.touches;

        if (TimeManager.Instance.IsGameNotPaused)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (myTouches[i].phase == TouchPhase.Began)
                {
                    ClickActions();
                }
            }

            if (AutoClickerDivider > 0)
            {
                AutoClickTimer += Time.deltaTime;
            }

            if (AutoClickTimer >= AutoClickCheckPoint)
            {
                AutoClickActions();
                AutoClickTimer = 0f;
            }
        }
    }

    public void ClickActions()
    {
        enemy.TakeDamage(ClickValue);
        player.GainGold(ClickValue);
    }

    public void AutoClickActions()
    {
        enemy.TakeDamage(AutoClickValue);
        player.GainGold(AutoClickValue);
    }

    public void SetAutoClickCheckPoint()
    {
        AutoClickCheckPoint = 1f / AutoClickerDivider;
    }
}