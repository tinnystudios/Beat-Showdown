using System.Collections.Generic;
using UnityEngine;

namespace App.Stages.Models
{
    /// <summary>
    /// The model for a sequence of waves
    /// </summary>
    [CreateAssetMenu(menuName = "Game/Stages/Wave Stage")]
    public class WaveStageModel : StageModel
    {
        public List<WaveModel> WaveModels;
    }
}