using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : BaseBarrier
{
    override protected void GameOver()
    {
        bird.GetComponent<PlayerController>().Notify_Gameover();
        Debug.Log("�Ђ悱��������������I�Q�[���N���A�[�I");
    }
}
