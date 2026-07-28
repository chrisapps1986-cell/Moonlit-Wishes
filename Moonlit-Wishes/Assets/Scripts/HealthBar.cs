using System.Data;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private GameObject[] mooncakes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        mooncakes = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            mooncakes[i] = transform.GetChild(i).gameObject;
        }
    
        
    }

    // Update is called once per frame
    public void UpdateMoonCakesUI( int currentLives)
    {

        if (mooncakes == null) return;

        for (int i = 0; i < mooncakes.Length; i++)
        {
            mooncakes[i].SetActive(i < currentLives);
        }
        
    }
}
