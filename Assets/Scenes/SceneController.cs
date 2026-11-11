using UnityEngine; // Unity'nin hazır özelliklerini kullanabilmek için ekledim.
using System; // C# dilinin temel özelliklerini kullanabilmek için ekledim.
using unitySceneManager = UnityEngine.SceneManagement.SceneManager; // Sahne geçişlerini daha kolay yapabilmek için SceneManager'a kısa bir isim verdim.

public class SceneController : MonoBehaviour // Oyundaki sahne geçişlerini kontrol etmek için bu scripti oluşturdum.
{
    public void NextScene() // Bir sonraki seviyeye geçmek için bu metodu oluşturdum.
    {
        int currentSceneIndex = unitySceneManager.GetActiveScene().buildIndex; // Şu anda oynanan sahnenin sırasını öğrendim.
        int nextSceneIndex = currentSceneIndex + 1; // Bir sonraki sahnenin sırasını bulmak için mevcut sahne numarasına 1 ekledim.

        if (nextSceneIndex < unitySceneManager.sceneCountInBuildSettings) // Bir sonraki sahnenin mevcut olup olmadığını kontrol ettim.
        {
            unitySceneManager.LoadScene(nextSceneIndex); // Sonraki sahne varsa o sahneye geçiş yaptım.
        }
        else // Eğer başka sahne kalmadıysa bu bölüm çalışıyor.
        {
            Debug.Log("Oyunu Bitirdiniz!"); // Oyunun bittiğini konsola yazdırdım.
        }
    }

    public void RestartScene() // Oyuncunun bulunduğu bölümü yeniden başlatabilmesi için bu metodu oluşturdum.
    {
        int currentSceneIndex = unitySceneManager.GetActiveScene().buildIndex; // İçinde bulunduğum sahnenin numarasını aldım.
        unitySceneManager.LoadScene(currentSceneIndex); // Aynı sahneyi tekrar yükleyerek bölümü baştan başlattım.
    }

    internal void LoadNextScene() // Diğer kodlardan bir sonraki sahneye geçiş yapabilmek için bu metodu oluşturdum.
    {
        NextScene(); // NextScene metodunu çağırarak sonraki seviyeye geçiş yaptım.
    }
}