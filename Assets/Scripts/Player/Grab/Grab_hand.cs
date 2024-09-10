using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_hand : MonoBehaviour
{
    [SerializeField] Arm_action Arm;
   // [SerializeField] GameObject hantei;
    private GameObject GrabGO;
    private Hominghantei Homics;
    private Grab_suffer GOs;
    private FixedJoint Fj;
    private Vector3 bekutoru;
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
            bekutoru = Arm.Handekutoru();
            Fj.connectedBody = null;
            /*
            GameObject taget = Homics.Itibantikaiyaru();
            if(taget != null)
            {
                GOs.GrabEndTaget(taget);
            }
            */
            GOs.GrabEnd(bekutoru);
            GrabTrigger = false;
        }
    }
    private void Start()
    {
        Fj = this.gameObject.GetComponent<FixedJoint>();
        //Homics = hantei.GetComponent<Hominghantei>();
    }
    private void FixedUpdate()
    {
        /*
        bekutoru = Arm.Handekutoru();
        Vector3 kakudo = bekutoru.normalized;
        hantei.transform.eulerAngles = kakudo;
        */
    }
    public GameObject GrabG()
    {
        return GrabGO;//äÓñ{ìIÇ…ãÛÇæÇ©ÇÁíçà”
    }
    public bool GrabGnullceak()
    {
        bool nullkana=false;
        if(GrabGO == null)
        {
            nullkana = false;
        }
        else
        {
            nullkana = true;
        }
        return nullkana;
    }
}
