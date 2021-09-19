using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class RemoteServices : MonoBehaviour
{


    public static PlayGamesPlatform platform;

    void Start()
    {
        if (platform==null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled=true;
            platform=PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });

    }

    public void AddScoreToLeaderboard(float _score)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore((long)_score, Globals.LEADERBOARD_ID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public static void UnlockAchievement(string _achievementID)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(_achievementID, 100f, success => { });
        }
    }
}
