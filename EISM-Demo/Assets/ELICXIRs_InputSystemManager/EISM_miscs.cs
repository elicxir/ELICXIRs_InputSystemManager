using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

namespace EISM
{
    internal static class EISM_miscs
    {
        internal static void Generate(List<string> list)
        {
            if (!Application.isEditor)
            {
                throw new Exception("this is Editor Mode only");
            }

            string res = "namespace EISM\n";
            res += "{\n";
            res += "    public enum Control {\n";

            foreach (string item in list)
            {
                res += $"        {item},\n";
            }

            res += "    }\n";
            res += "}\n";

#if UNITY_EDITOR
            File.WriteAllText(GetExportPass(), res, Encoding.UTF8);

            AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
#endif
        }

        internal static string GetExportPass()
        {
            string[] files = Directory.GetFiles(Application.dataPath, "EISM_Control.cs", SearchOption.AllDirectories);

            if (files.Length != 1)
            {
                throw new Exception("EISM_Control.cs is not found");

            }
            return files[0];
        }

        internal static InputData GenerateInputData(InputButton[] sources, uint framecount, DateTime datetime)
        {
            var res = new InputData();


            return res;

        }

    }

    public struct InputData
    {
        internal InputData(InputButton[] sources, uint framecount, DateTime datetime)
        {
            DateTime = datetime;
            Framecount = framecount;
            singleInputs = new SingleInputData[sources.Length];
            for (int i = 0; i < singleInputs.Length; i++)
            {
                singleInputs[i] = new SingleInputData(sources[i]);
            }
        }

        private SingleInputData[] singleInputs { get; set; }

        public DateTime DateTime { get; private set; }

        public uint Framecount { get; private set; }


        public SingleInputData GetSingleInputData(Control control)
        {
            return singleInputs[(int)control];
        }





        public string InputLog()
        {
            string res = "InputLog:\n";

            for (int i = 0; i < singleInputs.Length; i++)
            {
                string d = $" {singleInputs[i].ID}:   isP:{singleInputs[i].isPressed}   isPTF:{singleInputs[i].isPressedThisFrame}    isRTF:{singleInputs[i].isReleasedThisFrame}   PTimer:{singleInputs[i].PressTimer} HTimer:{singleInputs[i].HoldTimer} RTimer:{singleInputs[i].ReleaseTimer}\n";

                res += d;
            }
            return res;
        }
    }

    public struct SingleInputData
    {
        internal SingleInputData(InputButton source)
        {
            ID = source.ID;
            isPressed = source.isPressed;
            isPressedThisFrame = source.isPressedThisFrame;
            isReleasedThisFrame = source.isReleasedThisFrame;
            PressTimer = source.PressTimer;
            HoldTimer = source.HoldTimer;
            ReleaseTimer = source.ReleaseTimer;
        }
        public string ID
        {
            get; private set;
        }
        public bool isPressed
        {
            get; private set;
        }
        public bool isPressedThisFrame
        {
            get; private set;
        }
        public bool isReleasedThisFrame
        {
            get; private set;
        }
        public float PressTimer
        {
            get; private set;
        }
        public float HoldTimer
        {
            get; private set;
        }
        public float ReleaseTimer

        {
            get; private set;
        }
    }


    internal struct InputButton
    {
        internal InputButton(PlayerInput input, string id)
        {
            inputAction = input.actions[id];
            ID = id;

            isPressed = false;
            isPressedThisFrame = false;
            isReleasedThisFrame = false;
            PressTimer = 0;
            HoldTimer = 0;
            ReleaseTimer = 0;


        }
        internal string ID;

        InputAction inputAction;

        internal bool isPressed;
        internal bool isPressedThisFrame;
        internal bool isReleasedThisFrame;
        internal float PressTimer;
        internal float HoldTimer;
        internal float ReleaseTimer;


        internal void FrameUpdate(float time)
        {
            isPressed = inputAction.IsPressed();
            isPressedThisFrame = inputAction.WasPressedThisFrame();
            isReleasedThisFrame = inputAction.WasReleasedThisFrame();

            if (isPressedThisFrame)
            {
                PressTimer = 0;
            }
            else
            {
                PressTimer += time;
            }

            if (isReleasedThisFrame)
            {
                ReleaseTimer = 0;
            }
            else
            {
                ReleaseTimer += time;
            }

            if (isPressedThisFrame || isReleasedThisFrame)
            {
                HoldTimer = 0;
            }

            if (isPressed)
            {
                HoldTimer += time;
            }

        }
    }

}