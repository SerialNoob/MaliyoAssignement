using UnityEngine;



public class GameManager : MonoBehaviour
{


    static GameManager()
    {


        if (Globals.USE_SEED_GENERATION)
        {
            Random.InitState(Globals.SEED_STRING.GetHashCode());
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
