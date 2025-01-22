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
    [SerializeField] Animator playerAnimator;
    [SerializeField] Rigidbody2D rb;
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

        if (SceneManager.GetActiveScene().name == "L1 Irfn")
        {
            if (scoreCount == 8)
            {
                if (!functionCalled)
                {
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
                    Invoke("LoadNewSceneL2Irfan", 1f);
                    functionCalled = true;
                }
            }
        }

        else if (SceneManager.GetActiveScene().name == "L3 Irfn")
        {
            if (scoreCount == 7)
            {
                if (!functionCalled)
                {
                    Invoke("LoadNewSceneL3Irfan", 1f);
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

    private void LoadNewSceneL3Irfan()
    {
        SceneManager.LoadScene("EndScene");
    }

}
