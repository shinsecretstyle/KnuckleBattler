using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Angles : MonoBehaviour
{
    [SerializeField] GameObject kamera;
    [SerializeField] GameObject hand;
    [SerializeField] GameObject player;
    [SerializeField] float kyori;
    [SerializeField] float hedoffset;

    private Rigidbody rb;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        if(kamera != null && hand != null)
        {
            Vector3 camerapoint = kamera.transform.position;
            Vector3 handpoint = hand.transform.position;
            Vector3 hedkaiten = player.transform.localEulerAngles - kamera.transform.localEulerAngles ;
            Vector3 handangle = hand.transform.localEulerAngles + new Vector3(0.0f, hedkaiten.y, 0.0f); 
            camerapoint.y = camerapoint.y + hedoffset;
            Vector3 c = handpoint - camerapoint;
            c = c.normalized;
            Vector3 point = handpoint + c * kyori;
            tf.localEulerAngles = handangle;
            rb.velocity = (point - tf.position) * 10;
        }
    }
}
