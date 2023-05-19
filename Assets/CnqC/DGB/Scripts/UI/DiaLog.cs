using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CnqC.DGB;
using TMPro;

// chúng ta ta có rất nhiều dialog( hộp thoại), sript này giúp xử lý các hộp thoại
public class DiaLog : MonoBehaviour
{
    public TextMeshProUGUI titleTxt;
    public TextMeshProUGUI contentTxt; // tham chiếu tới các thành phần có sử dụng Text bên trong 

    public virtual void Show(bool isShow)
    {
        gameObject.SetActive(isShow); //setAcive là để ẩn hay k ẩn( true là hiện, fl là ẩn)
    }
    
    public virtual void UpdateDiaLog(string title , string content)
    {
        if (titleTxt) // nếu biến này khác rỗng thì sẽ gán giá trị của text của titleTxt cho biến string title trong hàm 
            titleTxt.text = title;

        if (contentTxt)// nếu biến này khác rỗng thì sẽ gán giá trị của text của contentTxt cho biến string content trong hàm
            contentTxt.text = content;
    }

    public virtual void Close()
    {
        // phương thức đóng hộp thoại để ẩn đối tượng dialog
        gameObject.SetActive(false);
    }
}
