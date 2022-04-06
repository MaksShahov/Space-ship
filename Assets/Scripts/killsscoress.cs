using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class killsscoress : MonoBehaviour
{
    public Text txt1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt1.text = "Kills: "+staticcs.kills.ToString();
    }
}
