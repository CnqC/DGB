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
}
