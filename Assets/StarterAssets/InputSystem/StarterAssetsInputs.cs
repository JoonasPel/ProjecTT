using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		// char inputs
		public Vector2 move { get; private set;}
		public Vector2 look { get; private set;}
		public bool jump { get; set;}
		public bool sprint { get; private set;}
		public bool attack { get; private set;}
		public bool mining { get; private set;}
		
		// movement settings
		public bool analogMovement { get; private set;}
		
		// mouse cursor settings
		public bool cursorLocked { get; private set;} = true;
		public bool cursorInputForLook { get; private set;} = true;


		// create static singleton instance
		public static StarterAssetsInputs Instance;
		void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
		}

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}

		public void OnMining(InputValue value)
		{
			MiningInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
		}

		public void MiningInput(bool newMiningState)
		{
			mining = newMiningState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}