using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Images")]
    public Image frontBar;
    public Image backBar;
    public Image damageEffect;

    [Header("Colors")]
    public Color red;
    public Color green;

    [Header("Values")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f; 
    public float duration;
    public float fadeSpeed;

    private float health;
    private float lerpTimer;
    private float durationTimer;

    private AudioManager audio;
    private SceneControl scene;
    void Start()
    {
        audio = FindAnyObjectByType<AudioManager>();
        scene = FindAnyObjectByType<SceneControl>();
        health = maxHealth;
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, 0f);
    }
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if(damageEffect.color.a > 0)
        {
            if (health < 30f)
                return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                float tempAlpha = damageEffect.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, tempAlpha);
            }
        }
    }
    public void UpdateHealthUI()
    {
        float fillF = frontBar.fillAmount;
        float fillB = backBar.fillAmount;
        float hFraction = health / maxHealth;
        if(fillB > hFraction)
        {
            frontBar.fillAmount = hFraction;
            backBar.color = red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if(fillF < hFraction)
        {
            backBar.fillAmount = hFraction;
            backBar.color = green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontBar.fillAmount = Mathf.Lerp(fillF, backBar.fillAmount, percentComplete);
        }
    }
    public void Dead()
    {
        scene.ChangeScene("Main");
    }
    public void TakeDamage(float damage)
    {
        audio.PlaySoundEffect(audio.TakeDamage);
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0f;
        damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, 1);

        if(health <= 0)
        {
            Dead();
        }
    }
    public void RestoreHealth(float healAmount)
    {
        audio.PlaySoundEffect(audio.RestoreHealth);
        health += healAmount;
        lerpTimer = 0f;
    }
}
