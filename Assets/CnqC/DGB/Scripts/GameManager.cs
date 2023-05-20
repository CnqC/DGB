using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
public class GameManager : MonoBehaviour,IcomponentChecking // tự động tạo ra các con quái
{
    public float spawnTime; // thời gian để tạo ra quái
    public Enemy[] enemyPrefabs; // tập hợp các con quái trong Prefabs

    public GUIManager guiMng; // tham chiếu  tới scirpt Guimanager

    private int m_score; // set/get --> ctrl . ( private bởi vì k muốn bên ngoài có thể sửa điểm số)
    private bool m_isGameOver;




    public int Score { get => m_score; set => m_score = value; }
    // Start is called before the first frame update
    void Start()
    {

        // để gọi 1 Coroutine thì ta phải gọi

      

        if (IscomponentNull()) return;

        guiMng.ShowGameGUI(false); // khi người chơi mới vảo thì ta sẽ show cái homeGui và ẩn cái gameGUI 
                                   // hiện lên cái homeGUi cho người chơi ấn Play hay tác vụ khác

        // cập nhập lại số coins ng chơi nhận được
        guiMng.UpdateMainCoins();
    }

    public void PlayGame() 
    {
        guiMng.ShowGameGUI(true); // là hiện cái GameGUi đi và ẩn cái HOmeGUi và bắt đầu game

        StartCoroutine(SpawnEnemy()); // spawn lính

        // cập nhập số vàng ng chơi ở gameGUI

        guiMng.UpdateGamePlayCoins();
    }

    public void GameOver()
    {
        if (m_isGameOver) return; //nếu game kết thúc rồi thì k chạy câu lệnh dưới, nếu k thì thực hiện

        Pref.bestScore = m_score; // lưu lại điểm số cao nhất của người chơi

        //hiện thị hộp thoại GameOver
        if(guiMng.gameOverDiaLog) // biến gameOverDialoG trong guiMng khác null thì chạy
        guiMng.gameOverDiaLog.Show(true);
        // biến guiMng tham chiếu tới biến gameOverDiaLog ( kế thừa lớp DiaLog), gọi hàm Show( biến bool true) để hiện ra hộp thoại GameOver

    }
    // tạo ra 1 coroutine
    IEnumerator SpawnEnemy()
    {
        while (!m_isGameOver) // khi nào mà gameOver là true thì sẽ thoát khỏi vòng lập và outGame.
        {
            // lấy ngẫu nhiên trong mảng enemies 1 con quái
            if (enemyPrefabs != null && enemyPrefabs.Length > 0) // mảng quái khác null và phải có phần tử ở trong
            {
                int ranIdx = Random.Range(0, enemyPrefabs.Length);
                //  Random.Range lấy ngẫu nhiên các chỉ số trong mảng không quá giá trị lớn nhất trong mảng ( giá trị nhỏ nhất, giá trị lớn nhất)  vd ( 0,3) thì nó chỉ lấy 0,1,2 thôi.

                Enemy enemyPref = enemyPrefabs[ranIdx];

                if (enemyPref)// tạo đối tượng gameObject từ code và setup vị trị tạo của nó
                {
                    Instantiate(enemyPref, new Vector3(8, 0, 0), Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }   
    }

    public bool IscomponentNull()
    {
        return guiMng == null;
    }
}
