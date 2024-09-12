using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houdai_Die : MonoBehaviour
{
    [SerializeField, Tooltip("エネミーナンバー")] int enemynumber;
    public void Die()
    {
        
        Destroy(this.gameObject);
    }
}
