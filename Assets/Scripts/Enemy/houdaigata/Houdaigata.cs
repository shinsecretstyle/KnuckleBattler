using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houdaigata : MonoBehaviour
{
    private EnemyState enemyState = EnemyState.�o��;
    private EnemyState stockenemyState = EnemyState.�ҋ@;//���������Ŏg����[��
    private Rigidbody rb;
    private float timecount = 0.0f;
    #region �ҋ@�Ŏg�����
    [Header("�ҋ@��ԂŎg���ϐ�")]
    
    [SerializeField, Tooltip("�ړ��{�� �����ł��g�p����")] private float moveMultiplier = 3.0f;
    
    [SerializeField,Tooltip("�ړ����x �����ł��g�p����")] private float power = 5.0f;
    
    [SerializeField,Tooltip("��]���x �����ł��g�p����")] private float sokudo = 1.0f;
    private Vector3 originpositon;
    
    [SerializeField, Tooltip("�o�����Ă���ړ�����ړ����a")] private float hankei = 6.0f;
    
    [SerializeField,Tooltip("�ݒ肵���ړI�n�i�U������ۂɃ����_���ɐݒ肵���ړI�n�j�ɑ΂��ċ����덷")] private float mokutekitihankei = 0.5f;
    private Vector3 nextpositon;
    
    
    [SerializeField,Tooltip("�����Ԉړ���������ƒ��߂ĕʂ̏ꏊ�ֈړ����悤�Ƃ�����ׂ̎���")] private float timelmit;
    
    [SerializeField,Tooltip("�ړI�n������؍݂������鎞��")] private float taikitimelimit;
    private bool basyo = false;// �ړI�n��ݒ肵�Ă��邩�ǂ����̃t���O
    private Quaternion kakudoizi;
    #endregion
    #region �����Ŏg�����
    [Header("��������ۂɎg���ϐ�")]
    [SerializeField, Tooltip("�v���C���[�����ė~�����I")] private GameObject playerG;
    private GameObject child;
    private Transform playerT;
    private float playerkyori;
    [SerializeField, Tooltip("�ǂ̂��炢�̋����Ŕ������邩")] private float sakutekikyori = 6.0f;
    [SerializeField, Tooltip("�ǂ̂��炢�̋����Ō�������")] private float sakutekisippai = 10.0f;
    [SerializeField, Tooltip("�ǂ̂��炢�̋����ړ���������߂邩")] private float sakutekiakirame = 15.0f;
    [SerializeField, Tooltip("�ǂ̂��炢�̋�����ۂ�")] private float kyorihozi = 4.0f;
    private bool kyorihoziflg = false;
    [SerializeField, Tooltip("�ǂ̂��炢�̎��ԂŒH�蒅���Ȃ������猂��")] private float timelimithakken = 5.0f;
    private Vector3 kyorihozipositon;
    #endregion
    #region �U���Ŏg�����
    [Header("�U������ۂɎg���ϐ�")]
    [SerializeField, Tooltip("�U���J�n�܂ł̎���")] private float Timetoattack = 1.5f;
    [SerializeField, Tooltip("�U�����Ă���I���܂ł̎���")] private float Timetoattackend = 2.0f;
    [SerializeField, Tooltip("�ł��o���e������Ă�")] private GameObject bullet;
    [SerializeField, Tooltip("�e���o��������I�u�W�F�N�g")] private GameObject bulletpoint;
    private Transform bulletpointT;
    private bool hassya = false;
    private Quaternion kougekihozi;
    private Quaternion kougekikakudohozi;
    private Vector3 basyoizi;
    #endregion
    #region �m�b�N�o�b�N�Ŏg�����
    [Header("�m�b�N�o�b�N�Ɏg���ϐ�")]
    [SerializeField, Tooltip("�߂܂�X�N���v�g��u���Ă�")] private Grab_suffer Grabceak;
    [SerializeField, Tooltip("�X�e�[�^�X��u���Ă�")] private Sutetasu sutetasu;
    private int hp = 0;
    private int hpstock = 0;
    private bool Grabon = false;
    private bool knockback = false;
    [SerializeField, Tooltip("���̑��x�ȉ��ŉ���")] private float lmitofspeed = 2.0f;
    [SerializeField, Tooltip("���̎��Ԃ����������")] private float lmitoftime = 3.0f;
    #endregion
    public enum EnemyState
    {
        �o��,
        �ҋ@,
        ����,
        �U��,
        �m�b�N�_�E��,
        ���S,
    }
    // Start is called before the first frame update
    public void ChangeState(EnemyState s)
    {
        enemyState = s;
    }
    void OnChangeState(EnemyState s)//�e��Ԃ̏����������s����
    {
        switch (s)
        {
            #region �o��
            case EnemyState.�o��:
               // Debug.Log("�C��^��ԁ@�o��");
                originpositon = this.transform.position;
                rb = this.GetComponent<Rigidbody>();
                child = playerG.transform.Find("OVRPlayerController").gameObject;
               // Debug.Log("�C��^��ԁ@�o���@" + child.name);
                playerT = child.GetComponent<Transform>();
                Random.InitState(System.DateTime.Now.Millisecond);
                bulletpointT = bulletpoint.GetComponent<Transform>();
                hp = sutetasu.HPCeak();
                hpstock = hp;
                Grabon = false;
                break;
            #endregion
            #region �ҋ@
            case EnemyState.�ҋ@:
                //Debug.Log("�C��^��ԁ@�ҋ@");
                basyo = false;
                nextpositon = Vector3.zero;
                timecount = 0.0f;
                playerkyori = 999.0f;
                break;
            #endregion
            #region ����
            case EnemyState.����:
                //Debug.Log("�C��^��ԁ@����");
                kyorihozipositon = Vector3.zero;
                kyorihoziflg = false;
                timecount = 0.0f;
                break;
            #endregion
            #region �U��
            case EnemyState.�U��:
                timecount = 0.0f;
                kougekikakudohozi = Quaternion.Euler(this.transform.eulerAngles);
                rb.constraints = RigidbodyConstraints.None;
                basyoizi = this.transform.position;
                hassya = false;
                break;
            #endregion
            #region �m�b�N�_�E��
            case EnemyState.�m�b�N�_�E��:
                rb.constraints = RigidbodyConstraints.None;
                timecount = 0.0f;
                knockback = true;
                break;
            #endregion
            #region ���S
            case EnemyState.���S:

                break;
�@�@�@�@�@�@#endregion
        }
        stockenemyState = s;
    }
    void FixedUpdate()
    {
        Quaternion rotation = Quaternion.identity;
        Vector3 idou = new Vector3(0.0f, 0.0f, 0.0f);
        playerkyori = 0.0f;
        
        Grabon = Grabceak.GrabCeak();
        if (Grabon && !knockback)
        {
            ChangeState(EnemyState.�m�b�N�_�E��);
        } else if (hp != hpstock)
        {
            hpstock = hp;
        }
            
        if(enemyState != stockenemyState)
        {
            OnChangeState(enemyState);
        }
        switch (enemyState)
        {
            #region �o��
            case EnemyState.�o��:
                ChangeState(EnemyState.�ҋ@);
                break;
            #endregion
            #region �ҋ@
            case EnemyState.�ҋ@:
                playerkyori = (playerT.position - this.gameObject.transform.position).magnitude;
                if(playerkyori <= sakutekikyori)
                {
                    ChangeState(EnemyState.����);
                    break;
                }
                if (!basyo)
                {
                    float distans = Random.Range(0.0f, hankei);
                    float x = Random.Range(-1.0f, 1.0f);
                    float z = Random.Range(-1.0f, 1.0f);
                    Vector3 bekutoru = new Vector3(x, 0.0f, z);
                    bekutoru = bekutoru * distans;
                    nextpositon = bekutoru + originpositon;
                    basyo = true;
                    timecount = 0.0f;
                   // Debug.Log("�C��^�@�ꏊ�ݒ�" + nextpositon);
                }//�ړI�n�̐ݒ�
                Vector3 muki = nextpositon - this.transform.position;
                float kyori =  Mathf.Abs(muki.magnitude);
                timecount += Time.deltaTime;
                if ((kyori <= mokutekitihankei || timecount >= timelmit )&& basyo)
                {
                    //Debug.Log("�C��^�@����" + kyori +","+ mokutekitihankei + "," +kakudoizi);
                    rotation = kakudoizi;
                    idou = Vector3.zero;
                    if(basyo && timecount >= timelmit + taikitimelimit)
                    {
                        basyo = false;
                    }
                }
                else
                {
                    
                    Vector3 mokuhyoumuki = new Vector3(muki.x, 0.0f, muki.z); ;
                    rotation = Quaternion.LookRotation(mokuhyoumuki, Vector3.up);
                    kakudoizi = rotation;
                    idou = transform.forward * power;
                    //Debug.Log("�C��^�@�ړ�");
                }
                break;
            #endregion
            #region ����
            case EnemyState.����:
                playerkyori = (playerT.position - this.gameObject.transform.position).magnitude;
                if (playerkyori <= sakutekisippai && !kyorihoziflg)
                {
                   Vector3 bekutoru = this.transform.position - playerT.position;
                   bekutoru = bekutoru.normalized;
                   Vector3 bekutorusecond = bekutoru * kyorihozi;
                   kyorihozipositon = bekutorusecond + playerT.position;
                   kyorihoziflg = true;
                   //Debug.Log("�C��^�@�����ڕW�ݒ�");
                }//���ꏊ�����߂�
                else if(playerkyori >= sakutekisippai || (originpositon - this.transform.position).magnitude >= sakutekiakirame )
                {
                    ChangeState(EnemyState.�ҋ@);
                    break;
                }
                Vector3 kyorimuki = kyorihozipositon - this.transform.position;
                float hozikyori = Mathf.Abs(kyorimuki.magnitude);
                timecount += Time.deltaTime;
                if ((hozikyori <= mokutekitihankei || timecount >=timelimithakken) && kyorihoziflg)
                {
                    //Debug.Log("�C��^�@��������" + hozikyori + "" + mokutekitihankei);
                    rotation = kakudoizi;
                    idou = Vector3.zero;
                    ChangeState(EnemyState.�U��);
                    break;
                }//�ړ�������U��
                else
                {
                    Vector3 mokuhyoumuki = new Vector3(kyorimuki.x, 0.0f, kyorimuki.z); 
                    rotation = Quaternion.LookRotation(mokuhyoumuki, Vector3.up);
                    kakudoizi = rotation;
                    idou = transform.forward * power;
                    //Debug.Log("�C��^�@�����ړ�");
                }//���ꏊ�ֈړ�����
                break;
            #endregion
            #region �U��
            case EnemyState.�U��:
                
                if(timecount <= Timetoattack && !hassya)
                {
                    rb.constraints = RigidbodyConstraints.None;
                    Vector3 mokuhyou = playerT.position - this.transform.position;

                    rotation = Quaternion.LookRotation(mokuhyou, Vector3.up);
                    kougekihozi = rotation;

                }
                else if(!hassya)
                {
                    //Debug.Log("�C��^�@�U���I");
                    rotation = kougekihozi;
                    Quaternion q = Quaternion.Euler(bulletpointT.eulerAngles);
                    Instantiate(bullet, bulletpointT.position, q);
                    hassya = true;
                    timecount = 0.0f;

                }
                else if(hassya)
                {
                    rotation = kougekihozi;
                    if(timecount >= Timetoattackend)
                    {
                        rotation = kougekikakudohozi;
                        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                        ChangeState(EnemyState.����);
                        //ChangeState(EnemyState.�m�b�N�_�E��);�e�X�g�p
                        break;
                    }
                }
                idou = basyoizi - this.transform.position;
                timecount += Time.deltaTime;

                break;
            #endregion
            #region �m�b�N�_�E��
            case EnemyState.�m�b�N�_�E��:
                if (!Grabon && rb.velocity.magnitude <= lmitofspeed && timecount >= lmitoftime)
                {
                    rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    knockback = false;
                    ChangeState(EnemyState.�ҋ@);
                }
                timecount = timecount + Time.deltaTime;
                break;
            #endregion
            #region ���S
            case EnemyState.���S:
                //���S�����͑��X�e�[�^�X�̕��ōς܂�������Ă�̂ŏȗ��B���e�^���������鎞�����g���Ǝv��
                break;
            #endregion
        }
        hp = sutetasu.HPCeak();
        
        //rb.AddForce(new Vector3(0.0f,0.0f,speed), ForceMode.VelocityChange);
        if (!knockback)
        {
            rb.AddForce(moveMultiplier * (idou - rb.velocity));
            this.gameObject.transform.rotation = rotation;
        }
        
    }
    
}
