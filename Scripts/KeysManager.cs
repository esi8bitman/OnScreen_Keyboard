using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class KeysManager : MonoBehaviour {
    #region singlton
    public static KeysManager keysManager;
    public int lastCaretPosition,selectionPosition;
    public bool isLeft = true;

    int min,max;
    private void Awake()
    {
        keysManager = this;
    }
    #endregion

    public InputField textToAddTo= null;


    public void FocusInputField(InputField inputField)
    {
        textToAddTo = inputField;
        
    }

    public void AppendChar(string character)
    {
        if (textToAddTo != null)
        {            
            textToAddTo.caretPosition = lastCaretPosition;

            textToAddTo.text = textToAddTo.text.Insert(textToAddTo.caretPosition, character);

            lastCaretPosition++;

            textToAddTo.GetType().GetField("m_AllowInput", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(textToAddTo, true);
            textToAddTo.GetType().InvokeMember("SetCaretVisible", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance, null, textToAddTo, null);
            textToAddTo.caretPosition = isLeft?lastCaretPosition:textToAddTo.text.Length - lastCaretPosition;
            selectionPosition = lastCaretPosition;
            
        }
    }

    public void DeleteChar()
    {
        if (textToAddTo != null){

                if (selectionPosition == lastCaretPosition)
                {
                    if (lastCaretPosition > 0){
                    textToAddTo.text = textToAddTo.text.Substring(0, lastCaretPosition - 1) + textToAddTo.text.Substring(lastCaretPosition);
                    lastCaretPosition--;
                    selectionPosition = lastCaretPosition;
                    
                    }
                }
                else
                {
                    if(selectionPosition<lastCaretPosition)
                    {
                        min = selectionPosition;
                        max = lastCaretPosition;
                    }else{
                        min = lastCaretPosition;
                        max = selectionPosition;
                    }

                    textToAddTo.text = textToAddTo.text.Substring(0, min) + textToAddTo.text.Substring(max);
                    lastCaretPosition = min;
                    selectionPosition = min;
                    
                }

            textToAddTo.GetType().GetField("m_AllowInput", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(textToAddTo, true);
            textToAddTo.GetType().InvokeMember("SetCaretVisible", BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.Instance, null, textToAddTo, null);
            textToAddTo.caretPosition = isLeft?lastCaretPosition:textToAddTo.text.Length - lastCaretPosition;
        }
    }

}
