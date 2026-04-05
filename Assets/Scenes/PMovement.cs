using UnityEngine;

public class PMovement : MonoBehaviour
{
    public bool isAI = false;
    public float aiSmoothing = 0.1f;
    private float yVelocity = 0f;
    public bool isPlayer2 = false; // P1 W/S, P2 Panah Atas/Bawah
    public float speed = 10f;

    // Referensi ke bola buat AI
    public Transform ball;

    private float input;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (isAI)
        {
            MoveAsAI();
        }
        else
        {
            MoveAsPlayer();
        }

    }

    void MoveAsPlayer()
    {
        input = 0;

        if (!isPlayer2)
        {
            // Player 1: W dan S
            if (Input.GetKey(KeyCode.W)) input = 1;
            if (Input.GetKey(KeyCode.S)) input = -1;
        }
        else
        {
            // Player 2: Panah Atas dan Bawah
            if (Input.GetKey(KeyCode.UpArrow)) input = 1;
            if (Input.GetKey(KeyCode.DownArrow)) input = -1;
        }

        rb.linearVelocity = new Vector2(0, input * speed);

    }

    void LateUpdate()
    {
        // Contoh membatasi posisi Y paddle antara -3.9 sampai 3.9
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 4f), 0);
    }

    void MoveAsAI()
    {

        if (ball != null)
        {
            // AI nggak ngejar posisi bola secara presisi, tapi ada delay-nya
            float targetY = Mathf.SmoothDamp(transform.position.y, ball.position.y, ref yVelocity, aiSmoothing);

            // Terapkan posisi baru
            transform.position = new Vector3(transform.position.x, targetY, 0);
        }
    }
}
