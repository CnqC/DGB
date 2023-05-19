using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using TMPro;

public class GUIManager : MonoBehaviour
{
    // xử lý chung giao diện của người chơi

    public GameObject homeGUI;
    public GameObject gameGUI;
    public DiaLog gameOverDiaLog;
    public TextMeshProUGUI mainCoinTxt;
    public TextMeshProUGUI gameplayCoinTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShowGameGUI (bool isShow) // nếu như hộp thoại gameGUI bật thì homeGUI ẩn và ngược lại
    {
        if (gameGUI)
            gameGUI.SetActive(isShow);

        if (homeGUI)
            homeGUI.SetActive(!isShow);
    }

    public void UpdateMainCoins()
    {
        if (mainCoinTxt) 
            mainCoinTxt.text = Pref.coins.ToString();
        // nếu như biến mainCointxt khác rỗng thì sẽ giá trị text của nó sẽ bằng số coins dưới máy người dùng ép về dạng string cho nó bằng với dạng text.
    }
}   
