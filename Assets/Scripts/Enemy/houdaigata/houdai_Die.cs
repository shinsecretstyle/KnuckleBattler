using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houdai_Die : MonoBehaviour
{
    [SerializeField, Tooltip("�G�l�~�[�i���o�[")] int enemynumber;
    public void Die()
    {
        
        Destroy(this.gameObject);
    }
}
