using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(Const.ENEMY_TAG))
        {
            Enemy enemy = col.GetComponent<Enemy>(); // tạo một biến enemy bằng biến va chạm truy cập, lấy vào Script Enemy gán cho giá trị biến enemy

            if (enemy)
                enemy.Die();
        }
    }
}
