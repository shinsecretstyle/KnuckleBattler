using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcollsion : MonoBehaviour
{
    [SerializeField] GameObject hand;
    private Transform mytf;
    private Rigidbody myRg;
    private Transform handpoint;
    // Start is called before the first frame update
    void Start()
    {
        mytf = GetComponent<Transform>();
        myRg = GetComponent<Rigidbody>();
        handpoint = hand.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector3 mokuteki = handpoint.position - mytf.position;
        myRg.velocity = mokuteki*10;

    }
}
