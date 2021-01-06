using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_kari : MonoBehaviour
{

    public static SoundManager_kari instance;
    //シングルトン
    //ゲーム内に一つしか存在しない物（音を管理する）
    //利用場所:シーン間でのデータ共有/オブジェクト共有
    //書き方
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject); //同じオブジェクトが既にあったら遷移後のシーンで破壊する
        }
    }
    //--シングルトン終わり

    [SerializeField] AudioClip[] SE;
    public AudioSource audioSourceSE;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void getCoinSE()
    {
        audioSourceSE.PlayOneShot(SE[0]);
    }

    public void shavingSE()
    {
        audioSourceSE.PlayOneShot(SE[1]);
    }

    public void createSheepSE()
    {
        audioSourceSE.PlayOneShot(SE[2]);
    }
}
