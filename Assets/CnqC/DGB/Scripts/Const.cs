using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public class Const
{
    // hằng là 1 biến lưu giá trị không thay đổi trong suốt chương trình
    // bắt buộc phải khởi tạo giá trị khi khai báo 

    // Tạo ra các hằng số cho TAG
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG  = "Enemy";
    public const string ENEMY_WEAPON_TAG = "EnemyWeapon";

    // Tạo ra các hằng số cho Animator
    public const string ATTACK_ANIM = "Attacking";
    public const string DEAD_ANIM   = "Dead";

    // Tạo ra các hằng số cho các Layer
    public const string DEAD_LAYER  = "Dead";
    public const string ENEMY_LAYER = "Enemy";
    public const string PLAYER_LAYER = "Player";

    // Tạo ra các hằng số cho các KEY của playerpref -- lưu vào xuống máy người dùng ( 4 key)
    public const string BEST_SCORE_PREF    = "best_score";
    public const string PLAYER_PREFIX_PREF = "player_";  // key của Shop
    public const string CUR_PLAYER_ID_PREF = "cur_player_id";
    public const string COINS_PREF         = "coins";

    // Tạo ra các hằng số lưu lại music, sound
    public const string MUSIC_VOL_PREF = "music_vol";
    public const string SOUND_VOL_PREF = "sound_vol";


    // định nghĩa cho các scence trong gamepLay

    public const string GAMEPLAY_SCENE = "GamePlay";
}
