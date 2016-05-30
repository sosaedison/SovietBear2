using UnityEngine;
using System.Collections;

// MIT License ( MIT, https://opensource.org/licenses/MIT )
// Copyright (c) 2015 GhoulMage (Contact: theghoulmage@gmail.com)

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
public sealed class InfiniteBackgroundMusic {
	public float MusicLoopPoint;
	public AudioClip audioClip;
	
	public float Time {
		get {
			long p = position;

			p /= entire.Length;

			return p * audioClip.length;
		}
		set {
			double m = value / audioClip.length;

			position = (long)(m * entire.Length);
		}
	}
	public float Duration {
		get {
			return audioClip.length;
		}
	}
	public long SampleTime {
		get {
			return position;
		}
		set {
			if (value >= entire.Length) {
				Debug.LogError("Value is larger than audioClip.samples");
				return;
			}
			if (value < 0) {
				Debug.LogError("Value is lesser than 0");
				return;
			}
			position = value;
		}
	}
	public int SampleDuration {
		get {
			return entire.Length;
		}
	}

	float[] entire;
	long position;
	int sampleLoopPoint;
	string audioName;
	int channels;

	int start;
	AudioSource audioSource;

	public void Play(AudioSource source) {
		double mul = MusicLoopPoint / audioClip.length;
		sampleLoopPoint = (int)(mul * audioClip.samples);

		channels = audioClip.channels;
		audioName = audioClip.name;
		entire = new float[audioClip.samples * channels];

		audioClip.GetData(entire, 0);

		audioClip = AudioClip.Create(audioName + "_Loop", audioClip.samples, channels, audioClip.frequency, true, OnAudioRead, OnAudioSetPos);

		audioSource = source;

		audioSource.loop = true;
		audioSource.clip = audioClip;
		start = 0;
		position = 0;
		audioSource.Play();
	}
	public void Stop() {
		audioSource.Stop();
		position = 0;
	}
	public void Replay() {
		audioSource.Stop();
		start = 0;
		position = 0;
		audioSource.Play();
	}
	public void ChangeTrack(AudioSource audioSource, AudioClip newTrack, float loop) {
		if (audioClip != null) {
			Stop();
			Object.Destroy(audioClip);
		}
		audioClip = newTrack;
		MusicLoopPoint = loop;
		Play(audioSource);
	}

	void OnAudioRead(float[] data) {
		if (start <= 16) {
			start++;
			position = 0;
			for (int i = 0; i < data.Length; i++)
				data[i] = 0;
			return;
		}
		int count = 0;
		while (count < data.Length) {
			data[count] = entire[position];

			position++;
			count++;

			if (position >= entire.Length) {
				position = sampleLoopPoint * channels;
			}
		}
	}
	void OnAudioSetPos(int newPos) {

	}
}
