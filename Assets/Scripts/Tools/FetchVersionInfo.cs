using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FetchVersionInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textElement = GetComponent<TMP_Text>();

        if (textElement == null) return;

        textElement.text = Application.productName + " - v" + Application.version; 
    }

    
}
