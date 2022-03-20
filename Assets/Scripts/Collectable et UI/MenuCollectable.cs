using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuCollectable : MonoBehaviour
{
    TMP_Text text;
    public int nbr_collectable = 2;
    // Start is called before the first frame update
    void Start()
    {
        foreach (string collectable in GameManager.Instance.PlayerData.ListeCollectable)
        {
            Debug.Log(collectable);
        }

        text = GameObject.Find("TexteCollectable").GetComponent<TMP_Text>();
        int nbrCollectable = GameManager.Instance.PlayerData.ListeCollectable.Length;
        text.text = nbrCollectable + " / "+ nbr_collectable;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
