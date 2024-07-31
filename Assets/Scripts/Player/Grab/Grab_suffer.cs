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
    public void GrabStart(GameObject Grab_hand)//�߂܂ꂽ�ۂɍŏ��ɍs����
    {
        
        hand = Grab_hand;
        handTf = hand.GetComponent<Transform>();
        handRB = hand.GetComponent<Rigidbody>();
        handcs = hand.GetComponent<Grab_hand>();
        Grab_Trigger = true;

    }
    public void GrabEnd()//�����ꂽ�ۂɍs����
    {
        Grab_Trigger = false;
        hand = null;
        handTf = null;
    }

    public bool GrabCeak()//���I�u�W�F�N�g�̑��̃X�N���v�g���玝����Ă��邩�`�F�b�N�����
    {
        return Grab_Trigger;
    }
    public bool GrabAtackCeak()//���̃X�N���v�g����A�^�b�N����ɂȂ��Ă��邩�`�F�b�N�����
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
            //�͂܂ꂽ�ۂɃA�^�b�N���[�h�ɂȂ�
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
