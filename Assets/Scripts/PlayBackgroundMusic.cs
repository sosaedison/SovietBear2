using UnityEngine;
using System.Collections;

public class PlayBackgroundMusic : MonoBehaviour {
    public AudioClip music;
    public AudioSource source;
    public float loopPoint;

	void OnEnable () {
        var infiniteMusic = new InfiniteBackgroundMusic();
        infiniteMusic.ChangeTrack(source, music, loopPoint);
    }

}
