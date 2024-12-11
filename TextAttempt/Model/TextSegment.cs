namespace IHeartFunnyReindeer.Model;

public enum EffectType
{
    None,
    Glitched,
    Scrambled,
    Distorted,
}

public record struct TextSegment(string Text, string Color, EffectType EffectType);
