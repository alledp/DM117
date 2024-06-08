using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController_Finish : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string score;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetString("total_score");

        scoreText.text = score;

    }

}
