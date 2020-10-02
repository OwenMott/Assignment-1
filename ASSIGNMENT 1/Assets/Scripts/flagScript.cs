using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagScript : MonoBehaviour
{

    public GameObject smallExplosion;
    SpriteRenderer spriteRen;
    public Sprite flag2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag(gameObject.tag))
        {
            //Debug.Log("Hitself");

        }
        else
        {
            //Debug.Log("gottem lol");
            //change sprite

            spriteRen.sprite = flag2;
            Instantiate(smallExplosion, gameObject.transform.position, Quaternion.identity);
            GameManager.flagDestroyed();
        }
    }
}
