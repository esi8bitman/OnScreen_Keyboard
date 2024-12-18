using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UPersian.Components;
using UnityEngine.EventSystems;

/*----------------------------
it is not nessecery to use this inputfield...
you can use your own inputfield with your customized code!!
it's just a sample .... ^-^ 
----------------------------*/
public class InputField_Ctrl : MonoBehaviour ,IPointerUpHandler,ISelectHandler {
    public InputField inputField;

    Regex regex_HasPersianCharacters = new Regex(".[\u0600-\u06FF]+.|^[\u0600-\u06FF]");
    Regex regex_HasFirstPersianCharacters =  new Regex("^[\u0600-\u06FF]");
    Text inp_Text;
    RtlText inp_RtlText;
    // Use this for initialization
    void Start () {
        inputField = GetComponent<InputField>();
        inp_RtlText = inputField.transform.GetChild(1).GetComponent<RtlText>();
        inp_Text = inputField.transform.GetChild(1).GetComponent<Text>();
	}


    public void ChangeingText() //LanguageAlignment
    {
        
        if (inputField.text != "")
        {
            if (regex_HasPersianCharacters.IsMatch(inputField.text))
            {
                if (regex_HasFirstPersianCharacters.IsMatch(inputField.text))
                {
                    inp_Text.alignment = TextAnchor.UpperRight;
                    KeysManager.keysManager.isLeft = false;
                    inp_RtlText.active = true;
                }
                else
                {
                    inp_Text.alignment = TextAnchor.UpperLeft;
                    KeysManager.keysManager.isLeft = true;
                    inp_RtlText.active = true;
                }
            }
            else
            {
                inp_Text.alignment = TextAnchor.UpperLeft;
                KeysManager.keysManager.isLeft = true;
                inp_RtlText.active = false;
            }
        }

    }

    public void OnSelect(BaseEventData eventData) //Send Refrence
    {
        KeysManager.keysManager.FocusInputField(inputField);
    }

    public void OnPointerUp(PointerEventData eventData) //Send Selectable
    {
        KeysManager.keysManager.selectionPosition = KeysManager.keysManager.isLeft?inputField.selectionAnchorPosition:(inputField.text.Length-inputField.selectionAnchorPosition);
        KeysManager.keysManager.lastCaretPosition = KeysManager.keysManager.isLeft?inputField.caretPosition:(inputField.text.Length-inputField.caretPosition);
        //inputField.selectionFocusPosition = KeysManager.keysManager.lastCaretPosition;

        // Debug.Log($"caretPos: {KeysManager.keysManager.lastCaretPosition} - selecPos: {KeysManager.keysManager.selectionPosition}");
    }
}
