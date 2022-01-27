using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Demo : MonoBehaviour
{
    [SerializeField] InputSystemManager ISM;

    // Start is called before the first frame update
    void Start()
    {
        ISM.Init();
    }

    // Update is called once per frame
    void Update()
    {
        ISM.Updater();

    }
}
