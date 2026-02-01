using System.Collections.Generic;

public static class Utils
{
    public enum Mask
    {
        TEAM1,
        TEAM2,
        TEAM3
    }

    public enum NPCColor
    {
        RED,
        GREEN,
        BLUE,
        PURPLE
    }

    public enum Voice
    {
        LOW,
        MEDIUM,
        HIGH,
        MUSICAL
    }

    public enum Title
    {
        PRINCE,
        DUKE,
        PRINCESS,
        DUCHESS
    }

    public enum Room
    {
        GARDEN,
        BALCONY,
        DANCING_HALL,
        BUFFET
    }

    public enum Faction
    {
        ALLY,
        NEUTRAL,
        ENEMY
    }

    public static List<string> titles = new List<string>()
    {
        "Prince",
        "Duke",
        "Princess",
        "Duchess"
    };
}
