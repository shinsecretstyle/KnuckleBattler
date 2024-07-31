using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move_Control : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float movespeedlmit = 0.0f;
    [SerializeField] private float movepow = 0.0f;
    [SerializeField] private float tarn_speed=0.0f;

    private Vector2 stickL = Vector2.zero;
    private Vector2 stickR = Vector2.zero;
    private Vector3 stickL3 = Vector3.zero;
    private Vector3 stickR3 = Vector3.zero;
    private Rigidbody myrb;
    private Transform myTf;
    void Start()
    {
        myrb = this.GetComponent<Rigidbody>();
        myTf = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);//Še“ü—Í‚ðŽæ“¾
        stickL3 = new Vector3(stickL.x,0.0f,stickL.y);
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        myTf.localEulerAngles = new Vector3(0.0f, stickR.x * tarn_speed, 0.0f);
    }
    private void FixedUpdate()
    {
        myrb.AddForce(stickL3 * movepow);


    }
}
