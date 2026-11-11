using UnityEditor; // Unity editör özelliklerini kullanabilmek için ekledim.
using UnityEngine; // Unity'nin hazır özelliklerini kullanabilmek için ekledim.

public class LevelExit : MonoBehaviour // Oyuncunun seviyeyi geçmesini kontrol etmek için bu scripti oluşturdum.
{
    [SerializeField] private int requiredScore = 50; // Seviyeyi geçebilmek için gereken puanı 50 olarak belirledim.

    [SerializeField] private ScoreManager scoreManager; // Oyuncunun puanını kontrol edebilmek için ScoreManager scriptini ekledim.
    [SerializeField] private SceneController sceneController; // Seviye geçişlerini yapabilmek için SceneController scriptini ekledim.

    private void OnTriggerEnter(Collider other) // Oyuncu belirlediğim alana girdiğinde çalışmasını sağladım.
    {
        if (other.CompareTag("Player")) // Alana giren nesnenin Player olup olmadığını kontrol ettim.
        {
            Debug.Log("ScoreManager: " + scoreManager); // ScoreManager bağlantısının doğru olup olmadığını kontrol etmek için konsola yazdırdım.

            if (scoreManager.GetScore() >= requiredScore) // Oyuncunun puanının gereken 50 puana eşit veya fazla olup olmadığını kontrol ettim.
            {
                Debug.Log("Yeterli paranız var. Seviyeyi geçtiniz!"); // Yeterli puana ulaşıldığında ekrana mesaj yazdırdım.
                sceneController.NextScene(); // Yeterli puan varsa sonraki seviyeye geçmesini sağladım.
            }

            else // Eğer oyuncunun puanı yeterli değilse bu bölüm çalışıyor.
            {
                Debug.Log("Yeterli paranız yok. Yeniden deneyin!"); // Puan yeterli olmadığında oyuncuya uyarı mesajı verdim.
            }
        }
    }
}