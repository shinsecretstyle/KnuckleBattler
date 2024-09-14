using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
    public static GameM instance = null;
    public int[] enemykazu;
    public int[] monokazu;
    private int hp = 3;
    private GameObject Player;
    private Transform Playerpoint;

    private void Awake()//シングルトン
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlayerHP(int hitpoint)
    {
        hp = hitpoint;
    }

    public int PlayerHPPull()//プレイヤーのHPを確認したい時用
    {
        return hp;
    }
    public void PlayerGameobj(GameObject plyer)//プレイヤーのゲームオブジェクトを送り込む奴。プレイヤー以外の他のオブジェクトを入れないで欲しい
    {
        Player = plyer;
        Playerpoint = Player.GetComponent<Transform>();
    }
    public Transform PlayerPositon()//一応作ったプレイヤーの場所確認できるやつ。プレイヤーがセットされてなければnullを返す
    {
        if (Playerpoint != null)
        {
            return Playerpoint;
        }
        else
        {
            return null;
        }
        
    }
    public void Scoretuika(int enemy )//倒れた敵はここにアクセスしてキルカウントに一つ追加される。
    {
        enemykazu[enemy] += 1;
    }
    public int[] EnemyScorePull()//倒した敵のスコアを確認する為の奴。配列なので注意
    {
        return enemykazu;
    }
    
}