# EISM:ELICXIRs_InputSystemManager

Copyright (c) 2022 ELICXIR
Released under the MIT license
https://opensource.org/licenses/mit-license.php

## About
EISM is a package for easy installation of Input System.

## Feature
- Easily handle inputs utilizing the Action of Input System

- the Action of Input System makes it easy to handle input from a keyboard or several types of gamepads

- Focus on handling BUTTON input

- Mouse and touchpad input is not supported <br>(can be used together if you make it on your own)


## How to Use
1. Install Input System
(https://docs.unity3d.com/Packages/com.unity.inputsystem@1.3/manual/Installation.html)

2. Import "EISM.unitypackage" to your project.

3. Place the InputSystemManager prefab on the scene.
Note that the prefab is set to "Don't Destroy on Load".

4. EISM handles the input by initializing and updating it frame by frame.

    - Initialization:
      ```cs
      InputSystem.Input_System.Init();
      ```

    - Frame-by-frame update:
      ```cs
      InputData input = InputSystem.Input_System.FrameUpdate();
      ```

5. InputData type variable "input" contains SingleInputData that records the input for each button.<br><br>To obtain SingleInputData, use GetSingleInputData(). Use EISM.Control as the argument (EISM.Control will automatically enumerate the Actions defined in inputactions).<br><br>Up key information can be obtained by using Control.Up as an argument.


    ```cs
    SingleInputData s_input= input.GetSingleInputData(Control.Up)
    ```


6. SingleInputData contains the following information

    |  Property (readonly)  |  Type  | Description |
    | ---- | ---- | ---- |
    |  ID  |  string  |Corresponding Action name|
    |  isPressed  |  bool  |Whether the button is pressed or not|
    |  isPressedThisFrame  |  bool  |Whether or not the moment the button is pressed|
    |  isReleasedThisFrame  |  bool  |Whether or not the moment the button is released|
    |  PressTimer  |  float  |Time since isPressedThisFrame last set to True|
    |  HoldTimer  |  float  |Time to keep pressing |
    |  ReleaseTimer  |  float  |Time since isReleasedThisFrame last set to True|

    (All time units are in seconds. )

- Only actions for which InputActionType is a button are targeted for handling.

- When you edit InputActions.inputactions, you need to update the Control enum.<br>Run "ExecuteOnValidate" in the prefab InputSystem.cs.


## Check Demo

Open the EISM-Demo folder from Unity Hub to open the EISM demo project.

Open SampleScene and play it. Logs will be output to the console. Now, let's press the arrow key. Another log will be output to the console at the moment you press it. 

For example, the moment you press the Up key, the log "up:True" will be output.

EISM-Demo.cs also gives you tips on how to use it in your project.