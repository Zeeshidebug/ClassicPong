
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {
        // Tentukan arah acak ke kanan atau kiri
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        // Tentukan arah acak ke atas atau bawah biar gak lurus doang
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector2 direction = new Vector2(x, y);
        rb.linearVelocity = direction * speed;
    }

    // Fungsi ini buat reset bola ke tengah kalau ada yang skor
    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek kalau nabrak tembok (kasih tag "Wall" ke objek tembok atas & bawah)
        if (collision.gameObject.CompareTag("Tembok"))
        {
            // Kita paksa speed-nya tetap sama dengan nilai variabel 'speed'
            // .normalized itu buat ambil arahnya aja, terus dikali speed awal
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }

        // Kalau nabrak Player (Paddle), speed nambah dikit biar seru
        if (collision.gameObject.CompareTag("Player"))
        {
            speed += 0.5f; // Naikin base speed
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }
    }
}
