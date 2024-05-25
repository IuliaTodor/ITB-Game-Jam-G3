using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Image playerWater;
    //[SerializeField] public Text playerWaterText;
    public static UIManager instance;

    public float currentWater;
    public float maxWater;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        UpdateCharacterUI();
    }

    private void UpdateCharacterUI()
    {
        playerWater.fillAmount = Mathf.Lerp(playerWater.fillAmount, currentWater / maxWater, 10f * Time.deltaTime);

        //playerWaterText.text = $"{currentWater}/{maxWater}";
    }

    public void UpdatePlayerHealth(float playerWater, float playerMaxWater)
    {
        //De esta forma los valores iniciales no son null
        currentWater = playerWater;
        maxWater = playerMaxWater;
    }

}
