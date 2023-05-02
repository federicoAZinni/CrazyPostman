using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreFinal : MonoBehaviour
{
    [SerializeField] GameObject scoreUIFinalPanel;
    public Text scoreUIFinal;
    public bool finish;

    bool flag = true;

    public void StartAnim()
    {
        if (!flag) return;
        LeanTween.moveLocalY(gameObject, 0, 0.3f).setEaseOutBack().setOnComplete(() => {
            LeanTween.scale(scoreUIFinal.gameObject, Vector2.one * 1.2f, 0.5f).setLoopPingPong(-1);
        });
        scoreUIFinal.text = "Score " + GameManager.Instance.Score.ToString();
        finish = true;
        flag = false;
    }
    private void Update()
    {
        if (finish)
        {
            if (Input.GetKeyDown(KeyCode.Return)) SceneManager.LoadScene("Game");
        }

    }
}
