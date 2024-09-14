using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int attack_pow;
    [SerializeField] string damage_side;
    [SerializeField] float Armspeedlmit;
    private Sutetasu status;
    private float Armspeed;
    private Rigidbody RB;
    void Start()
    {
        RB = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Armspeed = RB.velocity.magnitude; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == damage_side)
        {
            Debug.Log(Armspeed);
            if(Armspeed >= Armspeedlmit)
            {
                status = collision.gameObject.GetComponent<Sutetasu>();
                if (status != null)
                {
                    status.Damage(attack_pow);
                }
            }

        }
    }

}
