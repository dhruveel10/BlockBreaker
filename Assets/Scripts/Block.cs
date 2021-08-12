using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleEffect;
    Level level;
    [SerializeField] int numberOfHits;
    [SerializeField] Sprite[] spriteHits;  

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int spriteIndex;
        int maxHits = spriteHits.Length + 1;
        if(tag == "Breakable")
        {
            numberOfHits++;
            if (numberOfHits >= maxHits)
            {
                FindObjectOfType<GameStatus>().AddToScore();
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                Destroy(gameObject);
                level.BlockDestroyed();
                TriggerVFX();
            }    
            else
            {
                spriteIndex = numberOfHits -1;
                GetComponent<SpriteRenderer>().sprite = spriteHits[spriteIndex];    
            }
        }
         
    }

    private void TriggerVFX()
    {
        GameObject sparkles = Instantiate(particleEffect, transform.position, transform.rotation);
    }
}
