using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDESERT : MonoBehaviour
{
    #region basic property
    private int basicStrength = 10;
    private int basicIntellect = 10;
    private int basicAgility = 10;
    private int basicStamina = 10;
    private int basicDamage = 10;

    public int BasicStrength { get { return basicStrength; } }
    public int BasicIntellect { get { return basicIntellect; } }
    public int BasicAgility { get { return basicAgility; } }
    public int BasicStamina { get { return basicStamina; } }
    public int BasicDamage { get { return basicDamage; } }
    #endregion

    private int coinAmount = 100;
    private Text coinText;

    public int CoinAmount
    {
        get { return coinAmount; }
        set
        {
            coinAmount = value;
            if (coinText != null)
            {
                coinText.text = coinAmount.ToString();
            }
        }
    }

    // 👉 控制当前添加的物品ID
    private int currentItemId = 11;
    private const int maxItemId = 14; // 可根据你总物品数调整

    void Start()
    {
        GameObject coinObj = GameObject.Find("Coin");
        if (coinObj != null)
        {
            coinText = coinObj.GetComponentInChildren<Text>();
            if (coinText != null)
            {
                coinText.text = coinAmount.ToString();
            }
        }
    }

    void Update()
    {
        // G键：按顺序添加物品（非随机）
        if (Input.GetKeyDown(KeyCode.G))
        {
            Knapsack.Instance.StoreItem(currentItemId);
            currentItemId++;
            if (currentItemId > maxItemId)
            {
                currentItemId = 11; // 循环重来
            }
        }

        // T键：显示/隐藏背包
        if (Input.GetKeyDown(KeyCode.T))
        {
            Knapsack.Instance.DisplaySwitch();
        }

        // O键：锻造界面显示/隐藏
        if (Input.GetKeyDown(KeyCode.O))
        {
            Forge.Instance.DisplaySwitch();
        }

        // 下面这些界面功能如果不用可以注释掉或删除
        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Chest.Instance.DisplaySwitch();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            CharacterPanel.Instance.DisplaySwitch();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Vendor.Instance.DisplaySwitch();
        }
        */
    }

    // 扣金币
    public bool ConsumeCoin(int amount)
    {
        if (coinAmount >= amount)
        {
            coinAmount -= amount;
            if (coinText != null)
            {
                coinText.text = coinAmount.ToString();
            }
            return true;
        }
        return false;
    }

    // 加金币
    public void EarnCoin(int amount)
    {
        coinAmount += amount;
        if (coinText != null)
        {
            coinText.text = coinAmount.ToString();
        }
    }
}