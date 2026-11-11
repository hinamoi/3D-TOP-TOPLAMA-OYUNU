using UnityEngine; // Unity'nin hazır özelliklerini kullanabilmek için ekledim.
using TMPro; // Ekranda puanı gösterebilmek için TextMeshPro kütüphanesini ekledim.

public class PlayerController : MonoBehaviour // Oyuncunun hareketlerini ve kontrollerini sağlamak için bu scripti oluşturdum.
{
    [SerializeField] private float moveSpeed = 10f; // Oyuncunun hareket hızını 10 olarak belirledim.
    [SerializeField] private float jumpForce = 5f; // Oyuncunun zıplama gücünü 5 olarak belirledim.

    private Rigidbody rb; // Oyuncunun fizik kurallarına göre hareket etmesini sağlamak için Rigidbody tanımladım.
    private bool isGrounded = false; // Oyuncunun yerde olup olmadığını kontrol etmek için kullandım.

    private float horizontal; // Oyuncunun sağa ve sola hareketini kontrol etmek için kullandım.
    private float vertical; // Oyuncunun ileri ve geri hareketini kontrol etmek için kullandım.

    public int Score = 0; // Oyuncunun puanını başlangıçta 0 olarak belirledim.
    [SerializeField] private TextMeshProUGUI scoreText; // Oyuncunun puanını ekranda göstermek için TextMeshPro ekledim.

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Oyuncunun üzerindeki Rigidbody bileşenini aldım.
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // A ve D veya sağ ve sol yön tuşlarıyla hareket edilmesini sağladım.
        vertical = Input.GetAxisRaw("Vertical"); // W ve S veya ileri ve geri yön tuşlarıyla hareket edilmesini sağladım.

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Boşluk tuşuna basıldığında ve oyuncu yerdeyse zıplamasını sağladım.
        {
            Jump(); // Zıplama işlemini gerçekleştirmek için Jump metodunu çağırdım.
        }
    }

    private void FixedUpdate()
    {
        Movement(); // Fizik tabanlı hareket işlemlerinin düzenli şekilde çalışmasını sağladım.
    }

    private void Movement()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical); // Oyuncunun sağa, sola, ileri ve geri hareket yönünü belirledim.

        direction = direction.normalized; // Çapraz hareketlerde oyuncunun daha hızlı gitmesini engelledim.

        rb.AddForce(direction * moveSpeed); // Oyuncunun belirlediğim hızda hareket etmesini sağladım.
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Oyuncuya yukarı doğru ani bir kuvvet uygulayarak zıplamasını sağladım.

        isGrounded = false; // Oyuncu zıpladığı anda yerde olmadığını belirttim.
        print("Zıpladın!"); // Zıplama gerçekleştiğinde konsola mesaj yazdırdım.
    }

    private void UpdateScoreUi()
    {
        scoreText.text = "Score : " + Score.ToString(); // Oyuncunun güncel puanını ekranda göstermesini sağladım.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Oyuncunun Ground etiketli zemine temas edip etmediğini kontrol ettim.
        {
            isGrounded = true; // Oyuncu yere değdiğinde tekrar zıplayabilmesini sağladım.
            Debug.Log("Yerdesin!"); // Yere temas edildiğinde konsola mesaj yazdırdım.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GreenBall")) // Oyuncunun yeşil topa temas edip etmediğini kontrol ettim.
        {
            Score += 10; // Yeşil top toplandığında oyuncunun puanına 10 ekledim.
            UpdateScoreUi(); // Puan arttıktan sonra ekrandaki puanı güncelledim.
            Debug.Log("GreenBall! Score" + Score); // Yeşil top toplandığında güncel puanı konsola yazdırdım.
            Destroy(other.gameObject); // Toplanan yeşil topun sahneden silinmesini sağladım.
        }
        else if (other.CompareTag("RedBall")) // Oyuncunun kırmızı topa temas edip etmediğini kontrol ettim.
        {
            Score -= 5; // Kırmızı topa temas edildiğinde oyuncunun puanından 5 çıkardım.
            UpdateScoreUi(); // Puan azaldıktan sonra ekrandaki puanı güncelledim.
            Debug.Log("RedBall! Score" + Score); // Kırmızı topa temas edildiğinde güncel puanı konsola yazdırdım.
            Destroy(other.gameObject); // Temas edilen kırmızı topun sahneden silinmesini sağladım.
        }
    }
}