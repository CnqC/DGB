using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CnqC.DGB
{
    public class Player : MonoBehaviour, IcomponentChecking
    {
        public float atkRate;


        private bool m_isDead; // ktr là nhân vật đã chết và enemy dừng đánh
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

        public bool IscomponentNull()
        {
            return m_anim == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (IscomponentNull()) return;

            if (Input.GetMouseButtonDown(0) && !m_isAttacked) // thêm sự kiện là nhân vật chỉ ấn được chuột khi nó đang k ở trạng thái Attack
            {
               
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true; // người choi đã bấm nút tấn công rồi
            }

            if (m_isAttacked) // isAttacked == true
            {

                m_curAtkRate -= Time.deltaTime; // giảm dần thời gian bằng khoảng thời gian giữa 2 frame

                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false; // gán lại thành chưa tấn công

                    m_curAtkRate = atkRate; // gán lại giá trị của curAtkRate = atkRate ban đầu
                }
            }


        }

        public void ResetAtkAnim()
        {
            if (IscomponentNull()) return;
                m_anim.SetBool(Const.ATTACK_ANIM, false);
        }

        // Bắt va chạm trigger của vũ khí enemy với lại nhân vật
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IscomponentNull()) return;
            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_isDead ) // so sánh xem là có tag nào mà enemy nó va chạm có tên là Enemy weapon không, nếu có thì chạy 
            {
                m_anim.SetTrigger(Const.DEAD_ANIM); // xử lý va chạm trigger giữa player với lại EnemyWeapon --> chuyển thành animation Dead
                m_isDead = true; 
            }
        }
    }
} 