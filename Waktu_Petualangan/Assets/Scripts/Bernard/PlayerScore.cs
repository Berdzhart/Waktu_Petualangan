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

        if (SceneManager.GetActiveScene().name == "L1 Irfn")
        {
            if (scoreCount == 8)
            {
                if (!functionCalled)
                {
                    playerAnimator.SetTrigger("Die");
                    Invoke("LoadNewSceneL1Irfan", 1f);
                    functionCalled = true;
                }
            }
        }

        else if (SceneManager.GetActiveScene().name == "L2 Irfn")
        {
            if (scoreCount == 8)
            {
                if (!functionCalled)
                {
                    playerAnimator.SetTrigger("Die");
                    Invoke("LoadNewSceneL2Irfan", 1f);
                    functionCalled = true;
                }
            }
        }
    }
    private void LoadNewSceneL1Irfan()
    {
        SceneManager.LoadScene("L2 Irfn");
    }

    private void LoadNewSceneL2Irfan()
    {
        SceneManager.LoadScene("L3 Irfn");
    }


}
