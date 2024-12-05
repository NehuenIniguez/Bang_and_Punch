using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
     public static readonly Dictionary<string, string> LanguageCodes = new Dictionary<string, string>()
    {
        { "Spanish", "es-AR" },
        { "English", "en-US" },
        { "Portuguese", "pt-BR" },
        { "German", "de-DE" },
        { "French", "fr-FR" }
    };

    // Si prefieres hacerlo con constantes
    public const string SPANISH = "es-AR";
    public const string ENGLISH = "en-US";
    public const string PORTUGUESE = "pt-BR";
    public const string GERMAN = "de-DE";
    public const string FRENCH = "fr-FR";
}