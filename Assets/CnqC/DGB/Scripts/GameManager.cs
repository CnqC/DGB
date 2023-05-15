﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
public class GameManager : MonoBehaviour // tự động tạo ra các con quái
{
    public float spawnTime; // thời gian để tạo ra quái
    public Enemy[] enemyPrefabs; // tập hợp các con quái trong Prefabs

    private bool m_isGameOver;

    // Start is called before the first frame update
    void Start()
    {

        // để gọi 1 Coroutine thì ta phải gọi

        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
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
}