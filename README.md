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

- Only actions for which InputActionType is a button are targeted for handling.

- When you edit InputActions.inputactions, you need to update the Control enum.<br>Run "ExecuteOnValidate" in the prefab InputSystem.cs.


## Check Demo

Open the EISM-Demo folder from Unity Hub to open the EISM demo project.

Open SampleScene and play it. Logs will be output to the console. Now, let's press the arrow key. Another log will be output to the console at the moment you press it. 

For example, the moment you press the Up key, the log "up:True" will be output.

EISM-Demo.cs also gives you tips on how to use it in your project.