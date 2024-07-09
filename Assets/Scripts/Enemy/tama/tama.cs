using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tama : MonoBehaviour
{
    [SerializeField] int attack_pow;
    [SerializeField] string damage_side;
    private Sutetasu status;
    private Rigidbody RB;
    // Start is called before the first frame update
    private Rigidbody shell;
    [SerializeField] float speed = 500.0f;
    [SerializeField] float ltime = 5.0f;
    void Start()
    {
        shell = this.gameObject.GetComponent<Rigidbody>();
        shell.AddForce(transform.forward * speed);
        Destroy(this.gameObject, ltime);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damage_side)
        {
            
            
                status = other.gameObject.GetComponent<Sutetasu>();
                if (status != null)
                {
                    status.Damage(attack_pow);
                }
            

        }
    }
}
