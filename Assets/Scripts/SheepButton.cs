﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheepButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    public SheepData sheepData;

    public SheepGenerator sheepGenerator;


    //羊画像
    [SerializeField]
    private Image sheepImage;

    //金額Text
    [SerializeField]
    private Text priceText;

    //頭数Text
    [SerializeField]
    private Text countText;

    //販売可否Text
    [SerializeField]
    private Text infoText;

    //所持金オブジェクト
    public Wallet wallet;

    //現在の頭数
    public int currentCnt;
    //現在の羊の金額を返却

    private SaveLoadManager saveLoadManager ; //羊購入時のデータ保存処理
    public int GetPrice()
    {
        return sheepData.basePrice + sheepData.extendPrice * currentCnt; //現在の頭数から、次の購入金額を計算
    }

    public void CreateSheep()
    {
        var price = GetPrice(); //現在の頭数から次の購入金額を計算
        wallet.money -= price; //購入分所持金から引く
        currentCnt++; //現在の頭数+1
        sheepGenerator.CreateSheep(sheepData); //羊を生成
        saveLoadManager.Save();
        SoundManager.Instance.Play("メ～"); //シングルトンで簡易音声処理
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(CreateSheep);
        saveLoadManager = GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var price = GetPrice(); //現在の頭数から次の購入金額を計算

        sheepImage.color = sheepData.color; //羊の色をセット
        priceText.text = price.ToString("C0"); //金額表示なので"C0"を指定
        countText.text = $"{currentCnt}頭/{sheepData.maxCount}頭"; //現在の頭数と上限表示

        if(currentCnt >= sheepData.maxCount) //購入上限かどうか
        {
            infoText.text = "完売";
            button.interactable = false; //ボタン無効
        }
        else if(wallet.money >= price) //所持金が上
        {
            infoText.text = "購入";
            button.interactable = true; //ボタン有効
        }
        else //所持金が足りない
        {
            infoText.text = "お金が足りません";
            button.interactable = false; //ボタン無効
        }
    }
}