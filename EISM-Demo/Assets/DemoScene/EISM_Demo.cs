using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EISM;

namespace EISM {
    public class EISM_Demo : MonoBehaviour
    {
        // Initialize the InputSystem in Start()
        void Start()
        {
            InputSystem.Input_System.Init();
        }


        void Update()
        {
            // By calling FrameUpdate(), the input data can be updated and retrieved.
            // Let the InputData structure hold the acquired data.

            InputData input = InputSystem.Input_System.FrameUpdate();

            // By executing GetSingleInputData() on the acquired data, the data for each button can be retrieved.
            //In the following, you can get whether or not the arrow key is pressed at the moment.

            print($"up:{input.GetSingleInputData(Control.Up).isPressedThisFrame}");
            print($"down:{input.GetSingleInputData(Control.Down).isPressedThisFrame}");
            print($"right:{input.GetSingleInputData(Control.Right).isPressedThisFrame}");
            print($"left:{input.GetSingleInputData(Control.Left).isPressedThisFrame}");
        }
    }
}


