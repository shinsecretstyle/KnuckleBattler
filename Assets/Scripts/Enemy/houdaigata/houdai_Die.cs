using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houdai_Die : MonoBehaviour
{
    [SerializeField] int tekinanber;
    public void Die()
    {
        GameM.instance.Scoretuika(tekinanber);
        Destroy(this.gameObject);
    }
}
