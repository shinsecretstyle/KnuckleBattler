using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tekinerau : MonoBehaviour
{
    [SerializeField] tamautudake tamautudake;
    private void Start()
    {
        tamautudake.active();
    }
}
