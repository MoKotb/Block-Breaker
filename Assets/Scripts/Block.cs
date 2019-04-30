﻿using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    private Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlocks();
    }

    private void DestroyBlocks()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlocksDestroyed();
    }
}