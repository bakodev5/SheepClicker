using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class DebugSaveData : ISaveData
{
    public void SaveMoney(BigInteger money)
    {
    }

    public void SaveSheepCnt(int id, int cnt)
    {
    }

    public BigInteger LoadMoney()
    {
        return 10000000000; //デバッグ用に大金
    }

    public int LoadSheepCnt(int id)
    {
        return 5; //デバッグ用に最初から全羊が５匹居る
    }
}
