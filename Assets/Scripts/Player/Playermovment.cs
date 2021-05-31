using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{

    public float movespeed = 5f;

    public bool Grounded = false;

    PlayerState playerState = PlayerState.Playable;

    Vector3 m_velocity = Vector3.zero;

    [SerializeField]
    Collider2D TriggerCollider;

    [SerializeField]
    Color flashColor;
    Color regularColor = Color.white;

    [SerializeField]
    int numberOfFlashes = 4;

    [SerializeField]
    LayerMask enemiesMask;

    [SerializeField]
    LayerMask pitFallMask;

    [SerializeField]
    LayerMask tokenMask;

    [SerializeField]
    intVariableObject healthObject;

    [SerializeField]
    GameEvent DeathEvent;

    [SerializeField]
    Vector2 lastGroundStanded;

    float saveDelay = 0.5f;
    float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
        if (playerState == PlayerState.Playable)
        {
            if (Input.GetButtonDown("Jump") && Grounded == true)
                Jump();

            if (Input.GetButtonUp("Jump") && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y * 0.5f);
        }

        if (Grounded && timePassed > saveDelay)
        {
            lastGroundStanded = transform.position + Vector3.up;
            timePassed = 0f;
        }   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerState == PlayerState.Playable)
        {
            if (Input.GetAxis("Horizontal") != 0f)
                Move();
        }
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
    }

    void Move()
    {
        flipSprite();
        Vector3 movment = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * movespeed, gameObject.GetComponent<Rigidbody2D>().velocity.y, 0f);
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.SmoothDamp(gameObject.GetComponent<Rigidbody2D>().velocity, movment, ref m_velocity, 0.05f);
    }

    protected void flipSprite()
    {
        if (Input.GetAxis("Horizontal") > 0f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void getHit(Transform other)
    {
        healthObject.minusValue(1);
        if (healthObject.Value == 0)
            killPlayer();

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Vector2 knockbackDirection = new Vector2(transform.position.x - other.position.x, 1f).normalized;
        gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * 5, ForceMode2D.Impulse);
        StartCoroutine(knockBack());
    }

    void respawn()
    {
        StartCoroutine(knockBack());
        transform.position = lastGroundStanded;
        healthObject.minusValue(1);
        if (healthObject.Value == 0)
            killPlayer();
    }

    void killPlayer()
    {
        Destroy(gameObject);
        DeathEvent.Raise();
    }

    IEnumerator knockBack()
    {
        TriggerCollider.enabled = false;
        playerState = PlayerState.UnPlayable;
        Transform child = gameObject.transform.Find("GFX");
        for(int i = 0; i < numberOfFlashes; i++)
        {
            child.GetComponent<SpriteRenderer>().color = flashColor;
            yield return new WaitForSeconds(0.1f);
            child.GetComponent<SpriteRenderer>().color = regularColor;
            yield return new WaitForSeconds(0.1f);
        }
        playerState = PlayerState.Playable;
        yield return new WaitForSeconds(1f);
        TriggerCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemiesMask.value & (1 << collision.gameObject.layer)) > 0)
            getHit(collision.transform);

        if ((tokenMask.value & (1 << collision.gameObject.layer)) > 0)
            collision.GetComponent<tokenController>().getToken();

        if ((pitFallMask.value & (1 << collision.gameObject.layer)) > 0)
            respawn();
    }
}

public enum PlayerState
{
    Playable,
    UnPlayable
}