using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{

    // Biến lưu lại các thành phần trong shopItem

    public TextMeshProUGUI priceTxt;
    public Image hud;
    public Button btn;


    public void UpdateUI(ShopItem item, int itemIdx)
    {
        if (item == null) return; 

        // cập nhập HUD của shopItem

        if (hud)
            hud.sprite = item.previewImage; // cập nhập hình ảnh của con Hero mà chúng ta định mua sẽ như thế nào

        // ktra hero có cái chỉ số trong mảng các hero đã được mở khóa hay chưa
        bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdx);

        if (isUnlocked)
        {

            if(Pref.curPlayeriD == itemIdx)   // các chỉ số ( số thứ tự) mà các hero đang chọn hoặc đang chơi = chỉ số hero ở trong mảng ShopItem
                // hero đã mở khóa        
            {
                if (priceTxt)
                    priceTxt.text = "Active"; // khi mà hero đã mở khóa và đang được lưa chọn là active 
            }
            else
            {
                if (priceTxt)
                    priceTxt.text = "Owned"; // khi mà hero đã mở khóa và không được lưa chọn là owned+
            }
          }
        else // nếu mà hero chưa được unlock thì sẽ cập nhập lại giá tiền
        {
            if (priceTxt)
                priceTxt.text = item.ToString();
        }

    }
}
