using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_hand : MonoBehaviour
{
    private GameObject GrabGO;
    private Grab_suffer GOs;
    private FixedJoint Fj;
    private bool handTrigger = false;
    private bool GrabTrigger = false;
    private bool button = false;
    private void OnTriggerEnter(Collider other)
    {
        GOs = null;
        GOs = other.gameObject.GetComponent<Grab_suffer>();
        if(GOs != null)
        {
            GrabGO = null;
            GrabGO = other.gameObject;
            handTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == GrabGO)
        {
            GrabGO = null;
            handTrigger = false;
        }
    }

    public void GrabStart()
    {
        if(GrabGO != null && !GrabTrigger)
        {
            Rigidbody Rb = GrabGO.GetComponent<Rigidbody>();
            GOs.GrabStart(this.gameObject);
            Fj.connectedBody = Rb;
            GrabTrigger = true;
        }
        
    }
    public void GrabEnd()
    {
        if (GrabTrigger)
        {
            Fj.connectedBody = null;
            GOs.GrabEnd();
            GrabTrigger = false;
        }
    }
    private void Start()
    {
        Fj = this.gameObject.GetComponent<FixedJoint>();
    }
}
