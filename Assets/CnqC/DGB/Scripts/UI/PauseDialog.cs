using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // quản lý các scene

public class PauseDialog : DiaLog
{
    public override void Show(bool isShow)
    {
        Time.timeScale = 0f; // dừng tất cả thời gian lại

        base.Show(isShow);
    }

     
    public void Resume()
    {
        Close();

    }

    public void Replay()
    {
        Close();

        SceneManager.LoadScene(Const.GAMEPLAY_SCENE); // chuyển sang scence GamePlay trong unity.
    }
        
    public override void Close()
    {
        Time.timeScale = 1f;// đưa timeScale lại bình thường
        base.Close();   
    }
}
