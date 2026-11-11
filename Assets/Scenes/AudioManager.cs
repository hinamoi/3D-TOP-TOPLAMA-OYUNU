using UnityEngine;  // Unity'nin hazır özelliklerini kullanabilmek için ekledim.
public class AudioManager : MonoBehaviour // Oyundaki sesleri yönetmek için bu scripti oluşturdum.


{
    public static AudioManager instance; // Ses yöneticisine diğer scriptlerden de ulaşabilmek için kullandım.


    [SerializeField] private AudioSource sfxSource; // Efekt seslerini çalmak için kullandım.
    [SerializeField] private AudioSource musicSource;// Arka plan müziğini çalmak için kullandım.

    [SerializeField] private AudioClip PositiveCoinSound;  // Yeşil topa temas edildiğinde çalacak sesi ekledim.
    [SerializeField] private AudioClip NegativeCoinSound; // Kırmızı topa temas edildiğinde çalacak sesi ekledim.
    [SerializeField] private AudioClip jumpSound; //Karakter zıpladığında çalacak sesi ekledim.
    [SerializeField] private AudioClip backgroundMusic; // Oyunun arka plan müziğini ekledim.

    private void Awake()
    {
        instance = this; // AudioManager'ın diğer scriptlerden kullanılabilmesini sağladım.
    } 

    void Start()
    {
        musicSource.clip = backgroundMusic; // Arka plan müziğini müzik kaynağına atadım.
        musicSource.loop = true; // Müziğin sürekli tekrar etmesini sağladım.
        musicSource.Play(); // Oyun başladığında arka plan müziğini başlattım.
    }

    public void PlayGreenBallSound()
    {
        sfxSource.PlayOneShot(PositiveCoinSound); // Yeşil topa temas edildiğinde olumlu sesi çaldırdım.
    }

    public void PlayRedBallSound()
    {
        sfxSource.PlayOneShot(NegativeCoinSound); // Kırmızı topa temas edildiğinde olumsuz sesi çaldırdım.
    }

    public void PlayjumpSound()
    {
        sfxSource.PlayOneShot(jumpSound); // Karakter zıpladığında zıplama sesini çaldırdım.
    }

    void Update()
    {
        // Bu bölümde sürekli kontrol edilmesi gereken bir işlem olmadığı için boş bıraktım.
    }
}