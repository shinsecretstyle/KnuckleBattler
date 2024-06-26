using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sutetasu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hp_max = 10;
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
            Destroy(this.gameObject);
        }
        Debug.Log("’É‚¢‚æ");
    }
}
    
    
