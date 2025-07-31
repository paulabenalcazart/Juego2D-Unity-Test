using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerJumpForce = 20f;
    public float playerSpeed = 5f;
    public Sprite[] mySprites;
    private int index = 0;

    public GameManager myGameManager;
    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;
    public GameObject Ball;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRutine());

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Este salta con la barra espaciadora
            myrigidbody2D.linearVelocity = new Vector2(myrigidbody2D.linearVelocity.x, playerJumpForce);
        }
        // La velocidad en la que tiene que avanzar y el eje, este avanza
        myrigidbody2D.linearVelocity = new Vector2(playerSpeed, myrigidbody2D.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Ball, transform.position, Quaternion.identity);
        }
    }

    IEnumerator WalkCoRutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 6)
        {
            index = 0;
        }
        StartCoroutine(WalkCoRutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
            // Aquí podrías agregar lógica para manejar la colisión con un objeto malo
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
    
