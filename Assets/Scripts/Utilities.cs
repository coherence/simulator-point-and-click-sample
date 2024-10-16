using UnityEngine;

public static class Utilities
{
    public static Color RandomColor()
    {
        return Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);
    }

    public static Vector3 RandomPositionInCircle(float circleRadius)
    {
        float angle = Random.Range(0f, 360f);
        float x = circleRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = circleRadius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, 0f, z);
    }
}