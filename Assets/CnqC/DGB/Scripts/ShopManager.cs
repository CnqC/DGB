using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public class ShopManager : MonoBehaviour
{

    public ShopItem[] items;  /// các shopItem được lưu vào trong mảng iTem


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Init() // khởi tạo các dữ liệu máy ban đầu được lưu dưới shop
    {
        if (items == null || items.Length <= 0) return;

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i]; // lấy ra những phần tử ở trong mảng Item

            string dataKey = Const.PLAYER_PREFIX_PREF + i; // key cua PlayerPrefix nằm trong Script Const, mình đặt 1 chuỗi "Player_"
                                                           // player_0, player_1, player_2
                                                           // lưu lại những trái thái của các hero tách biệt ra, để check là các trạng thái đó đã mở khóa hay chưa

            if (item != null)
            {
                if(i == 0) // mặc định skin đầu tiên cho người chơi -- > giá free
                {
                    Pref.SetBool(dataKey, true); // trong Script Pref phần mình cài SetBool
                                                // nhân vật đầu tiên khi vào game dc mở khóa đầu tiên
                }
                else
                {
                    if (!PlayerPrefs.HasKey(dataKey))
                           Pref.SetBool(dataKey, false);             // nếu mà dữ liệu của player chưa dc lưu xuống máy ng dùng
                                        // kiểm tra dưới máy người dùng đã có dữ liệu cái dataKey chưa
                            
                }
            }
        }
    }
}
