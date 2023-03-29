//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""3DPlayer"",
            ""id"": ""3602373e-35b4-48d8-8497-2917d1c4b44c"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f5073663-d4a0-4fab-b16b-b371e5decfa7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ffa2e468-c769-4a3e-97b4-f3cdaabd8774"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Ybtn"",
                    ""type"": ""Button"",
                    ""id"": ""ef9de459-ae1c-48ca-986e-db0107812c9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""577e0362-df89-4d2c-a76b-1da90c816572"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightShoulder"",
                    ""type"": ""Button"",
                    ""id"": ""c281a239-27ff-4862-a041-ae2a0255351f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Xbtn"",
                    ""type"": ""Button"",
                    ""id"": ""15f41c91-b7fb-4d9f-ba5c-ab578d54595e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bbtn"",
                    ""type"": ""Button"",
                    ""id"": ""d8b303ae-6eb3-4b2c-8066-10d9ca04841f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7daca96b-82a1-4a28-b27a-04bcdfad1009"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d426901-bbe7-4b92-977f-7fc234b0225f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ca73bb30-dabe-48a9-af31-d7b2b1e7fa53"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9b9f163c-eef5-41f9-a21d-391c9bf58600"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""82bb4be3-f8e2-44f2-bc54-f55a0ee18b8a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ddf4e6f5-495e-40a4-af90-3e023cc2578c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""71ab1f1b-ac44-422d-a25e-08876d0118fb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""986bb8cb-fb73-4a8f-92dc-fa48426328c7"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9bd1ca9-ba43-486e-a97a-1faa539e7e14"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79282875-9c80-41b3-a59f-ea664609d1f3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Ybtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ff27857-a327-4cdf-be21-891f570ded77"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ybtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0d13c70-b0c9-4ef7-b328-2067e60a2a25"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ybtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03888363-1246-4409-b67b-6da0ef9ed4e2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Sight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5241e054-7824-4548-8422-77feb324783b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eb9835a6-f054-48fe-b5ab-532df71c607b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""68cec0fe-d0be-4880-9ec4-85cb035515a7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f95b89d8-d380-4af3-99a6-b458817cc8c2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae7b497f-107b-4d15-b55d-0528e923343f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ced5d643-0365-4a78-a847-a5fbf4b3ba0a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""RightShoulder"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""370997e6-2b74-47c7-8925-cd741ec6bc2c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Xbtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9e8c36a-7281-48e4-b886-2bfca275f0e0"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Xbtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""718dbe80-adad-40c0-8705-a5929a2b7f7d"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Bbtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6772b5e-982e-4303-8ace-03768b1143b2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Bbtn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""2DPlayer"",
            ""id"": ""5c5abdcd-c076-49c7-90a3-071c6e55f6dc"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""1a2c6506-ba70-40a7-9d49-1f57e8e4e74a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""0c6de896-cb70-4f04-8b8d-fa0e65a6f033"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""b12b4463-f1b9-4baa-805e-7e009d0c1a8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement2D"",
                    ""type"": ""Value"",
                    ""id"": ""af49e743-7a37-4654-bc0b-ee4c065d76a1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump2D"",
                    ""type"": ""Button"",
                    ""id"": ""6fb44766-ab41-4d88-a30d-b1149daf3367"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6472a4f-786c-45db-a727-a60ad384eb5e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52454d1e-d921-4c51-8d82-643189da775c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""345f229f-0786-46aa-9d67-1eeee149ec9a"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf2b7614-5bd9-41d3-b8d6-d1e4cd13420a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d893f870-5803-4b0c-91a0-fb35a24e6ec3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d9a2d1e-2e5c-4863-aeae-da9a8658ef84"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e699cc0d-18f2-4ad4-82f6-62efc3035930"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement2D"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""324c65ef-6e74-400a-9edc-fe9bebb5a9d1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13a7ea78-4ccb-4b33-8656-6a2fa7df39a3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // 3DPlayer
        m__3DPlayer = asset.FindActionMap("3DPlayer", throwIfNotFound: true);
        m__3DPlayer_Select = m__3DPlayer.FindAction("Select", throwIfNotFound: true);
        m__3DPlayer_Movement = m__3DPlayer.FindAction("Movement", throwIfNotFound: true);
        m__3DPlayer_Ybtn = m__3DPlayer.FindAction("Ybtn", throwIfNotFound: true);
        m__3DPlayer_Sight = m__3DPlayer.FindAction("Sight", throwIfNotFound: true);
        m__3DPlayer_RightShoulder = m__3DPlayer.FindAction("RightShoulder", throwIfNotFound: true);
        m__3DPlayer_Xbtn = m__3DPlayer.FindAction("Xbtn", throwIfNotFound: true);
        m__3DPlayer_Bbtn = m__3DPlayer.FindAction("Bbtn", throwIfNotFound: true);
        // 2DPlayer
        m__2DPlayer = asset.FindActionMap("2DPlayer", throwIfNotFound: true);
        m__2DPlayer_Select = m__2DPlayer.FindAction("Select", throwIfNotFound: true);
        m__2DPlayer_Rotate = m__2DPlayer.FindAction("Rotate", throwIfNotFound: true);
        m__2DPlayer_Grab = m__2DPlayer.FindAction("Grab", throwIfNotFound: true);
        m__2DPlayer_Movement2D = m__2DPlayer.FindAction("Movement2D", throwIfNotFound: true);
        m__2DPlayer_Jump2D = m__2DPlayer.FindAction("Jump2D", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // 3DPlayer
    private readonly InputActionMap m__3DPlayer;
    private I_3DPlayerActions m__3DPlayerActionsCallbackInterface;
    private readonly InputAction m__3DPlayer_Select;
    private readonly InputAction m__3DPlayer_Movement;
    private readonly InputAction m__3DPlayer_Ybtn;
    private readonly InputAction m__3DPlayer_Sight;
    private readonly InputAction m__3DPlayer_RightShoulder;
    private readonly InputAction m__3DPlayer_Xbtn;
    private readonly InputAction m__3DPlayer_Bbtn;
    public struct _3DPlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public _3DPlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m__3DPlayer_Select;
        public InputAction @Movement => m_Wrapper.m__3DPlayer_Movement;
        public InputAction @Ybtn => m_Wrapper.m__3DPlayer_Ybtn;
        public InputAction @Sight => m_Wrapper.m__3DPlayer_Sight;
        public InputAction @RightShoulder => m_Wrapper.m__3DPlayer_RightShoulder;
        public InputAction @Xbtn => m_Wrapper.m__3DPlayer_Xbtn;
        public InputAction @Bbtn => m_Wrapper.m__3DPlayer_Bbtn;
        public InputActionMap Get() { return m_Wrapper.m__3DPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_3DPlayerActions set) { return set.Get(); }
        public void SetCallbacks(I_3DPlayerActions instance)
        {
            if (m_Wrapper.m__3DPlayerActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSelect;
                @Movement.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnMovement;
                @Ybtn.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnYbtn;
                @Ybtn.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnYbtn;
                @Ybtn.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnYbtn;
                @Sight.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSight;
                @Sight.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSight;
                @Sight.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnSight;
                @RightShoulder.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnRightShoulder;
                @RightShoulder.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnRightShoulder;
                @Xbtn.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnXbtn;
                @Xbtn.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnXbtn;
                @Xbtn.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnXbtn;
                @Bbtn.started -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnBbtn;
                @Bbtn.performed -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnBbtn;
                @Bbtn.canceled -= m_Wrapper.m__3DPlayerActionsCallbackInterface.OnBbtn;
            }
            m_Wrapper.m__3DPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Ybtn.started += instance.OnYbtn;
                @Ybtn.performed += instance.OnYbtn;
                @Ybtn.canceled += instance.OnYbtn;
                @Sight.started += instance.OnSight;
                @Sight.performed += instance.OnSight;
                @Sight.canceled += instance.OnSight;
                @RightShoulder.started += instance.OnRightShoulder;
                @RightShoulder.performed += instance.OnRightShoulder;
                @RightShoulder.canceled += instance.OnRightShoulder;
                @Xbtn.started += instance.OnXbtn;
                @Xbtn.performed += instance.OnXbtn;
                @Xbtn.canceled += instance.OnXbtn;
                @Bbtn.started += instance.OnBbtn;
                @Bbtn.performed += instance.OnBbtn;
                @Bbtn.canceled += instance.OnBbtn;
            }
        }
    }
    public _3DPlayerActions @_3DPlayer => new _3DPlayerActions(this);

    // 2DPlayer
    private readonly InputActionMap m__2DPlayer;
    private I_2DPlayerActions m__2DPlayerActionsCallbackInterface;
    private readonly InputAction m__2DPlayer_Select;
    private readonly InputAction m__2DPlayer_Rotate;
    private readonly InputAction m__2DPlayer_Grab;
    private readonly InputAction m__2DPlayer_Movement2D;
    private readonly InputAction m__2DPlayer_Jump2D;
    public struct _2DPlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public _2DPlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m__2DPlayer_Select;
        public InputAction @Rotate => m_Wrapper.m__2DPlayer_Rotate;
        public InputAction @Grab => m_Wrapper.m__2DPlayer_Grab;
        public InputAction @Movement2D => m_Wrapper.m__2DPlayer_Movement2D;
        public InputAction @Jump2D => m_Wrapper.m__2DPlayer_Jump2D;
        public InputActionMap Get() { return m_Wrapper.m__2DPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_2DPlayerActions set) { return set.Get(); }
        public void SetCallbacks(I_2DPlayerActions instance)
        {
            if (m_Wrapper.m__2DPlayerActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnSelect;
                @Rotate.started -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnRotate;
                @Grab.started -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnGrab;
                @Movement2D.started -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnMovement2D;
                @Movement2D.performed -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnMovement2D;
                @Movement2D.canceled -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnMovement2D;
                @Jump2D.started -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnJump2D;
                @Jump2D.performed -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnJump2D;
                @Jump2D.canceled -= m_Wrapper.m__2DPlayerActionsCallbackInterface.OnJump2D;
            }
            m_Wrapper.m__2DPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Movement2D.started += instance.OnMovement2D;
                @Movement2D.performed += instance.OnMovement2D;
                @Movement2D.canceled += instance.OnMovement2D;
                @Jump2D.started += instance.OnJump2D;
                @Jump2D.performed += instance.OnJump2D;
                @Jump2D.canceled += instance.OnJump2D;
            }
        }
    }
    public _2DPlayerActions @_2DPlayer => new _2DPlayerActions(this);
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface I_3DPlayerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnYbtn(InputAction.CallbackContext context);
        void OnSight(InputAction.CallbackContext context);
        void OnRightShoulder(InputAction.CallbackContext context);
        void OnXbtn(InputAction.CallbackContext context);
        void OnBbtn(InputAction.CallbackContext context);
    }
    public interface I_2DPlayerActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnMovement2D(InputAction.CallbackContext context);
        void OnJump2D(InputAction.CallbackContext context);
    }
}
