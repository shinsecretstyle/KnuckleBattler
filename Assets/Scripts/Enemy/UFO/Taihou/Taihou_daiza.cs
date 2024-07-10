using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taihou_daiza : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Transform housin;
    // �O���̊�ƂȂ郍�[�J����ԃx�N�g��
    //[SerializeField] private Vector3 _forward = Vector3.forward;
    [SerializeField] private Vector3 _kakudo = new Vector3(1.0f, 1.0f, 1.0f);
    [SerializeField] private Vector3 housin_kakudo = new Vector3(1.0f, 1.0f, 1.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �^�[�Q�b�g�ւ̌����x�N�g���v�Z
        Vector3 dir = Target.position - this.gameObject.transform.position;
        Vector3 daiza = new Vector3(dir.x * _kakudo.x, dir.y * _kakudo.y, dir.z * _kakudo.z);
        Vector3 housinkakudo = new Vector3(dir.x * housin_kakudo.x, dir.y * housin_kakudo.y, dir.z * housin_kakudo.z);
        // �^�[�Q�b�g�̕����ւ̉�]
        Quaternion daizarotation = Quaternion.LookRotation(daiza, Vector3.up);
        Quaternion housinrotation = Quaternion.LookRotation(housinkakudo, Vector3.up);
        // �K�p
        this.gameObject.transform.rotation = daizarotation;
        housin.rotation = housinrotation;
    }
}
