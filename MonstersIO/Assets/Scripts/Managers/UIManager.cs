using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text coinTxt;
    public TMP_Text diamondTxt;

    public void UpdateCoin()
    {
        coinTxt.text = GameSavings.Coin.ToString();
    }

    public void UpdateDiamond()
    {
        diamondTxt.text = GameSavings.Diamond.ToString();
    }
}
