using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    [SerializeField] private Button sellButton;
    [SerializeField] private Wallet wallet;
    // Start is called before the first frame update
    void Start()
    {
        sellButton.onClick.AddListener(SellAllWool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SellAllWool()
    {
        var wools = FindObjectsOfType<Wool>(); //画面上の全てのWoolスクリプトが付いたオブジェクトを検索してWool配列woolsに入れる
        foreach(var wool in wools)
        {
            Destroy(wool.gameObject);
            wallet.money += 100; //TODO本当は羊毛ごとに金額を変えたい
        }

    }
}
