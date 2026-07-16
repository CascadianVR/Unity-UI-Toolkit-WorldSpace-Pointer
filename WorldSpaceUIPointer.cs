// MIT License
//
// Copyright (c) 2026 Cascadian
// Website: https://cascadian.coffee
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using PointerType = UnityEngine.PointerType;

namespace Cascadian
{
    public class WorldSpaceUIPointer : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance = 2.0f;
        [SerializeField] private LayerMask _uiLayerMask;
        
        private VisualElement _currentHover;
        
        private void Update()
        {
            // Send out raycast and find UI elements
            bool didHit = Physics.Raycast(
                transform.position, 
                transform.forward,
                out RaycastHit hit, 
                _interactionDistance,
                _uiLayerMask
            );

            if (!didHit)
            {
                _currentHover = null;
                return;
            }
            
            UIDocument document = hit.collider.gameObject.GetComponent<UIDocument>();
            if (!document) return;
            
            VisualElement root = document.rootVisualElement;
            Vector3 panelPosition = hit.collider.transform.InverseTransformPoint(hit.point);
            
            HandlePointerMove(root, panelPosition);
            HandlePointerDown(panelPosition);
            HandlePointerUp(panelPosition);
        }
        
        /// <summary>
        /// Handles the pointer move event by sending a PointerMoveEvent to the root visual element of the UIDocument.
        /// </summary>
        /// <param name="root">The root visual element of the UIDocument.</param>
        /// <param name="panelPosition">The position of the pointer in panel coordinates.</param>
        private void HandlePointerMove(VisualElement root, Vector3 panelPosition)
        {
            Event e = new Event
            {
                type = EventType.MouseMove, 
                mousePosition = panelPosition, 
                pointerType = PointerType.Mouse
            };
            
            using (PointerMoveEvent move = PointerMoveEvent.GetPooled(e)) root.panel.visualTree.SendEvent(move);
            _currentHover = root.panel.Pick(panelPosition);
        }

        /// <summary>
        /// Handles the pointer down event by sending a PointerDownEvent to the currently hovered visual element.
        /// </summary>
        /// <param name="panelPosition">The position of the pointer in panel coordinates.</param>
        private void HandlePointerDown(Vector3 panelPosition)
        {
            if (!Mouse.current.leftButton.wasPressedThisFrame || _currentHover == null) return;

            Event e = new Event
            {
                type = EventType.MouseDown, 
                mousePosition = panelPosition, button = 0, 
                pointerType = PointerType.Mouse
            };

            using PointerDownEvent down = PointerDownEvent.GetPooled(e);
            down.target = _currentHover;
            _currentHover.SendEvent(down);
        }

        /// <summary>
        /// Handles the pointer up event by sending a PointerUpEvent to the currently hovered visual element.
        /// </summary>
        /// <param name="panelPosition">The position of the pointer in panel coordinates.</param>
        private void HandlePointerUp(Vector3 panelPosition)
        {
            if (!Mouse.current.leftButton.wasReleasedThisFrame || _currentHover == null) return;

            Event e = new Event
            {
                type = EventType.MouseUp, 
                mousePosition = panelPosition, button = 0, 
                pointerType = PointerType.Mouse
            };

            using PointerUpEvent up = PointerUpEvent.GetPooled(e);
            up.target = _currentHover;
            _currentHover.SendEvent(up);
        }
    }
}