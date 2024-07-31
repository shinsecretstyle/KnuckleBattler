using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    [SerializeField]private GameObject LeftGrabhand;
    [SerializeField] private GameObject RightGrabhand;
    private Grab_hand leftgrab_Hand;
    private Grab_hand rightgrab_Hand;
    // Start is called before the first frame update
    void Start()
    {
        leftgrab_Hand = LeftGrabhand.GetComponent<Grab_hand>();
        rightgrab_Hand = RightGrabhand.GetComponent<Grab_hand>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
           // Debug.Log("A�{�^����������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
           // Debug.Log("B�{�^����������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
           // Debug.Log("X�{�^����������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
           // Debug.Log("Y�{�^����������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
           // Debug.Log("���胁�j���[�{�^�����������i�I���E�I�t�s����Ȃ̂Œ��Ӂj");
        }

        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
           // Debug.Log("�E�l�����w�g���K�[��������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
        {
            rightgrab_Hand.GrabStart();
        }else if (OVRInput.GetUp(OVRInput.RawButton.RHandTrigger))
        {
            rightgrab_Hand.GrabEnd();
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            
            
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger))
        {
            
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("�����w�O���b�v��������");
            leftgrab_Hand.GrabStart();
        }
        else if(OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            leftgrab_Hand.GrabEnd();
        }

    }
}
