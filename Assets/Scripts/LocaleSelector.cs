using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using System.Linq;

[RequireComponent(typeof(Dropdown))]
public class LocaleSelector : MonoBehaviour
{
    Dropdown dropdown;
    Locale[] locales;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();

        // Grab the Locales you set in Localization Settings:
        locales = LocalizationSettings.AvailableLocales.Locales.ToArray();

        // Populate dropdown options with their names:
        dropdown.options = locales
            .Select(loc => new Dropdown.OptionData(loc.Identifier.CultureInfo.NativeName))
            .ToList();

        // Pre-select the current one:
        int current = System.Array.IndexOf(locales, LocalizationSettings.SelectedLocale);
        dropdown.value = current >= 0 ? current : 0;

        // Hook value changes:
        dropdown.onValueChanged.AddListener(OnLocaleChanged);
    }

    void OnLocaleChanged(int idx)
    {
        LocalizationSettings.SelectedLocale = locales[idx];
    }
}