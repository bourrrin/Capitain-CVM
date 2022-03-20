using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCollectableInMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public string collectableName;
    void Start()
    {
        foreach (string collectable in GameManager.Instance.PlayerData.ListeCollectable)
        {
            if (collectable == collectableName)
            {
                gameObject.SetActive(true);
                return ;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
