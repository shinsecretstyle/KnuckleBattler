using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int attack_pow;
    [SerializeField] string damage_side;
    private Sutetasu status;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == damage_side)
        {
            status = collision.gameObject.GetComponent<Sutetasu>();
            if(status != null)
            {
                status.Damage(attack_pow);
            }
        }
    }

}
