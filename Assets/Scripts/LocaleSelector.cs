using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool active = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        // Load the selected locale from PlayerPrefs
        int localeID = PlayerPrefs.GetInt("LocaleID", 0);
        ChangeLocale(localeID);
    }

    public void ChangeLocale(int localeID)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeID];
        PlayerPrefs.SetInt("LocaleID", localeID);
        active = false;
    }
}
