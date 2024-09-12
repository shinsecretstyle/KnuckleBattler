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

    private void Awake()
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
    public void PlayerGameobj(GameObject plyer)
    {
        Player = plyer;
        Playerpoint = Player.GetComponent<Transform>();
    }
    public Transform PlayerPositon()
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
    public void Scoretuika(int eney ,int kazu)
    {
        enemykazu[eney] += kazu;
    }
    
}