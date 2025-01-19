using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int scoreCount = 0;
    public TextMeshProUGUI UIText;
    public Animator playerAnimator;
    private bool functionCalled = false;


    // Start is called before the first frame update
    private void Awake()
    {
        UIText.text = scoreCount.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        UIText.text = scoreCount.ToString();
        Debug.Log(scoreCount);
        if (scoreCount == 13)
        {
            if (!functionCalled)
            {
                playerAnimator.SetTrigger("LevelTransition");
                Invoke("LoadNewScene", 1f);
                functionCalled = true;
            }
        }
    }
    private void LoadNewScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
