using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : BaseBarrier
{
    override protected void GameOver()
    {
        Debug.Log("�Ђ悱��������������I�Q�[���N���A�[�I");
        base.GameOver();
    }
}
