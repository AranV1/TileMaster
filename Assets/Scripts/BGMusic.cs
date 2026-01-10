using UnityEngine;

public class BGMusic : MonoBehaviour
{
    void Awake()
    {
        int numberBGMusic = FindObjectsByType<BGMusic>(FindObjectsSortMode.None).Length;
        if (numberBGMusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        //DontDestroyOnLoad(gameObject);
    }
}
