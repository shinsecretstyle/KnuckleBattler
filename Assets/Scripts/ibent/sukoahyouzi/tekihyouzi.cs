using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tekihyouzi : MonoBehaviour
{
    [SerializeField] Sprite[] tekusurya;
    [SerializeField] int killsuu;
    SpriteRenderer MainSpriteRenderer;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    void Datein(int nanber,int kazu)
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
}
