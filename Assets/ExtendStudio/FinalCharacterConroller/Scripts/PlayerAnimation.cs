using UnityEngine;

namespace ExtendStudio.FinalCharacterController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float locomotionBlendSpeed = 4f;

        private PlayerLocomotionInput _plaerLocomotionInput;

        private static int inputXHash = Animator.StringToHash("inputX");
        private static int inputYHash = Animator.StringToHash("inputY");

        private Vector3 _currentBlendInput = Vector3.zero;

        private void Awake()
        {
            _plaerLocomotionInput = GetComponent<PlayerLocomotionInput>();
        }

        private void Update()
        {
            UpdateAnimationState();
        }

        private void UpdateAnimationState()
        {
            Vector2 inputTarget = _plaerLocomotionInput.MovementInput;
            _currentBlendInput = Vector3.Lerp(_currentBlendInput, inputTarget, locomotionBlendSpeed * Time.deltaTime);

            _animator.SetFloat(inputXHash, _currentBlendInput.x);
            _animator.SetFloat(inputYHash, _currentBlendInput.y);
        }
    }
}
