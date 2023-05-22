using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopDiaLog : DiaLog, IcomponentChecking
{
    public Transform gridRoot;
    //tham chiếu cái GameObject chứa component GridLayout Group

    public ShopItemUI itemUIPreFabs;

    private ShopManager m_shopMng;
    private GameManager m_gm;

    public bool IscomponentNull()
    {
        return m_shopMng == null || m_gm == null;
    }

    //Override phương thức Show của lớp cha D   iaLog
    public override void Show(bool isShow)
    {
        base.Show(isShow);

        m_shopMng = FindObjectOfType<ShopManager>();
        m_gm = FindObjectOfType<GameManager>();

        UpdateUI(); // tạo trước xong Ctrl . để tạo ra nó

    }

    private void UpdateUI()
    {
        if (IscomponentNull()) return;

        // mỗi khi chúng ta show bật lại cái ShopDiaLOg ra chúng ta sẽ xóa các phần tử con ở trong GridGroup đi
        ClearChilds();

        //var là khởi tạo 1 mảng k báo trước về định dạng
        var items = m_shopMng.items; // lấy ra mảng trong Script ShopManager.

        if (items == null || items.Length <=0 || gridRoot == null) return;

        for (int i = 0; i < items.Length; i++)
        {
            // index: mục lục 
            int idx = i; // lưu giá trị của thứ tự của vòng lập, làm như v để tránh lỗi.
            var item = items[idx]; // lấy ra các giá trị của mảng 

            // tạo ra các ShopItemUI
            var itemUIClone = Instantiate(itemUIPreFabs, Vector3.zero, Quaternion.identity);

            itemUIClone.transform.SetParent(gridRoot); /// set parent là đưa nó đi nó đi đâu và làm con của cái nào đó

            itemUIClone.transform.localScale = Vector3.one; //( scale 1,1,1)

            //reset cái  Posistion của itemUI về vị trí ( 000)

            itemUIClone.transform.localPosition = Vector3.zero;

            // cập nhập hình ảnh( hub) lẫn cái priceTxt cho các hero

            itemUIClone.UpdateUI(item,idx); //cái hàm UpdateUI là ở script ShopItemUI 
                                        // biến item là biến var đã được gọi ở trong vòng lặp for
    // Ta có thể gọi được hàm Update UI ở bên script ShopItemUI, bởi vì ở ngoài inspector của đối tượng ShopDiaLog, ta có kéo đối tượng ShopItem vào trong biến itemUIPrefabs
    // mà trong đối tượng ShopItem ta đã có add component Script ShopItemUI --> vì thế ta có thể dùng phương thức của script ShopItemUI ngay trong script Shop DiaLog
        
            if(itemUIClone.btn)
            {
                itemUIClone.btn.onClick.RemoveAllListeners(); // xóa bỏ tất cả những cái sự kiện sau khi click của biến itemUIclone trong Script ShopButtonUI đã vẽ ra

                // add sự kiện mới

                itemUIClone.btn.onClick.AddListener(() => ItemEvent(item,idx));
            }
        }
    }  
    
    public void ClearChilds()
    {
        if (gridRoot == null || gridRoot.childCount <= 0) return;
        // childCount đếm số lượng con trong 1 đối tượng transform
        // childCount là 1 thuộc tính của Transform

        // duyệt
        for (int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i); // lấy ra chỉ số từng con 1 trong gridGroup

            if (child)
                Destroy(child.gameObject); // hủy luôn đưa con và gameObject chứa đưa con luôn
                                            // cái gameObject là con của grid group
        }

    }


    // viết sự kiện khi ấn vào button của hero sẽ ra mua hero

    private void ItemEvent(ShopItem item, int itemidx)
    {
        if (item == null) return;

        // kiểm tra xem hero đã unlock chưa
        bool isUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemidx);

        // lấy ra trạng thái của hero trong shop mà ta đã lưu dưới máy ng dùng

        if (isUnlocked) // nếu đã unlock
        {
            // nếu item hiện tại mà người dùng click vào đó có cái Id = với cái Id con hero hiện tại mà chúng ta đang chọn --> sẽ không làm gì
            if (itemidx == Pref.curPlayeriD) return; // người chơi bấm chọn với con hero mà họ đã sở hưu --> ta sẽ không làm gì 

            // nếu mà không chọn vào
            Pref.curPlayeriD = itemidx; // việc mà ta ấn hero tại shop và nó hiện ở ngoài dù ta relay -> play lại vẫn hiện là do
                                        //  Pref.curPlayeriD lưu xuống máy người dùng thông qua biến itemidx ( là chỉ số thứ tự của hero trong ShopItem[] của ShopItem ( list các hero) của DataStruct 



            UpdateUI(); // cập nhập lại Shop


        }
        else if(Pref.coins >= item.price) // nếu tiền lưu ở trong máy người dùng lớn hoặc bằng với giá coin của nhân vật
            // nếu mà k unlock
        {
            // trừ số vàng ng chơi đang có, sẽ trừ đi số lượng tiền = giá tiền hero
            Pref.coins -= item.price;

            // khi mua con nhân vật đó thì sẽ set trạng thái của nó là Unlocked

            Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemidx, true); // cập nhập trạng thái của hero trong shop là đã mở --> chyển sang active / owner

            //xét lại cái ID của hero hiện tại mà người dùng sử dụng = với chỉ số itemidx( chỉ số mà hero mà người chơi đã click mua vào trong shop)
            Pref.curPlayeriD = itemidx;

           

            // cập nhập UI
            UpdateUI();

            // cập nhập số vàng người chơi còn lại trên main

                if (m_gm.guiMng)
                m_gm.guiMng.UpdateMainCoins();
        }
        else
        {
            Debug.Log(" You dont have enough money");
        }
    }
}
