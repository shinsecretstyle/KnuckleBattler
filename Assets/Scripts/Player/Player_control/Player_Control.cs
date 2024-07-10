using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [SerializeField]private GameObject Grabhand;
    private Grab_hand grab_Hand;
    // Start is called before the first frame update
    void Start()
    {
        grab_Hand = Grabhand.GetComponent<Grab_hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
           // Debug.Log("Aボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
           // Debug.Log("Bボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
           // Debug.Log("Xボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
           // Debug.Log("Yボタンを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
           // Debug.Log("左手メニューボタンを押した（オン・オフ不安定なので注意）");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
           // Debug.Log("右人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
           // Debug.Log("右中指グリップを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
           // Debug.Log("左人差し指トリガーを押した");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("左中指グリップを押した");
            grab_Hand.GrabStart();
        }
        else if(OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            grab_Hand.GrabEnd();
        }
    }
}
