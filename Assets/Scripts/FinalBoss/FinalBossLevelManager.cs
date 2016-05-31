using UnityEngine;
using System.Collections;

public class FinalBossLevelManager : LevelManager {
    public GameObject cage;
    public AudioClip winMusic;


    override public void BossDefeated()
    {
        cage.GetComponent<UnlockCharacter>().UnlockCage();
        musicPlayer = FindObjectOfType<PlayBackgroundMusic>();
        musicPlayer.ChangeTrack(winMusic, 2.4f);
    }
}
