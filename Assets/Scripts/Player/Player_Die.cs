using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Die : MonoBehaviour
{
    public void Die()
    {
        Debug.Log("�����͂Ȃ����");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
