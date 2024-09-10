using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sutetasu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hp_max = 10;
    [SerializeField] float mutekizikan = 0.5f;
    [SerializeField] bool Playermode = false;
    public UnityEvent OnDeath;
    int hp = 0;
    private bool damegi = false;
    private float timecount = 0.0f;

    void Start()
    {
        hp = hp_max;
        if (Playermode)
        {
            HPgmgo(hp);   
        }
    }
    private void Update()
    {
        if (damegi)
        {
            timecount += Time.deltaTime;
            if(timecount >= mutekizikan)
            {
                damegi = false;
            }
        }
    }

    public void Damage( int damage)
    {
        if (!damegi)
        {
            hp = hp - damage;
            if (Playermode)
            {
                HPgmgo(hp);
            }
            if (hp <= 0)
            {
                hp = 0;
                OnDeath.Invoke();
            }
            damegi = true;
        }
        
        
    }
    public void HPgmgo(int hp)
    {
        GameM.instance.PlayerHP(hp);
    }
    
    public int HPCeak()
    {
        return hp;
    }
}


   



    
