using System;

/// <summary>
/// ラップクラス
/// Yuuho Aritomi
/// 2017/02/05
/// </summary>
public class Wrap
{
    /// <summary>
    /// ラップ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_low"></param>
    /// <param name="_high"></param>
    /// <returns></returns>
    public static int wrap(int _x, int _low, int _high)
    {
        if (_low > _high) return 0;

        int n = (_x - _low) % (_high - _low);
        return (n >= 0) ? (n + _low) : (n + _high);
    }

    /// <summary>
    /// ラップ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_low"></param>
    /// <param name="_high"></param>
    /// <returns></returns>
    public static float wrap(float _x, float _low, float _high)
    {
        if (_low > _high) return 0;

        float n = (_x - _low) % (_high - _low);
        return (n >= 0) ? (n + _low) : (n + _high);
    }

    /// <summary>
    /// ラップ処理
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_low"></param>
    /// <param name="_high"></param>
    /// <returns></returns>
    public static double wrap(double _x, double _low, double _high)
    {
        if (_low > _high) return 0;

        double n = (_x - _low) % (_high - _low);
        return (n >= 0) ? (n + _low) : (n + _high);
    }
}
