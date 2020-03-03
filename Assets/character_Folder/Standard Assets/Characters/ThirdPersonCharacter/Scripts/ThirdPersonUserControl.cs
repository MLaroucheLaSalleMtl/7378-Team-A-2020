using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private bool m_Fire;
        float h = 0;
        float v = 0;
        bool jumping = false;
        bool crouch = false;
        bool walk = false;
        bool Fire = false;
        bool Dodge = false;

        Animator anim;

        //this is the receiver
        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 value = context.ReadValue<Vector2>();
            h = value.x;
            v = value.y;
        }

        public void onJump(InputAction.CallbackContext context)
        {
            jumping = context.performed;
            //if (context.started)  //buttonDown
            //if (context.started) //buttonUp when you release it, it jumps
            //{
            //    jumping = true;
            //}
        }


        public void onCrouch(InputAction.CallbackContext context)
        {
            //crouch = context.performed; //getButton, keep counting
            if (context.started)
            {
                crouch = !crouch; //toggle, switching the action
            }
        }

        public void onWalk(InputAction.CallbackContext context)
        {
            //walk = context.performed; // getButton

            if (context.started)  //buttonDown
            //if (context.canceled) //buttonUp when you release it, it jumps
            {
                walk = !walk;
            }
        }




        public void onDodge(InputAction.CallbackContext context)
        {
            Dodge = context.performed;
            anim.SetBool("Dodge", Dodge);
        }





        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
            anim = GetComponent<Animator>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = jumping;
                jumping = false;
            }


        }

    

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            //bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.6f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }



    
      
    }
}

