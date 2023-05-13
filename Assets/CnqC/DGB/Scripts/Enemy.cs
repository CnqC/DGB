using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public class Enemy : MonoBehaviour

{
    public float speed;
    public float atkDistance; // khoảng cách mà enemy tấn công player

    
    private Player m_player;
    private Animator m_anim;
    private Rigidbody2D m_rb; // để những con quái di chuyển tới con hero thì phải thay đổi vận tốc của nó 

    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_rb = GetComponent<Rigidbody2D>();

        m_player = FindObjectOfType<Player>();
        // tìm kiếm trên gameScence của chúng ta có 1 đói tượng game tên là Player, và gán giá trị đó cho m_player
        // ý là truy cập tới nhân vật hiện đang có trên scence  ở ngoài Hierachy ở Unity
        // vào truy cập tới phần script của player được add vào nhân vật đó
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rb == null || m_player == null) return;  // nếu mà rb khác rỗng thì sẽ thay đổi vận tốc hoặc biến m_player = rỗng thì return lại toàn bộ câu lệnh bên dưới
           
       
           
        
        // kiểm tra khoảng cách giữa 2 vector của 2 vị trí của con nhân vật và con quái có bằng cái khoảng cách atkDistance không ( ý là có tới vị trí cho sẳn để chuyển sang tấn công hay chưa)
        if(Vector2.Distance(m_player.transform.position,transform.position) <= atkDistance)
        {
            // nếu mà vị trí nó nhỏ hơn atkDistance thì cho con quái vật chuyển thành vị trí tấn công
           
            m_anim.SetBool(Const.ATTACK_ANIM, true); // chuyển thành tấn công trong animator

            //dừng di chuyển con enemy lại
            m_rb.velocity = Vector2.zero; // tọa độ 0,0 --> vận tốc về 0
        }
        else
        {
            m_rb.velocity = new Vector2(-speed, m_rb.velocity.y); // giá trị y giữ nguyên giá trị của Rg2D ý là lực hút trái đất
        }
    }
}
