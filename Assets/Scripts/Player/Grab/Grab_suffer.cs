using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_suffer : MonoBehaviour
{
    [SerializeField] int Grab_Atack_pow = 0;
    [SerializeField] float Atack_pow_speedlmit = 0.0f;

    private bool Grab_Trigger = false;
    private bool Grab_Atack_Trigger = false;
    private GameObject hand;
    private Transform handTf;
    private Rigidbody handRB;
    private Grab_hand handcs;
    private Rigidbody myRB;
    private Transform myTf;
    private Vector3 speed=Vector3.zero;
    public void GrabStart(GameObject Grab_hand)//捕まれた際に最初に行う事
    {
        
        hand = Grab_hand;
        handTf = hand.GetComponent<Transform>();
        handRB = hand.GetComponent<Rigidbody>();
        handcs = hand.GetComponent<Grab_hand>();
        Grab_Trigger = true;

    }
    public void GrabEnd()//離された際に行う事
    {
        Grab_Trigger = false;
        hand = null;
        handTf = null;
    }

    public bool GrabCeak()//同オブジェクトの他のスクリプトから持たれているかチェックするよ
    {
        return Grab_Trigger;
    }
    public bool GrabAtackCeak()//他のスクリプトからアタック判定になっているかチェックするよ
    {
        return Grab_Atack_Trigger;
    }

    private void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody>();
        myTf = this.gameObject.GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Grab_Trigger)
        {
            //掴まれた際にアタックモードになる
            if(myRB.velocity.magnitude >= Atack_pow_speedlmit && collision.gameObject.tag != "Player")
            {
                Sutetasu status = collision.gameObject.GetComponent<Sutetasu>();
                Grab_Atack_Trigger = true;
                if ( status != null)
                {
                    status.Damage(Grab_Atack_pow);
                }
            }
            else
            {
                Grab_Atack_Trigger = false;
            }
        }
    }

}
