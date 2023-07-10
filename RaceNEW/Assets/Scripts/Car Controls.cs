// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Car Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CarControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CarControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Car Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f110f603-e246-4505-95f2-f70bfccd1795"",
            ""actions"": [
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""686ac36e-4374-47f9-b4f5-e2ed6859f301"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Acceleration"",
                    ""type"": ""Value"",
                    ""id"": ""ce0792ee-3f8d-45b1-bc71-74f8aae018e7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""015f09c2-8511-4997-a0ee-b87af2d8bf99"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6387d18f-6367-43f4-86f0-9e337a63e7ce"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""6a45fc68-ec73-4810-a4f5-e2d198c459da"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""fc32e2cc-523e-45bd-af9a-bfde6861b4b9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""65a0e1b2-2270-416e-963c-7ea7fc89c217"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Acceleration"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""77a9fd9b-5fcb-4a64-af51-217dbf200d2d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""43ec6da5-039f-46ad-8733-56c215ae6cee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e12d8d9a-9378-45a7-8fff-a2102b4e86f2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""d62d2bea-1dde-4753-b7ce-4670c2d026b1"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Value"",
                    ""id"": ""328b7f25-1871-4a9c-8c2d-d212f4feb6d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Activate Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""7f013e63-5dd1-4fc4-9c01-5fa4022dbfa5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f1422f2-23d6-4846-a450-d37545d9a73d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62340ec3-e777-47e7-ad4e-33682c46fbd7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Activate Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_HandBrake = m_Player.FindAction("HandBrake", throwIfNotFound: true);
        m_Player_Acceleration = m_Player.FindAction("Acceleration", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Rotation = m_Camera.FindAction("Rotation", throwIfNotFound: true);
        m_Camera_ActivateRotation = m_Camera.FindAction("Activate Rotation", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_HandBrake;
    private readonly InputAction m_Player_Acceleration;
    private readonly InputAction m_Player_Rotate;
    public struct PlayerActions
    {
        private @CarControls m_Wrapper;
        public PlayerActions(@CarControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @HandBrake => m_Wrapper.m_Player_HandBrake;
        public InputAction @Acceleration => m_Wrapper.m_Player_Acceleration;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @HandBrake.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHandBrake;
                @Acceleration.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
                @Acceleration.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
                @Acceleration.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAcceleration;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
                @Acceleration.started += instance.OnAcceleration;
                @Acceleration.performed += instance.OnAcceleration;
                @Acceleration.canceled += instance.OnAcceleration;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Rotation;
    private readonly InputAction m_Camera_ActivateRotation;
    public struct CameraActions
    {
        private @CarControls m_Wrapper;
        public CameraActions(@CarControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotation => m_Wrapper.m_Camera_Rotation;
        public InputAction @ActivateRotation => m_Wrapper.m_Camera_ActivateRotation;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Rotation.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @ActivateRotation.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnActivateRotation;
                @ActivateRotation.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnActivateRotation;
                @ActivateRotation.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnActivateRotation;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @ActivateRotation.started += instance.OnActivateRotation;
                @ActivateRotation.performed += instance.OnActivateRotation;
                @ActivateRotation.canceled += instance.OnActivateRotation;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface IPlayerActions
    {
        void OnHandBrake(InputAction.CallbackContext context);
        void OnAcceleration(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnRotation(InputAction.CallbackContext context);
        void OnActivateRotation(InputAction.CallbackContext context);
    }
}
