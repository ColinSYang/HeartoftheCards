using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    public Image pCooldownImage;

    public Image pLockImage;

    public Image pDashImage;


    static Image cooldownImage;
    
    static Image lockImage;
    
    static Image dashImage;

    void Start()
    {
        cooldownImage = pCooldownImage;
        lockImage = pLockImage;
        dashImage = pDashImage;
        lockImage.enabled = false;
    }

    public static void UpdateCooldown(float time, float cooldown)
    {
        if (time >= cooldown)
        {
            cooldownImage.fillAmount = 0;
            lockImage.enabled = false;
            var fadeImageColor = dashImage.color;
            fadeImageColor.a = 1f;
            dashImage.color = fadeImageColor;
        }
        else
        {
            float amount = (time / cooldown);
            cooldownImage.fillAmount = amount;
            lockImage.enabled = true;
            var fadeImageColor = dashImage.color;
            fadeImageColor.a = 0.4f;
            dashImage.color = fadeImageColor;
        }
    }
}
