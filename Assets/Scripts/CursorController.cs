using UnityEngine;
using UnityEngine.InputSystem;

namespace PickNOre
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _pointerPositionAction;
        private RectTransform _cursorTransform;
        private Canvas _canvas;
        private RectTransform _canvasRectTransform;
        private Camera _canvasCamera;

        private void Awake()
        {
            _cursorTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
            if (_canvas != null)
            {
                _canvasRectTransform = _canvas.GetComponent<RectTransform>();
                _canvasCamera = _canvas.renderMode == RenderMode.ScreenSpaceOverlay
                    ? null
                    : _canvas.worldCamera;
            }
        }

        private void OnEnable()
        {
            Cursor.visible = false;
            _pointerPositionAction.action.performed += OnPointerPositionChanged;
        }
        private void OnDisable()
        {
            Cursor.visible = true;
            _pointerPositionAction.action.performed -= OnPointerPositionChanged;
        }
        private void OnPointerPositionChanged(InputAction.CallbackContext ctx)
        {
            if (_cursorTransform == null || _canvasRectTransform == null) return;
            var mousePosition = ctx.ReadValue<Vector2>();
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, mousePosition, _canvasCamera, out var localPoint))
            {
                _cursorTransform.anchoredPosition = localPoint;
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
