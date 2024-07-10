using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_suffer : MonoBehaviour
{
    private bool Grab_Trigger = false;
    private GameObject hand;
    private Transform handTf;
    private Rigidbody myRB;
    private Transform myTf;
    private Vector3 speed=Vector3.zero;
    public void GrabStart(GameObject Grab_hand)//�߂܂ꂽ�ۂɍŏ��ɍs����
    {
        
        hand = Grab_hand;
        handTf = hand.GetComponent<Transform>();
        Grab_Trigger = true;

    }
    public void GrabEnd()//�����ꂽ�ۂɍs����
    {
        Grab_Trigger = false;
        myRB.AddForce(speed, ForceMode.Impulse);
        speed = Vector3.zero;
        hand = null;
        handTf = null;
    }

    public bool GrabCeak()//���I�u�W�F�N�g�̑��̃X�N���v�g���玝����Ă��邩�`�F�b�N�����
    {
        return Grab_Trigger;
    }

    private void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody>();
        myTf = this.gameObject.GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if (Grab_Trigger)
        {
            speed = myRB.velocity;
        }
    }

}
