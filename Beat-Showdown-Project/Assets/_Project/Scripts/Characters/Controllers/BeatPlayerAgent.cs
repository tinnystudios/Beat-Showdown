using App.Characters.Controllers;
using App.Game.UserInput;

/// <summary>
/// A Game Implementation of PlayerCharacterAgent
/// All unique actions should be in here and not PlayerCharacterAgent
/// </summary>
public class BeatPlayerAgent : PlayerCharacterAgent, IBind<BeatMeterAgent>
{
    public BeatCondition BeatCondition;

    public override void ProcessCombatInput()
    {
        if (BeatCondition.Pass)
            base.ProcessCombatInput();
    }

    public void Bind(BeatMeterAgent beatMeterAgent)
    {
        BeatCondition.Bind(beatMeterAgent);
    }
}
