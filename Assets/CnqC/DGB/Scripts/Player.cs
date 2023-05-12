using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float atkRate;

    private float m_curAtkRate; // lưu lại giá trị của biến atkRate và giảm dần theo thời gian
    private bool m_isAttacked; // ktra xem đã tấn công chưa
    private Animator m_anim;

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_curAtkRate = atkRate; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !m_isAttacked) // thêm sự kiện là nhân vật chỉ ấn được chuột khi nó đang k ở trạng thái Attack
        {
            if (m_anim)
                m_anim.SetBool(Const.ATTACK_ANIM, true);
            m_isAttacked = true; // người choi đã bấm nút tấn công rồi
        }

        if (m_isAttacked) // isAttacked == true
        {
           
           m_curAtkRate -= Time.deltaTime; // giảm dần thời gian bằng khoảng thời gian giữa 2 frame

            if(m_curAtkRate <=0)
            {
                m_isAttacked = false; // gán lại thành chưa tấn công

                m_curAtkRate = atkRate; // gán lại giá trị của curAtkRate = atkRate ban đầu
            }
        }


    }

    public void ResetAtkAnim()
    {
        if (m_anim)
            m_anim.SetBool(Const.ATTACK_ANIM, false);
    }
}
