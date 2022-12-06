using System;
using UnityEngine;

public static class ScoreConverter
{
    public static string Convert(long score)
    {
        if(score > 1000)
        {
            var pow = (int)(Mathf.Log10(score) / 3) * 3;
            var index = pow / 3;
            return $"{TryDivideToTenths(score, (long)Mathf.Pow(10, pow))}{(ScoreIndex)index}";
        }

        return score.ToString();
    }

    private static string TryDivideToTenths(long score, long divider)
    {
        return score / divider < 10 ? Math.Round((double)score / divider, 1).ToString() : (score / divider).ToString();
    }

    enum ScoreIndex
    {
        K = 1,
        M = 2,
        B = 3,
        T = 4,
        Q = 5,
        I = 6,
    }
}
