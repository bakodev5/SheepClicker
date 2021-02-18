using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //加算する金額
    public int value;

    //walletオブジェクト　目的地兼加算対象
    public Wallet wallet;

    //移動待ち時間
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(0.1f, 0.3f);

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime; //カウントダウン
        if (waitTime > 0) return; //waitTime0になるまでコインは動かない
        var v = wallet.transform.position - transform.position; ////現在の位置から、Walletオブジェクトまで進むベクトル生成
        transform.position += v * Time.deltaTime * 20;
        
        //近づいたら到着とみなす
        if(v.magnitude < 0.5f)
        {
            wallet.money += value;
            Destroy(gameObject);
            SoundManager.Instance.Play("コイン"); //シングルトン使って音声処理
        }
    }
}
