using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // quản lý các scence

public class GameOverDiaLog : DiaLog
{
    public TextMeshProUGUI bestScoreTxt;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        if (bestScoreTxt)
            bestScoreTxt.text = Pref.bestScore.ToString("000");
    }

    public void Replay()
    {
        Close(); // đóng lại cái dialog này
        SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
                                // tên Scence ( phải giống như tên ta tạo ở ngoài unity)
    }

    public void QuitGame()
    {
        Application.Quit(); // application là ở trên di động thôi, trên pc thì không
    }
}
