using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BPMTool : MonoBehaviour
{
    public event Action<BeatEventArgs> OnBeat;

    [Range(0, 500)]
    public int Lead = 1;
    public float Speed = 1;

    public List<BeatEventArgs> NoteArgs { get; private set; }

    public bool IsRunning { get { return _songSource != null && _songSource.isPlaying; } }
    public int BPM { get; private set; }
    public int Index { get; private set; }
    public int TotalBeats { get; private set; }
    public double SongPos { get; private set; }
    public double SongPosInBeats { get; private set; }
    public double SecPerBeat { get; private set; }

    private AudioSource _songSource = null;
    public int OutputBPM;

    public void Play(AudioClip clip, int bpm, List<BeatEventArgs> notes = null, double songPos = 0)
    {
        _songSource = GetComponent<AudioSource>();
        _songSource.clip = clip;

        BPM = bpm;
        SecPerBeat = 60f / BPM;

        TotalBeats = (int)(_songSource.clip.length / SecPerBeat);
        NoteArgs = new List<BeatEventArgs>();
        for (int i = 0; i < TotalBeats; i++)
        {
            NoteArgs.Add(new BeatEventArgs
            {
                Index = i
            });
        }

        Index = 0;

        _songSource.Play();
        _songSource.time = (float)songPos;
    }

    public void AnalyzeClip(AudioClip clip, int bpm)
    {
        _songSource = GetComponent<AudioSource>();
        _songSource.clip = clip;
        BPM = bpm;

        SecPerBeat = 60f / BPM;
        TotalBeats = (int)(clip.length / SecPerBeat);
    }

    public void Stop()
    {
        _songSource.Stop();
    }

    private void Update()
    {
        if (!IsRunning) return;

        SongPos = _songSource.time;
        SongPosInBeats = SongPos / SecPerBeat;

        OutputBPM = (int)(BPM * _songSource.pitch);

        AnalyzeSamples();
    }

    public void AnalyzeSamples()
    {
        if (Index < NoteArgs.Count && NoteArgs[Index].Index < SongPosInBeats + Lead)
        {
            if (OnBeat != null)
                OnBeat.Invoke(NoteArgs[Index]);

            Index++;
        }
    }
}
