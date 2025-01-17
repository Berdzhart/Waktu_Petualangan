using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int scoreCount = 0;
    public TextMeshProUGUI UIText;


    // Start is called before the first frame update
    private void Awake()
    {
        UIText.text = scoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = scoreCount.ToString();
    }
}
