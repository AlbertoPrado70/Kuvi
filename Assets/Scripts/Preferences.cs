﻿using UnityEngine;

public class Preferences {

    public int actualLevel; 
    public int adCount;
    public bool muted; 
    public bool isPremium; 
    public bool preferencesSet;  

    public Preferences() {

        if(!PlayerPrefs.HasKey("preferences_set")) {

            PlayerPrefs.SetInt("actual_level", 0);
            PlayerPrefs.SetInt("ad_count", 0);
            PlayerPrefs.SetString("muted", "false");
            PlayerPrefs.SetString("is_premium", "false");
            PlayerPrefs.SetString("preferences_set", "true");

            PlayerPrefs.Save();

        }

        actualLevel = PlayerPrefs.GetInt("actual_level");
        muted = bool.Parse(PlayerPrefs.GetString("muted"));
        isPremium = bool.Parse(PlayerPrefs.GetString("is_premium"));
        preferencesSet = bool.Parse(PlayerPrefs.GetString("preferences_set"));

    }

    public void saveCompletedLevel() {
        PlayerPrefs.SetInt("actual_level", actualLevel);
        PlayerPrefs.Save();
    }

    public void saveVolumeLevel(bool muted) {
        this.muted = muted; 
        PlayerPrefs.SetString("muted", muted.ToString());
        PlayerPrefs.Save();
    }

    public void saveAdCount() {
        PlayerPrefs.SetInt("ad_count", adCount);
        PlayerPrefs.Save();
    }

    public void saveUserPremium() {
        isPremium = true; 
        PlayerPrefs.SetString("is_premium", "true");
    }

}