using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_suffer : MonoBehaviour
{
   
    [SerializeField,Tooltip("掴まれて振り回された時の攻撃力")] int GrabAttackPower = 0;
    [SerializeField] GameObject tuibisaki;
    private float AttackSpeedLimit = 1f;
    private float AttackThrownSpeedLimit = 2f;

    private bool Grab_Trigger = false;       //捕まれているかの判断
    private bool Atack_Trigger = false; //攻撃判定が発生しているかの判断
    private bool thrown_Tracking = false; //追尾判定が発生しているかの判断
    private bool Grab_thrown = false;        //投げられているかの判断。ここがfalseになってようやく一連の流れが終了する
    private float thrwn_speed = 0.0f;
    private GameObject hand;//手を取得
    private GameObject taget_ob;//追尾するオブジェクト
    private Transform handTf;//手のトランスフォームを取得
    private Rigidbody handRB;//手のリジットボディを取得
    private Grab_hand handcs;//手のGrab_handへのアクセスを取得
    private Rigidbody myRB;//自分のリジットボディを取得
    private Transform myTf;//自分のトランスフォームを取得
    private Vector3 speed=Vector3.zero;//自身のスピードを取得
    public void GrabStart(GameObject Grab_hand)//捕まれた際に最初に行う事
    {
        
        hand = Grab_hand;
        handTf = hand.GetComponent<Transform>();
        handRB = hand.GetComponent<Rigidbody>();
        handcs = hand.GetComponent<Grab_hand>();
        Grab_Trigger = true;
        
    }
    public void GrabEnd(Vector3 bekutoru)//離された際に行う事
    {
        Grab_Trigger = false;
        Grab_thrown = true;
        hand = null;
        handTf = null;
        myRB.velocity = bekutoru;
        thrwn_speed = myRB.velocity.magnitude;
        if (taget_ob != null)
        {
            thrown_Tracking = true;
        }
        else
        {
            thrown_Tracking = false;
        }
        
    }

    public void GrabEndTaget(GameObject enemy)//追尾対象があった際にここにオブジェクトを出します
    {
        taget_ob = enemy;
    }
    public bool GrabCeak()//同オブジェクトの他のスクリプトから持たれているかチェックするよ
    {
        return Grab_Trigger;//trueだったら持ってるよ
    }
    public bool GrabAtackCeak()//他のスクリプトからアタック判定になっているかチェックするよ
    {
        return Atack_Trigger;
    }
    public bool ThrownCeak()//他のスクリプトから投げ飛ばされているかチェックするよ
    {
        return Grab_thrown;
    }

    private void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody>();
        myTf = this.gameObject.GetComponent<Transform>();
        if(tuibisaki != null)
        {
            taget_ob = tuibisaki;
        }
    }
    private void FixedUpdate()
    {
        if (Grab_Trigger)
        {
            if(myRB.velocity.magnitude >= AttackSpeedLimit)
            {
                Atack_Trigger = true;
            }
            else
            {
                Atack_Trigger = false;
            }
        }
        if (thrown_Tracking)//追尾モードがオンになっていたら追尾する
        {
            Vector3 mokutekiti = taget_ob.transform.position - myTf.position;
            mokutekiti = mokutekiti.normalized * thrwn_speed;
            myRB.velocity = mokutekiti;
            if (!Atack_Trigger)
            {
                Atack_Trigger = true;
            }
        }
        if (Grab_thrown)
        {
            
            if(myRB.velocity.magnitude <= AttackThrownSpeedLimit)
            {
                Grab_thrown = false;
                thrown_Tracking = false;
                Atack_Trigger = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (Grab_Trigger)
        {
            
            if( Atack_Trigger && collision.gameObject.tag != "Player")
            {
                Sutetasu status = collision.gameObject.GetComponent<Sutetasu>();
                
                if ( status != null)
                {
                    status.Damage(GrabAttackPower);
                    
                }
            }

        }
        else if (Grab_thrown)
        {
            if(myRB.velocity.magnitude >= AttackThrownSpeedLimit && collision.gameObject.tag != "Player")
            {
                Sutetasu status = collision.gameObject.GetComponent<Sutetasu>();
                
                if (status != null)
                {
                    status.Damage(GrabAttackPower);
                }
            }
            
            if (thrown_Tracking)
            {
                thrown_Tracking = false;
                //taget_ob = null;
            }

        }
    }

}
