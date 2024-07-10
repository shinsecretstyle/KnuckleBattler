using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taihou_daiza : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Transform housin;
    // 前方の基準となるローカル空間ベクトル
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
        // ターゲットへの向きベクトル計算
        Vector3 dir = Target.position - this.gameObject.transform.position;
        Vector3 daiza = new Vector3(dir.x * _kakudo.x, dir.y * _kakudo.y, dir.z * _kakudo.z);
        Vector3 housinkakudo = new Vector3(dir.x * housin_kakudo.x, dir.y * housin_kakudo.y, dir.z * housin_kakudo.z);
        // ターゲットの方向への回転
        Quaternion daizarotation = Quaternion.LookRotation(daiza, Vector3.up);
        Quaternion housinrotation = Quaternion.LookRotation(housinkakudo, Vector3.up);
        // 適用
        this.gameObject.transform.rotation = daizarotation;
        housin.rotation = housinrotation;
    }
}
