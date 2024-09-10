using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hyouzihyouzi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField,Tooltip("横に表示する最大値")] int yoko ;
    [SerializeField, Tooltip("横に何ピクセル移動して設置するか")] int x_idoukyori;
    [SerializeField, Tooltip("縦に何ピクセル移動して設置するか")] int y_idoukyori;
    [SerializeField, Tooltip("倒した敵の数")] int[] kazu;
    [SerializeField] int[] monokazu;
    [SerializeField, Tooltip("表示するスコアの奴")] GameObject myprefab;
    private int count = 0;
    private tekihyouzi tekics= null;

    private void Start()
    {
        int[] tekidayo = { 5, 1, 2 };
        HyouziAwake(tekidayo);
    }
    public void HyouziAwake(int[] teki)
    {
        Debug.Log("アウェイク");
        kazu = teki;
        Hyouzi();
    }
    private void Hyouzi()
    {
        Debug.Log("hyouzi");
        count = 0;
        for(int i = 0;kazu.Length - 1 >= i; i++)
        {
            for(int g = 0;kazu[i] >= g; g++)
            {
                
                int tatehyouzi = (int)Mathf.Floor(count / yoko);
                int yokohyouzi = count - (tatehyouzi * yoko);
                Vector3 orizin = this.transform.position;
                GameObject sukoa = Instantiate(myprefab,new Vector3(orizin.x,orizin.y,orizin.z),this.transform.rotation);
                Debug.Log("つくった");
                sukoa.transform.SetParent(this.transform);
                RectTransform rect = sukoa.GetComponent<RectTransform>();
                rect.localScale = new Vector2(1, 1);
                Vector3 basyo;
                basyo.x = yokohyouzi * x_idoukyori;
                basyo.y = tatehyouzi * y_idoukyori;
                basyo.z = 0.0f;
                rect.localPosition = basyo;
                GameObject child = sukoa.transform.GetChild(0).gameObject;
                tekics = child.GetComponent<tekihyouzi>();
                tekics.Datein(i);
                count += 1; 
                
            }
        }
    }
}
