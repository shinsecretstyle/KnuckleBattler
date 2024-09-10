using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houdaigata : MonoBehaviour
{
    private EnemyState enemyState = EnemyState.出現;
    private EnemyState stockenemyState = EnemyState.待機;//初期処理で使うやーつ
    private Rigidbody rb;
    private float timecount = 0.0f;
    #region 待機で使うやつ
    [Header("待機状態で使う変数")]
    
    [SerializeField, Tooltip("移動倍率 発見でも使用する")] private float moveMultiplier = 3.0f;
    
    [SerializeField,Tooltip("移動速度 発見でも使用する")] private float power = 5.0f;
    
    [SerializeField,Tooltip("回転速度 発見でも使用する")] private float sokudo = 1.0f;
    private Vector3 originpositon;
    
    [SerializeField, Tooltip("出現してから移動する移動半径")] private float hankei = 6.0f;
    
    [SerializeField,Tooltip("設定した目的地（散歩する際にランダムに設定した目的地）に対して許す誤差")] private float mokutekitihankei = 0.5f;
    private Vector3 nextpositon;
    
    
    [SerializeField,Tooltip("長い間移動し続けると諦めて別の場所へ移動しようとさせる為の時間")] private float timelmit;
    
    [SerializeField,Tooltip("目的地到着後滞在し続ける時間")] private float taikitimelimit;
    private bool basyo = false;// 目的地を設定しているかどうかのフラグ
    private Quaternion kakudoizi;
    #endregion
    #region 発見で使うやつ
    [Header("発見する際に使う変数")]
    [SerializeField, Tooltip("プレイヤーを入れて欲しい！")] private GameObject playerG;
    private GameObject child;
    private Transform playerT;
    private float playerkyori;
    [SerializeField, Tooltip("どのくらいの距離で発見するか")] private float sakutekikyori = 6.0f;
    [SerializeField, Tooltip("どのくらいの距離で見失うか")] private float sakutekisippai = 10.0f;
    [SerializeField, Tooltip("どのくらいの距離移動したら諦めるか")] private float sakutekiakirame = 15.0f;
    [SerializeField, Tooltip("どのくらいの距離を保つか")] private float kyorihozi = 4.0f;
    private bool kyorihoziflg = false;
    [SerializeField, Tooltip("どのくらいの時間で辿り着かなかったら撃つか")] private float timelimithakken = 5.0f;
    private Vector3 kyorihozipositon;
    #endregion
    #region 攻撃で使うやつ
    [Header("攻撃する際に使う変数")]
    [SerializeField, Tooltip("攻撃開始までの時間")] private float Timetoattack = 1.5f;
    [SerializeField, Tooltip("攻撃してから終了までの時間")] private float Timetoattackend = 2.0f;
    [SerializeField, Tooltip("打ち出す弾をいれてね")] private GameObject bullet;
    [SerializeField, Tooltip("弾を出現させるオブジェクト")] private GameObject bulletpoint;
    private Transform bulletpointT;
    private bool hassya = false;
    private Quaternion kougekihozi;
    private Quaternion kougekikakudohozi;
    private Vector3 basyoizi;
    #endregion
    #region ノックバックで使うやつ
    [Header("ノックバックに使う変数")]
    [SerializeField, Tooltip("捕まれスクリプトを置いてね")] private Grab_suffer Grabceak;
    [SerializeField, Tooltip("ステータスを置いてね")] private Sutetasu sutetasu;
    private int hp = 0;
    private int hpstock = 0;
    private bool Grabon = false;
    private bool knockback = false;
    [SerializeField, Tooltip("この速度以下で解除")] private float lmitofspeed = 2.0f;
    [SerializeField, Tooltip("この時間たったら解除")] private float lmitoftime = 3.0f;
    #endregion
    public enum EnemyState
    {
        出現,
        待機,
        発見,
        攻撃,
        ノックダウン,
        死亡,
    }
    // Start is called before the first frame update
    public void ChangeState(EnemyState s)
    {
        enemyState = s;
    }
    void OnChangeState(EnemyState s)//各状態の初期処理を行うよ
    {
        switch (s)
        {
            #region 出現
            case EnemyState.出現:
               // Debug.Log("砲台型状態　出現");
                originpositon = this.transform.position;
                rb = this.GetComponent<Rigidbody>();
                child = playerG.transform.Find("OVRPlayerController").gameObject;
               // Debug.Log("砲台型状態　出現　" + child.name);
                playerT = child.GetComponent<Transform>();
                Random.InitState(System.DateTime.Now.Millisecond);
                bulletpointT = bulletpoint.GetComponent<Transform>();
                hp = sutetasu.HPCeak();
                hpstock = hp;
                Grabon = false;
                break;
            #endregion
            #region 待機
            case EnemyState.待機:
                //Debug.Log("砲台型状態　待機");
                basyo = false;
                nextpositon = Vector3.zero;
                timecount = 0.0f;
                playerkyori = 999.0f;
                break;
            #endregion
            #region 発見
            case EnemyState.発見:
                //Debug.Log("砲台型状態　発見");
                kyorihozipositon = Vector3.zero;
                kyorihoziflg = false;
                timecount = 0.0f;
                break;
            #endregion
            #region 攻撃
            case EnemyState.攻撃:
                timecount = 0.0f;
                kougekikakudohozi = Quaternion.Euler(this.transform.eulerAngles);
                rb.constraints = RigidbodyConstraints.None;
                basyoizi = this.transform.position;
                hassya = false;
                break;
            #endregion
            #region ノックダウン
            case EnemyState.ノックダウン:
                rb.constraints = RigidbodyConstraints.None;
                timecount = 0.0f;
                knockback = true;
                break;
            #endregion
            #region 死亡
            case EnemyState.死亡:

                break;
　　　　　　#endregion
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
            ChangeState(EnemyState.ノックダウン);
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
            #region 出現
            case EnemyState.出現:
                ChangeState(EnemyState.待機);
                break;
            #endregion
            #region 待機
            case EnemyState.待機:
                playerkyori = (playerT.position - this.gameObject.transform.position).magnitude;
                if(playerkyori <= sakutekikyori)
                {
                    ChangeState(EnemyState.発見);
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
                   // Debug.Log("砲台型　場所設定" + nextpositon);
                }//目的地の設定
                Vector3 muki = nextpositon - this.transform.position;
                float kyori =  Mathf.Abs(muki.magnitude);
                timecount += Time.deltaTime;
                if ((kyori <= mokutekitihankei || timecount >= timelmit )&& basyo)
                {
                    //Debug.Log("砲台型　到着" + kyori +","+ mokutekitihankei + "," +kakudoizi);
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
                    //Debug.Log("砲台型　移動");
                }
                break;
            #endregion
            #region 発見
            case EnemyState.発見:
                playerkyori = (playerT.position - this.gameObject.transform.position).magnitude;
                if (playerkyori <= sakutekisippai && !kyorihoziflg)
                {
                   Vector3 bekutoru = this.transform.position - playerT.position;
                   bekutoru = bekutoru.normalized;
                   Vector3 bekutorusecond = bekutoru * kyorihozi;
                   kyorihozipositon = bekutorusecond + playerT.position;
                   kyorihoziflg = true;
                   //Debug.Log("砲台型　発見目標設定");
                }//撃つ場所を決める
                else if(playerkyori >= sakutekisippai || (originpositon - this.transform.position).magnitude >= sakutekiakirame )
                {
                    ChangeState(EnemyState.待機);
                    break;
                }
                Vector3 kyorimuki = kyorihozipositon - this.transform.position;
                float hozikyori = Mathf.Abs(kyorimuki.magnitude);
                timecount += Time.deltaTime;
                if ((hozikyori <= mokutekitihankei || timecount >=timelimithakken) && kyorihoziflg)
                {
                    //Debug.Log("砲台型　発見到着" + hozikyori + "" + mokutekitihankei);
                    rotation = kakudoizi;
                    idou = Vector3.zero;
                    ChangeState(EnemyState.攻撃);
                    break;
                }//移動したら攻撃
                else
                {
                    Vector3 mokuhyoumuki = new Vector3(kyorimuki.x, 0.0f, kyorimuki.z); 
                    rotation = Quaternion.LookRotation(mokuhyoumuki, Vector3.up);
                    kakudoizi = rotation;
                    idou = transform.forward * power;
                    //Debug.Log("砲台型　発見移動");
                }//撃つ場所へ移動する
                break;
            #endregion
            #region 攻撃
            case EnemyState.攻撃:
                
                if(timecount <= Timetoattack && !hassya)
                {
                    rb.constraints = RigidbodyConstraints.None;
                    Vector3 mokuhyou = playerT.position - this.transform.position;

                    rotation = Quaternion.LookRotation(mokuhyou, Vector3.up);
                    kougekihozi = rotation;

                }
                else if(!hassya)
                {
                    //Debug.Log("砲台型　攻撃！");
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
                        ChangeState(EnemyState.発見);
                        //ChangeState(EnemyState.ノックダウン);テスト用
                        break;
                    }
                }
                idou = basyoizi - this.transform.position;
                timecount += Time.deltaTime;

                break;
            #endregion
            #region ノックダウン
            case EnemyState.ノックダウン:
                if (!Grabon && rb.velocity.magnitude <= lmitofspeed && timecount >= lmitoftime)
                {
                    rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                    rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                    knockback = false;
                    ChangeState(EnemyState.待機);
                }
                timecount = timecount + Time.deltaTime;
                break;
            #endregion
            #region 死亡
            case EnemyState.死亡:
                //死亡処理は大抵ステータスの方で済ませちゃってるので省略。爆弾型が爆発する時だけ使うと思う
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
