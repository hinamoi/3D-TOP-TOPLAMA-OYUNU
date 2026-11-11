    using UnityEngine; // Unity'nin hazır özelliklerini kullanabilmek için ekledim.
    using TMPro; // Ekranda puanı yazdırabilmek için TextMeshPro kütüphanesini ekledim.

    public class ScoreManager : MonoBehaviour // Oyundaki puan sistemini yönetmek için bu scripti oluşturdum.
    {
        public static ScoreManager instance; // Puan sistemine diğer scriptlerden de ulaşabilmek için kullandım.

        [SerializeField] private TextMeshProUGUI scoreText; // Oyuncunun puanını ekranda gösterebilmek için TextMeshPro ekledim.

        private int score = 0; // Oyuncunun puanını başlangıçta 0 olarak belirledim.

        private void Awake()
        {
            instance = this; // ScoreManager'a diğer scriptlerden ulaşılabilmesini sağladım.
        }

        private void Start()
        {
            UpdateScoreUI(); // Oyun başladığında puanın ekranda görünmesini sağladım.
        }

        public void AddScore(int amount) // Oyuncunun puanını artırmak için bu metodu oluşturdum.
        {
            score += amount; // Toplanan puanı mevcut puana ekledim.
            UpdateScoreUI(); // Puan arttıktan sonra ekrandaki puanın güncellenmesini sağladım.
        }

        public void RamoveScore(int amount) // Oyuncunun puanını azaltmak için bu metodu oluşturdum.
        {
            score -= amount; // Kaybedilen puanı mevcut puandan çıkardım.

            if (score < 0) // Puanın sıfırın altına düşüp düşmediğini kontrol ettim.
            {
                score = 0; // Puanın sıfırın altına düşmesini engelledim.
            }

            UpdateScoreUI(); // Puan azaldıktan sonra ekrandaki puanı güncelledim.
        }

        public int GetScore() // Oyuncunun mevcut puanını diğer scriptlere göndermek için kullandım.
        {
            return score; // Mevcut puanı geri döndürdüm.
        }

        private void UpdateScoreUI()
        {
            scoreText.text = "Score: " + score; // Oyuncunun güncel puanını ekranda Score yazısıyla gösterdim.
        }
    }