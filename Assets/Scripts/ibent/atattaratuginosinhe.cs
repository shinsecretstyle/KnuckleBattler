using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class atattaratuginosinhe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("�}�b�v");
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeScene();
    }
}
