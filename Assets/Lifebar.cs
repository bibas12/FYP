using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public int maxLife = 100;
    public int damagePerMiss = 20;
    public int healPerHit = 10;
    private int currentLife;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        currentLife = maxLife;
        slider.maxValue = maxLife;
        slider.value = maxLife;
    }

    public void HitNote()
    {
        currentLife = Mathf.Clamp(currentLife + healPerHit, 0, maxLife);
        slider.value = currentLife;
    }

    public void MissNote()
    {
        currentLife = Mathf.Clamp(currentLife - damagePerMiss, 0, maxLife);
        slider.value = currentLife;
    }
}
