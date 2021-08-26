// GENERATED AUTOMATICALLY FROM 'Assets/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""actionMap"",
            ""id"": ""348725da-fb34-4ea6-b761-331bcf0e8bab"",
            ""actions"": [
                {
                    ""name"": ""fillipDown"",
                    ""type"": ""Button"",
                    ""id"": ""be21bf0f-a695-441d-95a6-455913f9314e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""889f4b7e-cf09-40c4-9bf1-fc9e245fb6a2"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fillipUp"",
                    ""type"": ""Button"",
                    ""id"": ""6257a384-4c43-4e20-87c1-2e43a8f221c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2bc17493-e63c-4492-bc61-6ee3eb1db67a"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fillipDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5357e8e2-bd77-466a-80b2-98dfd16dde08"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a4b524e-05ee-4dd8-96a2-cc9bc25508b5"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fillipUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // actionMap
        m_actionMap = asset.FindActionMap("actionMap", throwIfNotFound: true);
        m_actionMap_fillipDown = m_actionMap.FindAction("fillipDown", throwIfNotFound: true);
        m_actionMap_movement = m_actionMap.FindAction("movement", throwIfNotFound: true);
        m_actionMap_fillipUp = m_actionMap.FindAction("fillipUp", throwIfNotFound: true);
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

    // actionMap
    private readonly InputActionMap m_actionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_actionMap_fillipDown;
    private readonly InputAction m_actionMap_movement;
    private readonly InputAction m_actionMap_fillipUp;
    public struct ActionMapActions
    {
        private @NewControls m_Wrapper;
        public ActionMapActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @fillipDown => m_Wrapper.m_actionMap_fillipDown;
        public InputAction @movement => m_Wrapper.m_actionMap_movement;
        public InputAction @fillipUp => m_Wrapper.m_actionMap_fillipUp;
        public InputActionMap Get() { return m_Wrapper.m_actionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @fillipDown.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipDown;
                @fillipDown.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipDown;
                @fillipDown.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipDown;
                @movement.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @fillipUp.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipUp;
                @fillipUp.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipUp;
                @fillipUp.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnFillipUp;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @fillipDown.started += instance.OnFillipDown;
                @fillipDown.performed += instance.OnFillipDown;
                @fillipDown.canceled += instance.OnFillipDown;
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @fillipUp.started += instance.OnFillipUp;
                @fillipUp.performed += instance.OnFillipUp;
                @fillipUp.canceled += instance.OnFillipUp;
            }
        }
    }
    public ActionMapActions @actionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnFillipDown(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnFillipUp(InputAction.CallbackContext context);
    }
}
