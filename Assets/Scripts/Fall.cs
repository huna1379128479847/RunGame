using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : BaseBarrier
{
    protected override void GameOver()
    {

        Debug.Log("落とし穴に[���I�[�o�[�I");
        base.GameOver();
    }
}
