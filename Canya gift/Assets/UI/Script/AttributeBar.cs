using UnityEngine;
using UnityEngine.UI;

public class AttributeBar : MonoBehaviour
{
    private Image attributeBar;
    public float currentValue;
    private float maxValue;

    public ValueBarData healthData;

    private void Start()
    {
        maxValue = healthData.maxValue;
        attributeBar = GetComponent<Image>();
       
    }

    private void Update()
    {
        currentValue = healthData.currentValue;
        
       attributeBar.fillAmount = currentValue / maxValue;
    }


}
