using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public static ShopManager Instance;

    public Text ClickValue_Text;
    public Text AutoClick_Text;
    public Text AutoClickValue_Text;
    public Text DoubleGold_Text;

    public Text ClickValue_Cost_Text;
    public Text AutoClick_Cost_Text;
    public Text AutoClickValue_Cost_Text;
    public Text DoubleGold_Cost_Text;

    public string ClickValue;
    public string AutoClick;
    public string AutoClickValue;
    public string DoubleGold;

    public int ClickValue_Cost;
    public int AutoClick_Cost;
    public int AutoClickValue_Cost;
    public int DoubleGold_Cost;

    private int multiplier;
    private Player player;

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
        player = FindObjectOfType<Player>();
        multiplier = 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ClickValue_Text.text = ClickValue;
        AutoClick_Text.text = AutoClick;
        AutoClickValue_Text.text = AutoClickValue;
        DoubleGold_Text.text = DoubleGold;
                                                                                        // Mettere il refresh delle scritte al comprare del corrispondente oggetto.
        ClickValue_Cost_Text.text = ClickValue_Cost.ToString();
        AutoClick_Cost_Text.text = AutoClick_Cost.ToString();
        AutoClickValue_Cost_Text.text = AutoClickValue_Cost.ToString();
        DoubleGold_Cost_Text.text = DoubleGold_Cost.ToString();
    }

    public void ClickValueShop()
    {
        if (player.Gold >= ClickValue_Cost)
        {
            ClickerManager.Instance.ClickValue += 1;
            player.SpendGold(ClickValue_Cost);
            ClickValue_Cost *= multiplier;
            ClickValue = "ClickValue: " + (ClickerManager.Instance.ClickValue + 1);
        }

    }

    public void AutoClickShop()
    {
        if (player.Gold >= AutoClick_Cost)
        {
            ClickerManager.Instance.AutoClickerDivider += 1;
            ClickerManager.Instance.SetAutoClickCheckPoint();
            player.SpendGold(AutoClick_Cost);
            AutoClick_Cost *= multiplier;
            AutoClick = "AutoClick: " + (ClickerManager.Instance.AutoClickerDivider + 1);
        }
    }

    public void AutoClickValueShop()
    {
        if (player.Gold >= AutoClickValue_Cost)
        {
            ClickerManager.Instance.AutoClickValue += 1;
            player.SpendGold(AutoClickValue_Cost);
            AutoClickValue_Cost *= multiplier;
            AutoClickValue = "AutoClickValue: " + (ClickerManager.Instance.AutoClickValue + 1);
        }
    }

    public void DoubleGoldShop()
    {
        if (player.Gold >= DoubleGold_Cost)
        {
            player.GoldMultiplier += 1;
            player.SpendGold(DoubleGold_Cost);
            DoubleGold_Cost *= multiplier;
            DoubleGold = "DoubleGold: x" + (player.GoldMultiplier + 1);
        }
    }
}