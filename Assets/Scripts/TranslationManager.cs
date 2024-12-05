using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class TranslationManager : MonoBehaviour
{
    private static Dictionary<string, string> translations;
    private const string BASE_URL = "https://traducila.vercel.app/api/translations/";
    private const string PROJECT_ID = "cm29kyxe30001s5ds5flu7oa7"; // El ID de tu proyecto
    private static string currentLanguage = "es-AR"; // Idioma por defecto

    

    // Método para obtener las traducciones
    public static IEnumerator GetTranslations(string language, System.Action callback)
    {
        // Limpiamos las traducciones actuales
        translations = null;
        currentLanguage = language;

        // Si el idioma es "es-AR", no necesitamos obtener traducciones
        if (language == "es-AR")
        {
            // Invocamos el callback inmediatamente
            callback?.Invoke();
            yield break; // Salimos de la corrutina
        }

        // Hacemos la solicitud a la API para obtener las traducciones
        string url = "https://traducila.vercel.app/api/translations/cm29kyxe30001s5ds5flu7oa7/en-US";
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error fetching translations: {request.error}");
        }
        else
        {
            // Usamos JsonUtility para deserializar la respuesta
            TranslationResponse response = JsonUtility.FromJson<TranslationResponse>(request.downloadHandler.text);

            // Almacenamos las traducciones en el diccionario
            translations = new Dictionary<string, string>();
            foreach (TranslationEntry entry in response.translations)
            {
                translations[entry.key] = entry.value;
                Debug.Log($"Key: {entry.key}, Value: {entry.value}");
            }

            // Guardamos las traducciones en PlayerPrefs
            PlayerPrefs.SetString("translations", request.downloadHandler.text);
            PlayerPrefs.Save();

            // Invocamos el callback después de obtener las traducciones
            callback?.Invoke();
        }
    }

    // Método para obtener una frase traducida
    public static string GetPhrase(string key)
    {
        if (translations == null)
        {
            // Si no hemos cargado las traducciones, intentamos recuperarlas de PlayerPrefs
            string storedTranslations = PlayerPrefs.GetString("translations", null);
            if (!string.IsNullOrEmpty(storedTranslations))
            {
                TranslationResponse response = JsonUtility.FromJson<TranslationResponse>(storedTranslations);
                translations = new Dictionary<string, string>();
                foreach (TranslationEntry entry in response.translations)
                {
                    translations[entry.key] = entry.value;
                }
            }
        }

        // Si tenemos las traducciones y la clave existe, devolvemos la frase traducida
        if (translations != null && translations.ContainsKey(key))
        {
            return translations[key];
        }

        // Si no hay traducción, devolvemos la clave original
        return key;
    }

    [System.Serializable]
    public class TranslationResponse
    {
        public List<TranslationEntry> translations; // Lista de traducciones
    }

    [System.Serializable]
    public class TranslationEntry
    {
        public string key;
        public string value;
    }

    // Método para obtener el idioma actual
    public static string GetCurrentLanguage()
    {
        return currentLanguage;
    }
}
