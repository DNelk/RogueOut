using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Just a static class to hold the 5 colors I'm using for this project
/// </summary>
public static class ProjectColors
{
    public static Color Yellow = new Color(0.996f, 0.894f, 0.251f);
    public static Color Purple = new Color(0.608f, 0.365f, 0.898f);
    public static Color Pink = new Color(0.945f, 0.357f, 0.710f);
    public static Color Blue = new Color(0f, 0.733f, 0.976f);
    public static Color Teal = new Color(0f, 0.961f, 0.831f);

    public static Color[] Colors = {Yellow, Purple, Pink, Blue, Teal}; //Also store these in an array, for randomization purposes
}
