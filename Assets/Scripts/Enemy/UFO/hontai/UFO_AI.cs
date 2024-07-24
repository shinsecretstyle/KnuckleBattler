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
            if(Vector3.Distance(transform.position,pc.playerPos.transform.position) > AttackDis)//追跡
            {
                //移動
                Vector3 dir = (pc.playerPos.transform.position - transform.position).normalized;
                dir.y = 0;
                transform.position += dir * Time.deltaTime * 10;
                //向かう
                Vector3 lookat = new Vector3(pc.playerPos.transform.position.x, dir.y, pc.playerPos.transform.position.z).normalized;
                transform.forward = lookat;
            }
            else
            {
                //攻撃
            }
        }
        else
        {
            {
                
                if (!isInSpawnPos)//初期化
                {
                    transform.position = SpawnPos;
                    isInSpawnPos = true;
                }
            }
        }
    }
}
