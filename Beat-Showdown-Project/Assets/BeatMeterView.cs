using System;
using UnityEngine;
using UnityEngine.UI;

public class BeatMeterView : MonoBehaviour
{
    public Image Fill;
    public AnimationCurve Curve = AnimationCurve.EaseInOut(0,0,1,1);

    public void SetFill(float progress)
    {
        Fill.fillAmount = Curve.Evaluate(progress);
    }
}

[Serializable]
public class BeatMeterModel
{
    public float BPM { get; set; }
    public float ProgressToBeat01 { get; set; }

    public BeatMeterModel(float bpm)
    {
        BPM = bpm;
    }
}