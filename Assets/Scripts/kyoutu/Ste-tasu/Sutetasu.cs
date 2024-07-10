using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sutetasu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hp_max = 10;
    public UnityEvent OnDeath;
    int hp = 0;

    void Start()
    {
        hp = hp_max;
    }

    public void Damage( int damage)
    {
        
        hp = hp - damage;
        if(hp <= 0)
        {
            hp = 0;
            OnDeath.Invoke();
        }
        
    }
}
    
    
