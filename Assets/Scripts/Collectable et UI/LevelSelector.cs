using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public int nbrButton = 3;
    void Start()
    {
        List<Button> buttonList = new List<Button>();

        for (int i=1; i <= nbrButton; i++)
        {
            Button btn = GameObject.Find("ButtonNiv" + i).GetComponent<Button>();
            btn.interactable = false;
            buttonList.Add(btn);
        }

        Debug.Log(GameManager.Instance.PlayerData.CurrentMaxLevel);
        for (int i = 0; i < GameManager.Instance.PlayerData.CurrentMaxLevel; i++)
        {
            buttonList[i].interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
