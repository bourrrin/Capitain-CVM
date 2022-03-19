using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string collectableName;
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (string collectable in GameManager.Instance.PlayerData.ListeCollectable)
        {
            Debug.Log(collectable);
            if (collectable == collectableName)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.PlayerData.AddCollectable(collectableName);
            Destroy(gameObject);
        }
    }

}
