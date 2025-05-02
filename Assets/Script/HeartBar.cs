using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    [SerializeField] private Base baseHp;
    [SerializeField] private Image healthBarFill;      // Image ที่ใช้เป็นแถบเลือด

    private void Update()
    {
        float hpPercent = baseHp.currestHp / baseHp.baseHp;
        healthBarFill.fillAmount = hpPercent;
    }
}
