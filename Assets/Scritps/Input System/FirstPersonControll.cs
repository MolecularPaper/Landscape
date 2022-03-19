// GENERATED AUTOMATICALLY FROM 'Assets/Scritps/Input System/FirstPersonControll.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @FirstPersonControll : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @FirstPersonControll()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FirstPersonControll"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7cd53a4a-e505-4be0-b961-7704da23340b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b69aea4c-0e3e-42f6-a268-5de0d594db0d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ViewControll"",
                    ""type"": ""Value"",
                    ""id"": ""fbab1342-fd65-492a-9a82-49e9d847a2d6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fcf907b1-71c0-4973-8171-6f3102489c50"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""945d9ce5-2579-4179-bb6c-8fe239ad243d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""e67b763a-1155-4291-9f30-08925bf5ad15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d4b6c2bd-927e-4ef5-9328-8b71b8428242"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""a099163f-d355-4c98-84cf-d92bbbad7466"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""d30beb3b-ceb6-4dfd-9777-3316850302ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""FlashLight"",
                    ""type"": ""Button"",
                    ""id"": ""95ece48c-4201-488b-a873-fb73e7149d00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""089486f9-188c-46c9-8bfc-7cd1eb3eac41"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""39054960-13d5-4006-8470-0c71ca4be2b4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b767780-de21-424f-8cae-e4792ccaf17c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""84250853-0ace-4314-9c18-a394d4a72963"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""853ca3fd-62a1-48d3-b771-07f40fd08f4b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""776db212-0285-48b4-931d-8928068ad68c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2155fdf9-776f-41d6-b183-7e661b9470d6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewControll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a751f40e-287b-42d0-b316-d34ee09dcdbc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ViewControll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4f1ad7a-c6ea-41b0-9ad3-da32479de796"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e026622c-3d7f-4a0d-a9c2-5e1519304eaf"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10bfefeb-cbfa-4252-80ff-2cc3a1453398"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feb9e063-2068-4ad1-a1c2-d2bf104196de"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f3f2ca3-ba78-49a0-b62b-3cdceaaa2594"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08ff8e0d-74b7-4483-957c-3f80c4f6c892"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cba96e32-18ca-4851-9a46-09e1777184e3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95f82be3-b5c4-4721-bb4f-bebeefe3a55a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4371b206-4e64-4347-bf3f-56a18b282f19"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FlashLight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""bee986cb-8b99-4e66-bbda-32471ce6279e"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""d672ab44-0a1c-4344-a256-75e89a1b462e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""59be9877-a6b4-472a-ab2c-a6a0bd8bc6f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""GetItem "",
                    ""type"": ""Button"",
                    ""id"": ""72cf7670-4615-41f6-b251-fbe0497365b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0120576b-0e5b-401d-9e1f-2bf3f8fd93c7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""370b88cb-07fe-470b-a31e-c96c1ee536cc"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a883b48c-33b9-401b-b378-b3371a30e16b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GetItem "",
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
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_ViewControll = m_Player.FindAction("ViewControll", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
        m_Player_Interaction = m_Player.FindAction("Interaction", throwIfNotFound: true);
        m_Player_FlashLight = m_Player.FindAction("FlashLight", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Inventory = m_UI.FindAction("Inventory", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_GetItem = m_UI.FindAction("GetItem ", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_ViewControll;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Run;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Crouch;
    private readonly InputAction m_Player_Interaction;
    private readonly InputAction m_Player_FlashLight;
    public struct PlayerActions
    {
        private @FirstPersonControll m_Wrapper;
        public PlayerActions(@FirstPersonControll wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @ViewControll => m_Wrapper.m_Player_ViewControll;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Run => m_Wrapper.m_Player_Run;
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Crouch => m_Wrapper.m_Player_Crouch;
        public InputAction @Interaction => m_Wrapper.m_Player_Interaction;
        public InputAction @FlashLight => m_Wrapper.m_Player_FlashLight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @ViewControll.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnViewControll;
                @ViewControll.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnViewControll;
                @ViewControll.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnViewControll;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Run.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRun;
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Crouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCrouch;
                @Interaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @Interaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteraction;
                @FlashLight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlashLight;
                @FlashLight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlashLight;
                @FlashLight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFlashLight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @ViewControll.started += instance.OnViewControll;
                @ViewControll.performed += instance.OnViewControll;
                @ViewControll.canceled += instance.OnViewControll;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interaction.started += instance.OnInteraction;
                @Interaction.performed += instance.OnInteraction;
                @Interaction.canceled += instance.OnInteraction;
                @FlashLight.started += instance.OnFlashLight;
                @FlashLight.performed += instance.OnFlashLight;
                @FlashLight.canceled += instance.OnFlashLight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Inventory;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_GetItem;
    public struct UIActions
    {
        private @FirstPersonControll m_Wrapper;
        public UIActions(@FirstPersonControll wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_UI_Inventory;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @GetItem => m_Wrapper.m_UI_GetItem;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @GetItem.started -= m_Wrapper.m_UIActionsCallbackInterface.OnGetItem;
                @GetItem.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnGetItem;
                @GetItem.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnGetItem;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @GetItem.started += instance.OnGetItem;
                @GetItem.performed += instance.OnGetItem;
                @GetItem.canceled += instance.OnGetItem;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnViewControll(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnFlashLight(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnInventory(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnGetItem(InputAction.CallbackContext context);
    }
}
