using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SheepData : ScriptableObject
{
    //羊の色
    public Color color;

    //初期値段
    public int basePrice;

    //値段上昇額
    public int extendPrice;

    //購入上限数
    public int maxCount;

    //羊毛の量
    public int woolCnt;

}
