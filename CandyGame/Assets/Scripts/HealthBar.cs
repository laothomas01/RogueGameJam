using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float health;
    private SpriteRenderer rend;
    public Object[] sprites;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll("healthbar");
    }

    void Update()
    {
        health = PlayerHealth.health;
        int i = (int)Mathf.Round((health - 1) * 10);
        rend.sprite = (Sprite)sprites[i + 1];
    }
}

