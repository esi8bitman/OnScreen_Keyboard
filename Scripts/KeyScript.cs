using UnityEngine;
using UnityEngine.UI;
public class KeyScript : MonoBehaviour {

    public void AddSpace()
    {
        KeysManager.keysManager.AppendChar(" ");
    }
    public void AddChar(string character)
    {
        KeysManager.keysManager.AppendChar(character);
    }
    public void sendEnter()
    {
        KeysManager.keysManager.AppendChar("\n");
    }
    public void sendTab()
    {
        KeysManager.keysManager.AppendChar("\t");
    }
    public void sendBackSpace()
    {
        KeysManager.keysManager.DeleteChar();
    }

}
