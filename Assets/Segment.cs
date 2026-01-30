using System;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [Header("Health")]
    public int maxhealth = 1;
    public int health = 1;
    public enum HealthState
    {
        Healthy,
        Damaged,
        Destroyed,
    };
    public HealthState healthState = HealthState.Healthy;
    [Header("Sprites")]
    public SpriteRenderer sr;
    public Sprite healthySprite;
    public Sprite damagedSprite;
    public Sprite destroyedSprite;
    public bool damageTrigger = false;
    public Blood bloodEffect;

    void OnValidate()
    {
        if (damageTrigger)
        {
            damageTrigger = false;
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // bloodEffect.PlayBloodEffect(transform.position, health <= 0);
        bloodEffect.PlayBloodEffect(transform.position, false);
        if (health < maxhealth && health > 0)
        {
            Damage();
        }
        else
        if (health <= 0)
        {
            Destroy();
        }
    }


    public void Damage()
    {
        healthState = HealthState.Damaged;
        // change sprite
        sr.sprite = damagedSprite;
        // add blood fx
        // play sound fx
    }

    public void Destroy()
    {
        healthState = HealthState.Destroyed;
        sr.sprite = destroyedSprite;
    }
}
