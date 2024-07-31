using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public GameObject Enemy;
    public bool findPlayer;
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        findPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(findPlayer)
        {
            //Debug.Log(playerPos.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPos = other.transform;
            findPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            findPlayer = false;
        }
    }

}
