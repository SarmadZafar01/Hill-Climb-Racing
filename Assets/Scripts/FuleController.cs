using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuleController : MonoBehaviour
{
    public static FuleController instance;

      
    [SerializeField] private Image fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float fuelDistance = 1f;
    [SerializeField] private float maxFuelAmount = 100f;
    [SerializeField] private Gradient fuelGradient;

    private float currentFuelAmount;


    private void Awake()
    {
        if( instance ==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentFuelAmount = maxFuelAmount;
        UpdateUI();

       
    }

    private void Update()
    {
        currentFuelAmount-= Time.deltaTime*fuelDistance;
        UpdateUI();

        if (currentFuelAmount <= 0f)
        {
            GameMangerScript.instance.gameover();
        }
    }


    void UpdateUI()
    {
        fuelImage.fillAmount = (currentFuelAmount / maxFuelAmount);
        fuelImage.color= fuelGradient.Evaluate(fuelImage.fillAmount);
    }


    public void FillFuel()
    {
        currentFuelAmount = maxFuelAmount;
        UpdateUI();
    }
}
