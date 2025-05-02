using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    [SerializeField] private Base baseHp;
    [SerializeField] private Image healthBarFill;      // Image �������ᶺ���ʹ

    private void Update()
    {
        float hpPercent = baseHp.currestHp / baseHp.baseHp;
        healthBarFill.fillAmount = hpPercent;
    }
}
