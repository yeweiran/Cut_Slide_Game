using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Clear()
    {
        SumScore.Reset();
        SumScore.ClearHighScore();
    }
}
