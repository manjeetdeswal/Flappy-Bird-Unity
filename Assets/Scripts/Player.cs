using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private Vector3 direction;
    public float streangth = 5f;
    public float Gravity = -9.8f;
    private SpriteRenderer sprite;
    public Sprite[] sprites;
    private int indexSPrite=0;
    public AudioSource audioSource;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }


   private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        audioSource.Play();

    }

    private void OnEnable()
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
        direction = Vector3.zero;
    }
    private void AnimateSprite()
    {
        
        if(indexSPrite >= sprites.Length)
        {
            indexSPrite = 0;
        }

        indexSPrite++;
        Debug.Log(indexSPrite);
      //  sprite.sprite = sprites[indexSPrite];

        if (indexSPrite < sprites.Length && indexSPrite >= 0)
        {
            sprite.sprite = sprites[indexSPrite];
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up   * streangth;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * streangth;
            }
        }
        direction.y += Gravity * Time.deltaTime;

        transform.position += direction * Time.deltaTime;




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            FindObjectOfType<GameManger>().GameOver();
        }
        else if (collision.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManger>().IncreaseSc();
        }
    }
}
