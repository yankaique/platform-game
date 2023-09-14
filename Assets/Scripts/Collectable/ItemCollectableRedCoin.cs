using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableRedCoin : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(10);
    }
}
