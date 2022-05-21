using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace EISM
{

    public class InputSystem : MonoBehaviour
    {
        public static InputSystem Input_System;

        private void Awake()
        {
            if (Input_System == null)
            {
                Input_System = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }




        [SerializeField] PlayerInput playerInput;

        [ContextMenu("ExecuteOnValidate")]
        void OnValidate()
        {
            EISM_miscs.Generate(GetInputList());
        }

        List<string> GetInputList()
        {
            List<string> res = new List<string>();

            foreach (var item in playerInput.actions)
            {
                if (item.type == InputActionType.Button)
                {
                    res.Add(item.name);
                }
            }

            return res;
        }

        InputButton[] inputButtons;


        uint framecount;


        public void Init()
        {
            framecount = 0;
            List<string> datas = GetInputList();

            inputButtons = new InputButton[datas.Count];

            for (int i = 0; i < datas.Count; i++)
            {
                inputButtons[i] = new InputButton(playerInput, datas[i]);
            }

        }


        public InputData FrameUpdate()
        {
            DateTime datetime = DateTime.Now;
            float timer = Time.deltaTime;



            for (int i = 0; i < inputButtons.Length; i++)
            {
                inputButtons[i].FrameUpdate(timer);
            }

            framecount++;
            return new InputData(inputButtons, framecount, datetime);
        }
    }
}