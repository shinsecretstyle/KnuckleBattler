using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tekihyouzi : MonoBehaviour
{
    [SerializeField] Sprite[] tekusurya;
    [SerializeField] int sprite;
    [SerializeField] int killsuu;
    [SerializeField] GameObject text;
    Image image;
    TextMeshProUGUI keytext;
    // Start is called before th
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }

    public void Datein(int nanber)
    {

        image = this.GetComponent<Image>();
        image.sprite = tekusurya[nanber];
    }
}
