using UnityEngine;

[System.Serializable]
public class LanguageObject
{
    [SerializeField] public GameObject m_Language;
    [SerializeField] public GameObject m_Language_Small_Alphabets;
    [SerializeField] public GameObject m_Language_Capitalized_Alphabets;
    [SerializeField] public GameObject m_Language_Special_Alphabets_And_Calculator;
}
public class KeyboardFunctionltyChanger : MonoBehaviour {
    
    private enum Language { English,Persian };
    private enum View { Small, Cabitalized, Special_And_Calculator };
    [Header("English Settings")]
    public LanguageObject engLanguage;


    [Header("Perisan Settings")]
    public LanguageObject persianLanguage;


    [SerializeField] Language language;
    [SerializeField] View view;

    private LanguageObject choosedLanguage;
    private void Start()
    {
        language = Language.English;
        KeysManager.keysManager.isLeft = true;
        view = View.Small;
        choosedLanguage = engLanguage;
    }

    public void chooseLanguage(int languageindex)
    {
        //KeysManager.keysManager.language = languageindex;
        language =  (Language)languageindex;
        switch (language)
        {
            case Language.English:
                {
                    engLanguage.m_Language.SetActive(true);
                    persianLanguage.m_Language.SetActive(false);
                    choosedLanguage = engLanguage;
                    break;
                }
            case Language.Persian:
                {
                    persianLanguage.m_Language.SetActive(true);
                    engLanguage.m_Language.SetActive(false);
                    choosedLanguage = persianLanguage;
                    break;
                }
        }
        chooseLanguageView((int)view);
    }
    public void chooseLanguageView(int languageindex)
    {
        view = (View)languageindex;
                switch (view)
        {
            case View.Small:
                choosedLanguage.m_Language_Small_Alphabets.SetActive(true);
                choosedLanguage.m_Language_Capitalized_Alphabets.SetActive(false);
                choosedLanguage.m_Language_Special_Alphabets_And_Calculator.SetActive(false);
                break;
            case View.Cabitalized:
                choosedLanguage.m_Language_Small_Alphabets.SetActive(false);
                choosedLanguage.m_Language_Capitalized_Alphabets.SetActive(true);
                choosedLanguage.m_Language_Special_Alphabets_And_Calculator.SetActive(false);
                break;
            case View.Special_And_Calculator:
                choosedLanguage.m_Language_Small_Alphabets.SetActive(false);
                choosedLanguage.m_Language_Capitalized_Alphabets.SetActive(false);
                choosedLanguage.m_Language_Special_Alphabets_And_Calculator.SetActive(true);
                break;
        }
    }
}
