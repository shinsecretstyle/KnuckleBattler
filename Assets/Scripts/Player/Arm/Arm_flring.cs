using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_flring : MonoBehaviour
{
    [Tooltip("˜r‚ª”ò‚ñ‚Å‚¢‚­‹——£")]
    [SerializeField] float flringdistance = 10.0f;
    [Tooltip("˜r‚ª”ò‚ñ‚Å‚¢‚­‘¬“x")]
    [SerializeField] float flringspeed = 10.0f;
    [Tooltip("‹——£•ª”ò‚ñ‚¾‚ ‚Æˆêu~‚Ü‚éŠÔ")]
    [SerializeField] float flringstop = 10.0f;

    private float distance;

    // Start is called before the first frame update
    public void FlringStart()
    {
        Vector3 forward = this.gameObject.transform.forward;
        Debug.Log(forward);
    }


}
