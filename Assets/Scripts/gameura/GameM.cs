using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameM : MonoBehaviour
{
    public static GameM instance = null;
    public int[] enemykazu;
    public int[] monokazu;
    private int hp = 3;
    private GameObject Player;
    private Transform Playerpoint;

    private void Awake()//�V���O���g��
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlayerHP(int hitpoint)
    {
        hp = hitpoint;
    }

    public int PlayerHPPull()//�v���C���[��HP���m�F���������p
    {
        return hp;
    }
    public void PlayerGameobj(GameObject plyer)//�v���C���[�̃Q�[���I�u�W�F�N�g�𑗂荞�ޓz�B�v���C���[�ȊO�̑��̃I�u�W�F�N�g�����Ȃ��ŗ~����
    {
        Player = plyer;
        Playerpoint = Player.GetComponent<Transform>();
    }
    public Transform PlayerPositon()//�ꉞ������v���C���[�̏ꏊ�m�F�ł����B�v���C���[���Z�b�g����ĂȂ����null��Ԃ�
    {
        if (Playerpoint != null)
        {
            return Playerpoint;
        }
        else
        {
            return null;
        }
        
    }
    public void Scoretuika(int enemy )//�|�ꂽ�G�͂����ɃA�N�Z�X���ăL���J�E���g�Ɉ�ǉ������B
    {
        enemykazu[enemy] += 1;
    }
    public int[] EnemyScorePull()//�|�����G�̃X�R�A���m�F����ׂ̓z�B�z��Ȃ̂Œ���
    {
        return enemykazu;
    }
    
}