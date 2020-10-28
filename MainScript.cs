
using UnityEngine;
using UnityEngine.UI;
using System;
using BreakInfinity;
using static BreakInfinity.BigDouble;

[Serializable]
public class PlayerData
{
    //Main
    public BigDouble life;
    public BigDouble lifeClickValue;
    public BigDouble lifePerSecond;

    public BigDouble clickUpgrade1Cost;
    public BigDouble clickUpgrade2Cost;
    public BigDouble clickUpgrade3Cost;
    public BigDouble clickUpgrade4Cost;
    public BigDouble clickUpgrade5Cost;
    public BigDouble clickUpgrade6Cost;

    public BigDouble productionUpgrade1Cost;
    public BigDouble productionUpgrade2Cost;
    public BigDouble productionUpgrade3Cost;
    public BigDouble productionUpgrade4Cost;
    public BigDouble productionUpgrade5Cost;
    public BigDouble productionUpgrade6Cost;

    public BigDouble productionUpgrade1Power;
    public BigDouble productionUpgrade2Power;
    public BigDouble productionUpgrade3Power;
    public BigDouble productionUpgrade4Power;
    public BigDouble productionUpgrade5Power;
    public BigDouble productionUpgrade6Power;

    public int clickUpgrade1Level;
    public int clickUpgrade2Level;
    public int clickUpgrade3Level;
    public int clickUpgrade4Level;
    public int clickUpgrade5Level;
    public int clickUpgrade6Level;

    public int productionUpgrade1Level;
    public int productionUpgrade2Level;
    public int productionUpgrade3Level;
    public int productionUpgrade4Level;
    public int productionUpgrade5Level;
    public int productionUpgrade6Level;

    //Souls

    public BigDouble souls;
    public BigDouble soulsBoost;
    public BigDouble soulsToGet;

    public BigDouble darkSouls;
    public BigDouble lightSouls;

    public BigDouble clickMultiplier1;
    public BigDouble clickMultiplier2;

    public int clickMultiplier1Level;
    public int clickMultiplier2Level;

    public int productionMultiplier1Level;
    public int productionMultiplier2Level;


    public BigDouble productionMultiplier1;
    public BigDouble productionMultiplier2;

    public BigDouble clickMultiplier1Cost;
    public BigDouble clickMultiplier2Cost;

    public BigDouble productionMultiplier1Cost;
    public BigDouble productionMultiplier2Cost;


    public PlayerData()
    {
        FullReset();
    }

    public void FullReset()
    {
        life = 0;
        lifeClickValue = 1;

        souls = 0;
        soulsBoost = 1;
        soulsToGet = 0;

        darkSouls = 0;
        lightSouls = 0;

        clickUpgrade1Cost = 10;
        clickUpgrade2Cost = 25;
        clickUpgrade3Cost = 100;
        clickUpgrade4Cost = 250;
        clickUpgrade5Cost = 1000;
        clickUpgrade6Cost = 2500;

        productionUpgrade1Cost = 25;
        productionUpgrade2Cost = 75;
        productionUpgrade3Cost = 200;
        productionUpgrade4Cost = 350;
        productionUpgrade5Cost = 900;
        productionUpgrade6Cost = 1500;

        productionUpgrade1Power = 1;
        productionUpgrade2Power = 5;
        productionUpgrade3Power = 10;
        productionUpgrade4Power = 25;
        productionUpgrade5Power = 50;
        productionUpgrade6Power = 125;

        productionUpgrade1Level = 0;
        productionUpgrade2Level = 0;
        productionUpgrade3Level = 0;
        productionUpgrade4Level = 0;
        productionUpgrade5Level = 0;
        productionUpgrade6Level = 0;

        clickUpgrade1Level = 0;
        clickUpgrade2Level = 0;
        clickUpgrade3Level = 0;
        clickUpgrade4Level = 0;
        clickUpgrade5Level = 0;
        clickUpgrade6Level = 0;

        clickMultiplier1 = 1;
        clickMultiplier2 = 1;

        productionMultiplier1 = 1;
        productionMultiplier2 = 1;

        clickMultiplier1Cost = 500;
        clickMultiplier2Cost = 10000;

        productionMultiplier1Cost = 1000;
        productionMultiplier2Cost = 25000;
    }
}

public class MainScript : MonoBehaviour
{
    //Publics

    public PlayerData data;

    //MainTexts
    public Text lifeText;
    public Text lifePerSecText;
    public Text clickValueText;

    public Text soulsText;
    public Text soulsBoostText;
    public Text soulsToGetText;

    public Text clickUpgrade1Text;
    public Text clickUpgrade2Text;
    public Text clickUpgrade3Text;
    public Text clickUpgrade4Text;
    public Text clickUpgrade5Text;
    public Text clickUpgrade6Text;

    public Text productionUpgrade1Text;
    public Text productionUpgrade2Text;
    public Text productionUpgrade3Text;
    public Text productionUpgrade4Text;
    public Text productionUpgrade5Text;
    public Text productionUpgrade6Text;

    //SoulsTexts

    public Text darkSoulsText;
    public Text lightSoulsText;

    public Text clickMultiplier1Text;
    public Text clickMultiplier2Text;
    public Text productionMultiplier1Text;
    public Text productionMultiplier2Text;
    //other
    public int notationType;

    public static bool fullScreen;
    public GameObject MainScreen;
    public GameObject Settings;
    public GameObject DLScreen;

    //Start
    public void Start()
    {
        Application.targetFrameRate = 60;
        Screen.SetResolution(1920, 1080, true);
        Application.runInBackground = true;

        SaveSystem.LoadPlayer(ref data);
    }

    //Update
    public void Update()
    {
        data.lifePerSecond = (data.productionUpgrade1Level + (data.productionUpgrade2Power * data.productionUpgrade2Level) + (data.productionUpgrade3Power * data.productionUpgrade3Level) + (data.productionUpgrade4Power * data.productionUpgrade4Level) + (data.productionUpgrade5Power * data.productionUpgrade5Level) + (data.productionUpgrade6Power * data.productionUpgrade6Level)) * data.soulsBoost;

        //prestige
        data.soulsToGet = (150 * Sqrt(data.life / 5e5));
        data.soulsBoost = (data.souls * 0.03) + 1;
        soulsText.text = $"Souls: {Methods.NotationMethod(data.souls, "F0")}";
        soulsBoostText.text = $" +{Methods.NotationMethod(data.soulsBoost, "F2")}x Boost";
        soulsToGetText.text = $"SoulSiege:\n+{Methods.NotationMethod(data.soulsToGet, "F0")} souls";

        lifeText.text = $"Life: {Methods.NotationMethod(data.life, "F0")}";
        clickValueText.text = $"Click\n+{Methods.NotationMethod(data.lifeClickValue, "F0")} Life";
        lifePerSecText.text = $"{Methods.NotationMethod(data.lifePerSecond, "F0")} Life/s";

        //Main Upgrades
        clickUpgrade1Text.text = $"+1 Click\n{Methods.NotationMethod(data.clickUpgrade1Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade1Level * data.soulsBoost, "F0")}";
        clickUpgrade2Text.text = $"+5 Clicks\n{Methods.NotationMethod(data.clickUpgrade2Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade2Level * data.soulsBoost, "F0")}";
        clickUpgrade3Text.text = $"+15 Clicks\n{Methods.NotationMethod(data.clickUpgrade3Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade3Level * data.soulsBoost, "F0")}";
        clickUpgrade4Text.text = $"+25 Clicks\n{Methods.NotationMethod(data.clickUpgrade4Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade4Level * data.soulsBoost, "F0")}";
        clickUpgrade5Text.text = $"+75 Clicks\n{Methods.NotationMethod(data.clickUpgrade5Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade5Level * data.soulsBoost, "F0")}";
        clickUpgrade6Text.text = $"+200 Clicks\n{Methods.NotationMethod(data.clickUpgrade6Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.clickUpgrade6Level * data.soulsBoost, "F0")}";

        productionUpgrade1Text.text = $"+{Methods.NotationMethod(data.productionUpgrade1Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade1Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade1Level, "F0")}";
        productionUpgrade2Text.text = $"+{Methods.NotationMethod(data.productionUpgrade2Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade2Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade2Level, "F0")}";
        productionUpgrade3Text.text = $"+{Methods.NotationMethod(data.productionUpgrade3Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade3Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade3Level, "F0")}";
        productionUpgrade4Text.text = $"+{Methods.NotationMethod(data.productionUpgrade4Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade4Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade4Level, "F0")}";
        productionUpgrade5Text.text = $"+{Methods.NotationMethod(data.productionUpgrade5Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade5Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade5Level, "F0")}";
        productionUpgrade6Text.text = $"+{Methods.NotationMethod(data.productionUpgrade6Power * data.soulsBoost, "F0")} Production\n {Methods.NotationMethod(data.productionUpgrade6Cost, "F0")} Life\nLevel: {Methods.NotationMethod(data.productionUpgrade6Level, "F0")}";

        //souls
        darkSoulsText.text = $"Dark Souls: {Methods.NotationMethod(data.darkSouls, "F0")}";
        lightSoulsText.text = $"Light Souls: {Methods.NotationMethod(data.lightSouls, "F0")}";

        clickMultiplier1Text.text = $"x{Methods.NotationMethod(data.clickMultiplier1, "F2")} Click Boost\n {Methods.NotationMethod(data.clickMultiplier1Cost, "F0")} Dark Souls\nLevel: {Methods.NotationMethod(data.clickMultiplier1Level * data.soulsBoost, "F0")}";
        clickMultiplier2Text.text = $"x{Methods.NotationMethod(data.clickMultiplier2, "F2")} Click Boost\n {Methods.NotationMethod(data.clickMultiplier2Cost, "F0")} Dark Souls\nLevel: {Methods.NotationMethod(data.clickMultiplier2Level * data.soulsBoost, "F0")}";

        productionMultiplier1Text.text = $"x{Methods.NotationMethod(data.productionMultiplier1, "F2")} Production Boost\n {Methods.NotationMethod(data.productionMultiplier1Cost, "F0")} Light Souls\nLevel: {Methods.NotationMethod(data.productionMultiplier1Level * data.soulsBoost, "F0")}";
        productionMultiplier2Text.text = $"x{Methods.NotationMethod(data.productionMultiplier2, "F2")} Production Boost\n {Methods.NotationMethod(data.productionMultiplier2Cost, "F0")} Light Souls\nLevel: {Methods.NotationMethod(data.productionMultiplier2Level * data.soulsBoost, "F0")}";


        data.life += data.lifePerSecond * Time.deltaTime;
        SaveSystem.SavePlayer(data);
    }

    //fullscreen
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    //Prestige
    public void SoulSiege()
    {
        if (data.life >= 500)
        {

            data.life = 0;
            data.lifeClickValue = 1;

            data.clickUpgrade1Cost = 10;
            data.clickUpgrade2Cost = 25;
            data.clickUpgrade3Cost = 100;
            data.clickUpgrade4Cost = 250;
            data.clickUpgrade5Cost = 1000;
            data.clickUpgrade6Cost = 2500;
                                              
            data.productionUpgrade1Cost = 25;
            data.productionUpgrade2Cost = 75;
            data.productionUpgrade3Cost = 200;
            data.productionUpgrade4Cost = 350;
            data.productionUpgrade5Cost = 900;
            data.productionUpgrade6Cost = 1500;
            
            data.productionUpgrade2Power = 5;
            data.productionUpgrade3Power = 10;
            data.productionUpgrade4Power = 25;
            data.productionUpgrade5Power = 50;
            data.productionUpgrade6Power = 125;


            data.productionUpgrade1Level = 0;
            data.productionUpgrade2Level = 0;
            data.productionUpgrade3Level = 0;
            data.productionUpgrade4Level = 0;
            data.productionUpgrade5Level = 0;
            data.productionUpgrade6Level = 0;

            data.clickUpgrade1Level = 0;
            data.clickUpgrade2Level = 0;
            data.clickUpgrade3Level = 0;
            data.clickUpgrade4Level = 0;
            data.clickUpgrade5Level = 0;
            data.clickUpgrade6Level = 0;

            data.souls += data.soulsToGet;
        }
    }


    //Buttons
    public void Click()
    {
        data.life += data.lifeClickValue;
    }

    public void CollectSouls()
    {
        if (data.souls >= 10)
        {
            data.darkSouls += data.souls / 10;
            data.lightSouls += data.souls / 10;
        }
        SoulSiege();
        data.souls = 0;
        data.life = 0;
        data.lifeClickValue = 1;
    }
    public void BuyClickUpgrade1()
    {
        if (data.life >= data.clickUpgrade1Cost)
        {
            data.clickUpgrade1Level++;
            data.life -= data.clickUpgrade1Cost;
            data.clickUpgrade1Cost *= 1.07;
            data.lifeClickValue += 5;
        }
    }

    public void BuyClickUpgrade2()
    {
        if (data.life >= data.clickUpgrade2Cost)
        {
            data.clickUpgrade2Level++;
            data.life -= data.clickUpgrade2Cost;
            data.clickUpgrade2Cost *= 1.09;
            data.lifeClickValue += 5;
        }
    }

    public void BuyClickUpgrade3()
    {
        if (data.life >= data.clickUpgrade3Cost)
        {
            data.clickUpgrade3Level++;
            data.life -= data.clickUpgrade3Cost;
            data.clickUpgrade3Cost *= 1.11;
            data.lifeClickValue += 15;
        }
    }

    public void BuyClickUpgrade4()
    {
        if (data.life >= data.clickUpgrade4Cost)
        {
            data.clickUpgrade4Level++;
            data.life -= data.clickUpgrade4Cost;
            data.clickUpgrade4Cost *= 1.13;
            data.lifeClickValue += 25;
        }
    }
    public void BuyClickUpgrade5()
    {
        if (data.life >= data.clickUpgrade5Cost)
        {
            data.clickUpgrade5Level++;
            data.life -= data.clickUpgrade5Cost;
            data.clickUpgrade5Cost *= 1.15;
            data.lifeClickValue += 75;
        }
    }
    public void BuyClickUpgrade6()
    {
        if (data.life >= data.clickUpgrade6Cost)
        {
            data.clickUpgrade4Level++;
            data.life -= data.clickUpgrade6Cost;
            data.clickUpgrade6Cost *= 1.17;
            data.lifeClickValue += 200;
        }
    }

    public void BuyProductionUpgrade1()
    {
        if (data.life >= data.productionUpgrade1Cost)
        {
            data.productionUpgrade1Level++;
            data.life -= data.productionUpgrade1Cost;
            data.productionUpgrade1Cost *= 1.07;
        }
    }

    public void BuyProductionUpgrade2()
    {
        if (data.life >= data.productionUpgrade2Cost)
        {
            data.productionUpgrade2Level++;
            data.life -= data.productionUpgrade2Cost;
            data.productionUpgrade2Cost *= 1.09;
        }
    }

    public void BuyProductionUpgrade3()
    {
        if (data.life >= data.productionUpgrade3Cost)
        {
            data.productionUpgrade3Level++;
            data.life -= data.productionUpgrade3Cost;
            data.productionUpgrade3Cost *= 1.11;
        }
    }

    public void BuyProductionUpgrade4()
    {
        if (data.life >= data.productionUpgrade4Cost)
        {
            data.productionUpgrade4Level++;
            data.life -= data.productionUpgrade4Cost;
            data.productionUpgrade4Cost *= 1.13;
        }
    }

    public void BuyProductionUpgrade5()
    {
        if (data.life >= data.productionUpgrade5Cost)
        {
            data.productionUpgrade5Level++;
            data.life -= data.productionUpgrade5Cost;
            data.productionUpgrade5Cost *= 1.15;
        }
    }

    public void BuyProductionUpgrade6()
    {
        if (data.life >= data.productionUpgrade6Cost)
        {
            data.productionUpgrade6Level++;
            data.life -= data.productionUpgrade6Cost;
            data.productionUpgrade6Cost *= 1.17;
        }
    }


    public void BuyClickMulti1()
    {
        if (data.darkSouls >= data.clickMultiplier1Cost) 
        {
            data.clickMultiplier1Level++;
            data.darkSouls -= data.clickMultiplier1Cost;
            data.clickMultiplier1Cost *= 1.21;
            data.clickUpgrade1Cost /= 2;
            data.clickUpgrade2Cost /= 2;
            data.clickUpgrade3Cost /= 2;
            data.clickUpgrade4Cost /= 2;
            data.clickUpgrade5Cost /= 2;
            data.clickUpgrade6Cost /= 2;
        }
    }
    public void BuyClickMulti2()
    {
        if (data.darkSouls >= data.clickMultiplier2Cost)
        {
            data.clickMultiplier2Level++;
            data.lightSouls -= data.clickMultiplier2Cost;
            data.clickMultiplier2Cost *= 1.25;
            data.clickUpgrade1Cost /= 3.5;
            data.clickUpgrade2Cost /= 3.5;
            data.clickUpgrade3Cost /= 3.5;
            data.clickUpgrade4Cost /= 3.5;
            data.clickUpgrade5Cost /= 3.5;
            data.clickUpgrade6Cost /= 3.5;
        }
    }
    public void BuyProductionMulti1()
    {
        if (data.lightSouls >= data.productionMultiplier1Cost)
        {
            data.productionMultiplier1Level++;
            data.lightSouls -= data.productionMultiplier1Cost;
            data.productionMultiplier1Cost *= 1.21;
            data.productionUpgrade1Cost /= 2;
            data.productionUpgrade2Cost /= 2;
            data.productionUpgrade3Cost /= 2;
            data.productionUpgrade4Cost /= 2;
            data.productionUpgrade5Cost /= 2;
            data.productionUpgrade6Cost /= 2;
        }
    }
    public void BuyProductionMulti2()
    {
        if (data.lightSouls >= data.productionMultiplier2Cost)
        {
            data.productionMultiplier2Level++;
            data.lightSouls -= data.productionMultiplier2Cost;
            data.productionMultiplier2Cost *= 1.25;
            data.productionUpgrade1Cost /= 3.5;
            data.productionUpgrade2Cost /= 3.5;
            data.productionUpgrade3Cost /= 3.5;
            data.productionUpgrade4Cost /= 3.5;
            data.productionUpgrade5Cost /= 3.5;
            data.productionUpgrade6Cost /= 3.5;
        }
    }





















    public void GoToSettings()
    {
        Settings.gameObject.SetActive(true);
    }

    public void GoBackFromSettings()
    {
        Settings.gameObject.SetActive(false);
    }

    public void GoToMainScreen()
    {
        MainScreen.gameObject.SetActive(true);
    }
    public void GoToDLScreen()
    {
        DLScreen.gameObject.SetActive(true);
    }
    public void GoBackFromDLScreen()
    {
        DLScreen.gameObject.SetActive(false);
    }

    public void FullReset()
    {
        data.FullReset();
    }
}
