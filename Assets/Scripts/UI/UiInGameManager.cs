using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.core.Singleton;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoin(string s) { 
        Instance.uiTextCoins.text = s;
    }
}
