using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamautudake : MonoBehaviour
{
    [SerializeField] float attacktime = 1.0f;
    [SerializeField] Transform hassyapoint;
    [SerializeField] GameObject tama;
    private bool attacktriger = false;
    private float timecount = 0.0f;
    public void active()
    {
        attacktriger = true;
        timecount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacktriger)
        {
            Attack();
        }
    }
    void Attack()
    {
        timecount += Time.deltaTime;
        if(timecount - attacktime >= 0)
        {
            timecount = 0.0f;
            Quaternion q = Quaternion.Euler( hassyapoint.eulerAngles);
            Instantiate(tama, hassyapoint.position,q);
        }
    }
    public void Baibai()
    {
        attacktriger = false;
    }
}
