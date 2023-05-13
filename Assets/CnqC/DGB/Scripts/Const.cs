using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

public class Const
{
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
    public const string PLAYER_PREFIX_PREF = "player_";
    public const string CUR_PLAYER_ID_PREF = "cur_player_id";
    public const string COINS_PREF         = "coins";

    // Tạo ra các hằng số lưu lại music, sound
    public const string MUSIC_VOL_PREF = "music_vol";
    public const string SOUND_VOL_PREF = "sound_vol";

}
