using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthSystem 
{
    [SerializeField] int maxHealth;
    [SerializeField] int currHealth;

    public void TakeDamage(int amount) { currHealth = Mathf.Clamp(currHealth - amount, 0, maxHealth); }
    public void FullHeal() { currHealth = maxHealth; }
    public void SetHealth(int health) { maxHealth = currHealth = health; }
    public void SetCurrentHealth(int health) { currHealth = health; }
}
