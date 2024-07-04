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
    [SerializeField] Arm_flring flring;

    private Rigidbody rb;
    private Rigidbody Prb;
    private Transform tf;
    private Vector3 camerapoint;
    private Vector3 handpoint;
    private Vector3 handmokuhyoupoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Prb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kamera != null && hand != null)
        {
            camerapoint = kamera.transform.position;
            handpoint = hand.transform.position;
            Vector3 point = Arm_move();
            Vector3 angle = Arm_angles();
            rb.velocity = point;
            tf.localEulerAngles = angle;
            if (flring != null)
            {
                flring.FlringStart();
            }
        }
    }

    public Vector3 Arm_move()
    {     
            camerapoint.y = camerapoint.y + hedoffset;
            Vector3 c = handpoint - camerapoint;
            c = c.normalized;
            Vector3 point = handpoint + c * kyori;
            handmokuhyoupoint = (point - tf.position) * 10;
            return handmokuhyoupoint;
    }

    public Vector3 Arm_angles()
    {
           Vector3 hedkaiten = player.transform.localEulerAngles - kamera.transform.localEulerAngles;
           Vector3 handangle = hand.transform.localEulerAngles + new Vector3(0.0f, hedkaiten.y, 0.0f);
           return handangle;
    }

    public Vector3 Arm_Trshot()
    {

        return new Vector3(0,0,0);
    }
    
}
