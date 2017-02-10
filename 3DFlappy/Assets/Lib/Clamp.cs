using System;

/// <summary>
/// クランプクラス
/// Yuuho Aritomi 
/// 2017/02/05
/// </summary>
public class Clamp
{
    /// <summary>
    /// クランプ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_min"></param>
    /// <param name="_max"></param>
    /// <returns></returns>
    public static int clamp(int _x, int _min, int _max)
    {
        return Math.Min(_max, Math.Max(_min, _x));
    }

    /// <summary>
    /// クランプ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_min"></param>
    /// <param name="_max"></param>
    /// <returns></returns>
    public static float clamp(float _x, float _min, int _max)
    {
        return Math.Min(_max, Math.Max(_min, _x));
    }

    /// <summary>
    /// クランプ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_min"></param>
    /// <param name="_max"></param>
    /// <returns></returns>
    public static double clamp(double _x, double _min, double _max)
    {
        return Math.Min(_max, Math.Max(_min, _x));
    }
}
