using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudOnce;
public class CloudOnceServices : MonoBehaviour
{
    // Start is called before the first frame updat
    public static CloudOnceServices instance;

    private void CheckForInstances()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    private void Awake()
    {

        CheckForInstances();
    }



    public void SubmitMyScoreToLeaderboard(int score)
    {

        Leaderboards.HighScores.SubmitScore(score);
    }
}
