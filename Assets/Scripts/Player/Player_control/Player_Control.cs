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
           // Debug.Log("�E���w�O���b�v��������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
           // Debug.Log("���l�����w�g���K�[��������");
        }
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            Debug.Log("�����w�O���b�v��������");
            grab_Hand.GrabStart();
        }
        else if(OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            grab_Hand.GrabEnd();
        }
    }
}
