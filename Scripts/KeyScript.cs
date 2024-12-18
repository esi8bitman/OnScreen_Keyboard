using UnityEngine;
using UnityEngine.UI;
public class KeyScript : MonoBehaviour {

    string mycharcter;
    private void Start()
    {
        if(transform.GetChild(0).GetComponent<Text>())
            mycharcter = transform.GetChild(0).GetComponent<Text>().text;
    }
    public void AddSpace()
    {
        KeysManager.keysManager.AppendChar(" ");
    }
    public void AddChar()
    {
        KeysManager.keysManager.AppendChar(mycharcter);
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
