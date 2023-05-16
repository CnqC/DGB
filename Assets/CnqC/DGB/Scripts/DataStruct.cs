using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

// định nghĩa các dữ liệu cấu trúc trong game của chúng ta

[System.Serializable]
public class ShopItem
{
   
    public Player playerPrefab;
    public int price; // giá mua con nhân vật đó
    public Sprite previewImage; // hình ảnh nhân vật
}

// Vì khi ta sử dụng 1 lớp khác để chứa các thông tin và ta lại tạo 1 lớp khác để xử lý thông tin dựa trên các thông số của lớp này
// thì t phải sử dung tiện ích [ System.Serializable] để nó hiện ra các thông tin của class ta muốn ra inspector