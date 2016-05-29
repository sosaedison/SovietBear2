using UnityEngine;
using System.Collections;

public class FinalBossLevelManager : LevelManager {
    public GameObject cage;


    override public void BossDefeated()
    {
        cage.GetComponent<UnlockCharacter>().UnlockCage();
    }
}
