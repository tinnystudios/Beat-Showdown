using App.Characters.Controllers;

/// <summary>
/// A Game Implementation of PlayerCharacterAgent
/// All unique actions should be in here and not PlayerCharacterAgent
/// </summary>
public class BeatPlayerAgent : PlayerCharacterAgent, IBind<BeatMeterAgent>
{
    public BeatCondition BeatCondition;

    public void Bind(BeatMeterAgent beatMeterAgent)
    {
        BeatCondition.Bind(beatMeterAgent);
    }
}
