using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_suffer : MonoBehaviour
{
   
    [SerializeField,Tooltip("�͂܂�ĐU��񂳂ꂽ���̍U����")] int GrabAttackPower = 0;
    [SerializeField] GameObject tuibisaki;
    private float AttackSpeedLimit = 1f;
    private float AttackThrownSpeedLimit = 2f;

    private bool Grab_Trigger = false;       //�߂܂�Ă��邩�̔��f
    private bool Atack_Trigger = false; //�U�����肪�������Ă��邩�̔��f
    private bool thrown_Tracking = false; //�ǔ����肪�������Ă��邩�̔��f
    private bool Grab_thrown = false;        //�������Ă��邩�̔��f�B������false�ɂȂ��Ă悤�₭��A�̗��ꂪ�I������
    private float thrwn_speed = 0.0f;
    private GameObject hand;//����擾
    private GameObject taget_ob;//�ǔ�����I�u�W�F�N�g
    private Transform handTf;//��̃g�����X�t�H�[�����擾
    private Rigidbody handRB;//��̃��W�b�g�{�f�B���擾
    private Grab_hand handcs;//���Grab_hand�ւ̃A�N�Z�X���擾
    private Rigidbody myRB;//�����̃��W�b�g�{�f�B���擾
    private Transform myTf;//�����̃g�����X�t�H�[�����擾
    private Vector3 speed=Vector3.zero;//���g�̃X�s�[�h���擾
    public void GrabStart(GameObject Grab_hand)//�߂܂ꂽ�ۂɍŏ��ɍs����
    {
        
        hand = Grab_hand;
        handTf = hand.GetComponent<Transform>();
        handRB = hand.GetComponent<Rigidbody>();
        handcs = hand.GetComponent<Grab_hand>();
        Grab_Trigger = true;
        
    }
    public void GrabEnd(Vector3 bekutoru)//�����ꂽ�ۂɍs����
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

    public void GrabEndTaget(GameObject enemy)//�ǔ��Ώۂ��������ۂɂ����ɃI�u�W�F�N�g���o���܂�
    {
        taget_ob = enemy;
    }
    public bool GrabCeak()//���I�u�W�F�N�g�̑��̃X�N���v�g���玝����Ă��邩�`�F�b�N�����
    {
        return Grab_Trigger;//true�������玝���Ă��
    }
    public bool GrabAtackCeak()//���̃X�N���v�g����A�^�b�N����ɂȂ��Ă��邩�`�F�b�N�����
    {
        return Atack_Trigger;
    }
    public bool ThrownCeak()//���̃X�N���v�g���瓊����΂���Ă��邩�`�F�b�N�����
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
        if (thrown_Tracking)//�ǔ����[�h���I���ɂȂ��Ă�����ǔ�����
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
