using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_action : MonoBehaviour
{
    [SerializeField] GameObject kamera;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject player;
    [SerializeField] float kyori;
    [SerializeField] float hedoffset;
    [SerializeField] float pow = 1.0f;
    [SerializeField] float Shottime = 2.0f;
    [SerializeField] Arm_flring flring;

    private Rigidbody rb;
    private Rigidbody PCc;
    private Transform tf;
    private Vector3 camerapoint;
    private Vector3 handpoint;
    private Vector3 handmokuhyoupoint;
    private Vector3 ShotAngle;
    private Vector3 point;

    private bool Shotf = false;//腕が飛ぶときにON
    private bool Ankar = false;//腕が地面等に接着してる時にON
    private float timecount = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PCc = player.GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kamera != null && hand != null)
        {
            camerapoint = kamera.transform.position;
            handpoint = hand.transform.position;

            
            if (Shotf)
            {
               point = Arm_Trshot();
            }
            else
            {
               point = Arm_move();
            }
            Vector3 angle = Arm_angles();

            rb.velocity =point;
            tf.localEulerAngles = angle;
            
            if (false)
            {
                PCc.AddForce(point * -1);
            }
            
            
        }
    }

    private Vector3 Arm_move()
    {     
            camerapoint.y = camerapoint.y + hedoffset;
            Vector3 c = handpoint - camerapoint;
            c = c.normalized;
            Vector3 nextpoint = handpoint + c * kyori;         
            handmokuhyoupoint = (nextpoint - tf.position) * 10;
            return handmokuhyoupoint;
    }

    private Vector3 Arm_angles()
    {
           Vector3 hedkaiten = player.transform.localEulerAngles - kamera.transform.localEulerAngles;
           Vector3 handangle = hand.transform.localEulerAngles + new Vector3(0.0f, hedkaiten.y, 0.0f);
        //return handangle;

        return hand.transform.eulerAngles;
    }

    private Vector3 Arm_Trshot()
    {
        Vector3 vekutoru = tf.forward - ShotAngle;
        vekutoru = vekutoru * pow;
        return vekutoru;
    }
    
    public void Arm_Shot()
    {
        if (!Shotf)
        {
            Shotf = true;
            ShotAngle = tf.forward;
            timecount = 0.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        var Tag = collision.gameObject.tag;
        if(Tag != "Player")
        {
            Ankar = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Ankar = false;
    }
    public Vector3 Handekutoru()
    {
        return point;
    }
}
