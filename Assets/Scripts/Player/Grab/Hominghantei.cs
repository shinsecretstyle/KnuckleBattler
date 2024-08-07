using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hominghantei : MonoBehaviour
{
    private Transform myTf;
    private List<GameObject> sessyokulist = new List<GameObject>();
    private GameObject itibantikai;
    private float kyori = 10000.0f;
    // Start is called before the first frame update
    void Start()
    {
        myTf = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            sessyokulist.Add(other.gameObject);
            Itibantikaino();
        }
        
    }
    private void nTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            sessyokulist.Remove(other.gameObject);
            if (itibantikai != null)
            {
                if (other == itibantikai)
                {
                    itibantikai = null;
                    kyori = 10000.0f;
                }
            }
            Itibantikaino();
        }
    }
    private void Itibantikaino()
    {
        for(int i= 0;i <= sessyokulist.Count; i++)
        {
            Vector3 kyoridayo = sessyokulist[i].transform.position - myTf.position;
            float kyorihakaruyo = kyoridayo.sqrMagnitude;
            if(kyorihakaruyo < kyori)
            {
                itibantikai = sessyokulist[i];
                kyori = kyorihakaruyo;
            }
        }
    }
    public GameObject Itibantikaiyaru()
    {
        return itibantikai;
    }
}
