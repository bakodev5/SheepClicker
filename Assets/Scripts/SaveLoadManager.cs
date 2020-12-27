using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    //保存対象の1所持金用
    [SerializeField] private Wallet wallet;

    //保存対象の2羊の頭数用
    [SerializeField] Shop shop;

    //セーブロードインターフェース
    private ISaveData saveData;

    private void Awake()
    {
        saveData = new PlayerPrefsSaveData();
        //saveData = new DebugSaveData(); //todo デバッグ用
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        Debug.Log("セーブ");
        //所持金を保存
        saveData.SaveMoney(wallet.money);
        //全ての羊の頭数を保存しておく
        for (var index = 0; index < shop.sheepButtonList.Count; index++)
        {
            var sheepButton = shop.sheepButtonList[index];
            saveData.SaveSheepCnt(index, sheepButton.currentCnt);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ロード");

        //所持金をロード
        wallet.money = saveData.LoadMoney();
        //全ての羊の頭数をロードする
        for(var index = 0; index < shop.sheepButtonList.Count; index++)
        {
            var sheepButton = shop.sheepButtonList[index];
            var sheepCnt = saveData.LoadSheepCnt(index);
            sheepButton.currentCnt = sheepCnt;
            for(var i = 0; i < sheepCnt; i++)
            {
                sheepButton.sheepGenerator.CreateSheep(sheepButton.sheepData);
            }
        }
    }

}
