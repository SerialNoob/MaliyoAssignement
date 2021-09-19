using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals
{
    public static float SPEED = 4;
    public static bool USE_SEED_GENERATION = true;
    public static string SEED_STRING = "123456";
    public static int MAX_FUEL = 5;
    public static int MAX_LIFE = 2;
    public static float Fuel_CONSUMPTIONTIME = 5;
    public static string CLOSESHAVEACHIEVEMENT_ID = "CgkIpOf01uwTEAIQAA";
    public static string LEADERBOARD_ID = "CgkIpOf01uwTEAIQAQ";



    static Globals()
    {

    }


    public enum Level_DIFFICULTY
    {
        EASY,MEDIUM,HARD
    }
}
