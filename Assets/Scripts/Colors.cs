using UnityEngine;

public static class Colors
{
    public static Color green = new(0.4334f, 0.78f, 0.234f);
    public static Color red = new(0.8117647f, 0.1803922f, 0.1764706f);
    public static Color yellow = new(0.9019608f, 0.8f, 0.1215686f);
    public static Color blue = new(0.01176471f, 0.6509804f, 0.8901961f);

    private static readonly int numOfColors = 4;

    public static Color GetRandomColor()
    {
        int colorIndex = Random.Range(0, numOfColors);

        return colorIndex switch
        {
            0 => green,
            1 => red,
            2 => yellow,
            3 => blue,
            _ => green,
        };
    }

    public static Color GetDifferentRandomColor(Color color)
    {
        Color newColor = GetRandomColor();

        while (newColor == color)
        {
            newColor = GetRandomColor();
        }

        return newColor;
    }
}