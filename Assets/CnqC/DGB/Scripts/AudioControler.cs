using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    [Header("Main Setting: ")] // đưa ra cho inspector 1 cái nhãn bên trên

    // VẼ 1 cái slider cho musicVolume
    [Range(0f,1f)] // vẽ 1 inspector 1 slider ( min, max)
    public float musicVol = 0.3f; // nhạc nền

    [Range(0f, 1F)]
    public float soundVol = 1f; // âm lượng

    public AudioSource musicAus; // nhạc nền ( audioSource điều khiển của AudioControler)
    public AudioSource soundAus; // tiếng động


    // gọi phương thức playSound( truyền 1 mảng âm thanh PlaySound(sounds), chúng ta k truyền vào audiosouce điều khiển
    // ta truyền màng âm thanh chư k phải audioSouce diều khiển bởi vì nếu như truyền AdiouS diều khiển mà ở ngoài còn có 1 AudioS điều khiển ở chỗ khác thì nó sẽ nhân AudioS ta truyền vào chứ k nhân cái AudioS của AudioControler.

    [Header("Music and Sound in GamePlay: ")]
    public AudioClip playerAtk;
    public AudioClip enemyDead;
    public AudioClip gameOver;
    public AudioClip[] Bgms; // phát ngẫu nhiên các bài nhạc trong mảng


    private void Start()
    {
        if (musicAus == null || soundAus == null || musicAus == null) ;

        musicVol = Pref.musicVol;
        soundVol = Pref.soundVol;

        musicAus.volume = musicVol;
        soundAus.volume = soundVol;

    }

    public void PlaySound(AudioClip[] sounds, AudioSource aus = null) // 1 mảng chứa file âm thanh
                                                   // giá trị ban đầu = null  
    {
        // phát ra âm thanh trong game

        if (!aus) // nếu mà aus = null
            aus = soundAus;

        if (aus == null) return;

        if (sounds == null || sounds.Length <= 0) return;

        int randIdx = Random.Range(0, sounds.Length);
        // lấy chỉ số ngẫu nhiên trong mảng()

        // ktra xem là phần từ sound ở vị trí randomIndex có null hay khong
        if (sounds[randIdx])  // nếu nó không null
            aus.PlayOneShot(sounds[randIdx], soundVol);  // phát hiệu ứng âm thanh trong game thì dùng PlayOneShot
                                            // đưa vào giá trị âm lượng
        // --> lấy ngẫu nhiên ra 1 sound trong 1 cái mảng và nó sẽ phát cái âm thanh đó lên.
    }

    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        
        if (!aus) // nếu mà aus = rỗng thì
            aus = soundAus;

        if (aus == null) return;

        if (sound)
            aus.PlayOneShot(sound,soundVol);
                            // đưa vào giá trị âm lượng 
    }


    public void PlayMusic(AudioClip [] musics, bool isLoop = true) // isLopp là muốn nhạc có lập lại hay k
    {
        if (musics == null|| musicAus == null || musics.Length <= 0) return;

        int randIdx = Random.Range(0, musics.Length);

        if (musics[randIdx])
        { // file music sẽ chứa ở trong component AudioScource
            // gán cái clip này = phần tử music ở vị trí randomIndex.
            musicAus.clip = musics[randIdx];
            musicAus.loop = isLoop; // có lặp lại hay không
            musicAus.volume = musicVol;  //gán volume cho audioScouce musicVol của AudioControler.
            musicAus.Play(); // chạy
        }
    }

    public void PlayMusic(AudioClip music, bool isLoop = true)
    {
        if (musicAus == null || music == null) return; // nếu mà music k được đưa vào hay cái musicAus == null thì off hết

        musicAus.clip = music;
        musicAus.loop = isLoop;
        musicAus.volume = musicVol;
        musicAus.Play();
    }

    public void SetMusicVolume(float vol)
    {
        if (musicAus == null) return;

        musicAus.volume = vol;

    }

    public void StopMusic()
    {
        if (musicAus == null) return;

        musicAus.Stop(); // dừng không phát ra âm thanh hay nhạc nữa
    }

    public void PlayBgm()
    {
        PlayMusic(Bgms);
    }
}
