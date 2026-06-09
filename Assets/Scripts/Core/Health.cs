using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    private Death Death;
    private GameManager gameManager;
    public Image HealthFiller;
    public TextMeshProUGUI HealthText;
    public float CurrentHealth = 100;
    public float MaxHealth = 100;
    public bool Main = false;

    void Start()
    {
        Death = GetComponent<Death>();
        gameManager = GameObject.FindFirstObjectByType<GameManager>();
    }

    public virtual bool IsAlive()
    {
        return CurrentHealth > 0.0f;
    }

    public virtual void InflictDamage(float Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth < 0.0f)
        {
            CurrentHealth = 0.0f;
        }
        if (Main)
        {
            HealthText.text = "HEALTH: " + CurrentHealth.ToString() + " / " + MaxHealth.ToString();
            HealthFiller.fillAmount = CurrentHealth/MaxHealth;
        }
        if (CurrentHealth == 0.0f)
        {
            if (gameObject.name == "Player" && gameManager.Lives > 0)
            {
                gameManager.RemoveLife();
                CurrentHealth = MaxHealth;
            }
            else if (Death != null)
            {
                Death.Die();
            }

            
        }
    }

    public virtual void InflictHeal(float Heal)
    {
        CurrentHealth += Heal;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }


}
