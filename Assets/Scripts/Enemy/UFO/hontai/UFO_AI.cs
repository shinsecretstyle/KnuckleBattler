using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UFO_AI : MonoBehaviour
{
    public GameObject Target;
    public GameObject PlayerCheck;
    public float AttackDis;
    [SerializeField]
    bool isInSpawnPos;
    PlayerCheck pc;

    Vector3 SpawnPos;
    void Start()
    {
        SpawnPos = transform.position;
        pc = PlayerCheck.GetComponent<PlayerCheck>();
        AttackDis = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.findPlayer)
        {

            Debug.Log(Vector3.Distance(transform.position, pc.playerPos.transform.position));
            isInSpawnPos = false;
            if(Vector3.Distance(transform.position,pc.playerPos.transform.position) > AttackDis)//í«ê’
            {
                //à⁄ìÆ
                Vector3 dir = (pc.playerPos.transform.position - transform.position).normalized;
                dir.y = 0;
                transform.position += dir * Time.deltaTime * 10;
                //å¸Ç©Ç§
                Vector3 lookat = new Vector3(pc.playerPos.transform.position.x, dir.y, pc.playerPos.transform.position.z).normalized;
                transform.forward = lookat;
            }
            else
            {
                //çUåÇ
            }
        }
        else
        {
            {
                
                if (!isInSpawnPos)//èâä˙âª
                {
                    transform.position = SpawnPos;
                    isInSpawnPos = true;
                }
            }
        }
    }
}
