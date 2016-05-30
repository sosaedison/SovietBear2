using UnityEngine;
using System.Collections;

public class PlayBackgroundMusic : MonoBehaviour {
    public AudioClip startingMusic;
    AudioSource source;
    public float loopPoint;
    InfiniteBackgroundMusic infiniteMusic = new InfiniteBackgroundMusic();

    void Awake () {
        DontDestroyOnLoad(gameObject);
        source = GetComponent<AudioSource>();
        infiniteMusic.ChangeTrack(source, startingMusic, loopPoint);
    }

    public void ChangeTrack(AudioClip newTrack, float newLoopPoint)
    {
        infiniteMusic.ChangeTrack(source, newTrack, newLoopPoint);
    }

    public void PlaySingleLoop(AudioClip newTrack)
    {
        infiniteMusic.Stop();
        source.clip = newTrack;
        source.loop = false;
        source.Play();
    }
}
