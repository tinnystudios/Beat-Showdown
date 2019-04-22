using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INote
{
    int Index { get; set; }
    float Progress { get; set; }
    void Finish();
}

public class Note : INote
{
    public int Index { get; set; }
    public float Progress { get; set; }
    public void Finish()
    {

    }
}

public class SongRunner : MonoBehaviour
{
    [Header("Song Configs")]
    public BPMTool BPMTool;
    public AudioClip Clip;
    public BeatMeterView BeatMeterView;

    private List<INote> _notes = new List<INote>();

    private void Awake()
    {
        BPMTool.Play(Clip, 128);
        BPMTool.OnBeat += OnPlayBeat;
    }

    public void OnPlayBeat(BeatEventArgs beatArgs)
    {
        var instance = new Note
        {
            Index = beatArgs.Index
        };

        _notes.Add(instance);
    }

    public void MoveNotes()
    {
        foreach (var note in _notes)
        {
            float t = (float)(BPMTool.Lead - (BPMTool.NoteArgs[note.Index].Index - BPMTool.SongPosInBeats)) / BPMTool.Lead;
            BeatMeterView.SetFill(t);
        }
    }

    public void TryClean()
    {
        List<INote> toRemove = new List<INote>();
        foreach (var note in _notes)
        {
            if (note.Progress >= 1)
            {
                toRemove.Add(note);
            }
        }

        foreach (var note in toRemove)
        {
            _notes.Remove(note);
            note.Finish();
        }
    }

    private void Update()
    {
        TryClean();
        MoveNotes();
    }
}
