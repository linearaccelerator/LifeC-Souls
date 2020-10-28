﻿using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;

public class Methods : MonoBehaviour
{
    public static int NotationSettings;

    public static void BigDoubleFill(BigDouble x, BigDouble y, ref Image fill)
    {
        float z;
        var a = x / y;
        if (a < 0.001)
            z = 0;
        else if (a > 10)
            z = 1;
        else
            z = (float)a.ToDouble();
        fill.fillAmount = z;
    }

    public static string NotationMethod(BigDouble x, string y)
    {
        if (x <= 1000) return x.ToString(y);
        switch (NotationSettings)
        {
            case 0:
                {
                    var exponent = Floor(Log10(Abs(x)));
                    var mantissa = x / Pow(10, exponent);
                    return mantissa.ToString("F2") + "e" + exponent;
                }
            case 1:
                {
                    var exponent = 3 * Floor(Floor(Log10(x)) / 3);
                    var mantissa = x / Pow(10, exponent);
                    return mantissa.ToString("F2") + "e" + exponent;
                }
            case 2:
                {

                    var exponent = Floor(Log10(x));
                    var thirdExponent = 3 * Floor(exponent / 3);
                    var mantissa = x / Pow(10, thirdExponent);

                    var exponent2 = Floor(Log10(Abs(x)));
                    var mantissa2 = x / Pow(10, exponent);

                    if (x < 1000) return x.ToString("F2"); // Normal Number
                    if (x > 1e308) return mantissa2.ToString("F2") + "e" + exponent2; //over 1e308 sci notation
                    return (x / Pow(10, thirdExponent)).ToString("F2") + prefixes[thirdExponent.ToDouble()]; //word notation

                }
        }
        return "";
    }
    private static readonly Dictionary<double, string> prefixes = new Dictionary<double, string>()
    {
        {3, " Thousand" },
        {6, " Million" },
        {9, " Billion" },
        {12, " Trillion" },
        {15, " Quadrillion" },
        {18, " Quintillion" },
        {21, " Sextillion" },
        {24, " Septillion" },
        {27, " Octillion" },
        {30, " Nonillion" },
        {33, " Decillion" },
        {36, " Undecillion" },
        {39, " Duodecillion" },
        {42, " Tredecillion" },
        {45, " Quattuordecillion" },
        {48, " Quinquadecillion" },
        {51, " Sexdecillion" },
        {54, " Septendecillion" },
        {57, " Octodecillion" },
        {60, " Novendecillion" },
        {63, " Vigintillion" },
        {66, " Unvigintillion" },
        {69, " Duovigintillion" },
        {72, " Trevigintillion" },
        {75, " Quattuorvigintillion" },
        {78, " Quinvigintillion" },
        {81, " Sexvigintillion" },
        {84, " Septenvigintillion" },
        {87, " Octovigintillion" },
        {90, " Nonvigintillion" },
        {93, " Trigintillion" },
        {96, " Untrigintillion" },
        {99, " Duotrigintillion" },
        {102, " Tretrigintillion" },
        {105, " Quattuortrigintillion"},
        {108, " Quintrigintillion" },
        {111, " Sextrigintillion" },
        {114, " Septentrigintillion" },
        {117, " Octotrigintillion" },
        {120, " Novemtrigintillion" },
        {123, " Quadragintillion"  },
        {126, " Unquadragintillion" },
        {129, " Duoquadragintillion" },
        {132, " Trequadragintillion" },
        {135, " Quattuorquadragintillion" },
        {138, " Quinquadragintillion" },
        {141, " Sexquadragintillion" },
        {144, " Septenquadragintillion" },
        {147, " Octoquadragintillion" },
        {150, " Novemquadragintillion" },
        {153, " Quinquagintillion" },
        {156, " Unquinquagintillion" },
        {159, " Duoquinquagintillion" },
        {162, " Trequinquagintillion" },
        {165, " Quattuorquinquagintillion" },
        {168, " Quinquinquagintillion" },
        {171, " Sexquinquagintillion" },
        {174, " Septenquinquagintillion" },
        {177, " Octoquinquagintillion" },
        {180, " Novemquinquagintillion" },
        {183, " Sexangintillion" },
        {186, " Unsexangintillion" },
        {189, " Duosexangintillion" },
        {192, " Tresexangintillion" },
        {195, " Quattuorsexangintillion" },
        {198, " Quinsexangintillion" },
        {201, " Sexsexangintillion" },
        {204, " Septensexangintillion" },
        {207, " Octosexangintillion" },
        {210, " Novemsexangintillion" },
        {213, " Septuagintillion" },
        {216, " Unseptuagintillion" },
        {219, " Duoseptuagintillion" },
        {222, " Treseptuagintillion" },
        {225, " Quattuorseptuagintillion" },
        {228, " Quinseptuagintillion" },
        {231, " Sexseptuagintliion" },
        {234, " Septenseptuagintllion" },
        {237, " Octoseptuagintillion" },
        {240, " Novemseptuagintillion" },
        {243, " Octogintllion" },
        {246, " Unoctogintillion" },
        {249, " Duooctogintillion" },
        {252, " Treoctogintillion" },
        {255, " Quattuoroctogintillion" },
        {258, " Quinoctogintillion" },
        {261, " Sexoctogintillion" },
        {264, " Septenoctogintillion" },
        {267, " Octooctogintillion" },
        {270, " Novemoctogintillion" },
        {273, " Nonangintillion" },
        {276, " Unnonangintillion" },
        {279, " Duononangintillion" },
        {282, " Trenonagintillion" },
        {285, " Quattuornonangintillion" },
        {288, " Quinnonangintillion" },
        {291, " Sexnonangintillion," },
        {294, " Septennonangintillion" },
        {297, " Octononagintillion" },
        {300, " Novemnonagintillion" },
        {303, " Centillion" },
        {306, " Infinity" }
    };

    public static void BuyMax(ref BigDouble c, BigDouble b, float r, ref BigDouble k)
    {
        var n = Floor(Log((c * (r - 1) / (b * Pow(r, k))) + 1, r));

        var cost = b * (Pow(r, k) * (Pow(r, n) - 1) / (r - 1));

        if (c >= cost)
        {
            k += n;
            c -= cost;
        }

    }

    public static void BuyMaxLimit(ref BigDouble c, BigDouble b, float r, ref BigDouble k, int limit)
    {
        var n = Floor(Log((c * (r - 1) / (b * Pow(r, k))) + 1, r));
        if (n + k > limit) n -= k;
        var cost = b * (Pow(r, k) * (Pow(r, n) - 1) / (r - 1));

        if (c < cost) return;
        k += n;
        c -= cost;
    }
}