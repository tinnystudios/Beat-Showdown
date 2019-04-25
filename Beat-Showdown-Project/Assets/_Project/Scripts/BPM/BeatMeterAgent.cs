using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The BeatMeterAgent also contains the Model
/// </summary>
public class BeatMeterAgent : MonoBehaviour
{
    public BPMTool BPMTool;
    public BeatMeterView BeatMeterView;

    [Header("Song Configuration")]
    public AudioClip Clip;
    public int BPM;

    private List<INoteModel> _notes = new List<INoteModel>();

    public float Progress { get; private set; }

    private void Awake()
    {
        BPMTool.Play(Clip, BPM);
        BPMTool.OnBeat += OnPlayBeat;
    }

    private void OnDestroy()
    {
        BPMTool.OnBeat -= OnPlayBeat;
    }

    private void Update()
    {
        TryClean();
        MoveNotes();
    }

    public void OnPlayBeat(BeatEventArgs beatArgs)
    {
        var instance = new NoteModel
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
            Progress = t;
        }
    }

    public void TryClean()
    {
        List<INoteModel> toRemove = new List<INoteModel>();
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
}