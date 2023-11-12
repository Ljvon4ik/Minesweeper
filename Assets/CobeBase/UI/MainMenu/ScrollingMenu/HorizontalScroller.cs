﻿using Assets.CobeBase.UI.Services;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CobeBase.UI.MainMenu.ScrollingMenu
{
    [RequireComponent(typeof(ScrollRect))]
    public class HorizontalScroller : MonoBehaviour, IEndDragHandler, IBeginDragHandler
    {
        [Range(1f, 60f)]
        [SerializeField]
        private float _panOffset = 40f;

        [Range(5f, 20f)]
        [SerializeField]
        private float _snapSpeed = 10f;

        [SerializeField]
        [Tooltip("Button to go to the previous page. (optional)")]
        private Button _previousButton;

        [SerializeField]
        [Tooltip("Button to go to the next page. (optional)")]
        private Button _nextButton;

        private ScrollRect _scrollRect;
        private RectTransform _contentRect;
        private GameObject[] _panels;
        private Vector2[] _panelsPos;

        private CompositeDisposable _disposables = new();
        private IntReactiveProperty _selectedPanelID = new();
        private ReactiveProperty<GameObject> SelectedPanel = new();

        private bool _isDragging;
        private Vector2 _contentVector;

        private int _minValuePanelID;
        private int _maxValuePanelID;

        private ILevelPanelsStorage _levelPanelsStorage;

        public void Init(ILevelPanelsStorage levelPanelsStorage)
        {
            _levelPanelsStorage = levelPanelsStorage;
        }

        private void Start()
        {
            _scrollRect = GetComponent<ScrollRect>();
            _contentRect = _scrollRect.content.GetComponent<RectTransform>();
            _scrollRect.inertia = false;

            InitializePanelsArray();
            MovePanelsToDefaultPositions();
            InitializePanelsPosArray();
            InitializeLimitsValuesPanelID();
            Subscriptions();
        }

        private void Subscriptions()
        {
            if(_previousButton && _nextButton)
            {
                _previousButton.OnClickAsObservable().Subscribe(_ => MoveToPreviousPanel()).AddTo(_disposables);

                _nextButton.OnClickAsObservable().Subscribe(_ => MoveToNextPanel()).AddTo(_disposables);

                _selectedPanelID.Subscribe(_panelID =>
                {
                    SelectedPanel.Value = _panels[_panelID];
                    _levelPanelsStorage?.UpdateSelectedPanel(SelectedPanel.Value);
                    }).AddTo(_disposables);

                _selectedPanelID.Where(x => x == _minValuePanelID)
                .Subscribe(_ => _previousButton.interactable = false).AddTo(_disposables);

                _selectedPanelID.Where(x => x != _minValuePanelID)
                .Subscribe(_ => _previousButton.interactable = true).AddTo(_disposables);

                _selectedPanelID.Where(x => x == _maxValuePanelID)
                .Subscribe(_ => _nextButton.interactable = false).AddTo(_disposables);

                _selectedPanelID.Where(x => x != _maxValuePanelID)
                .Subscribe(_ => _nextButton.interactable = true).AddTo(_disposables);
            }

        }

        private void InitializeLimitsValuesPanelID()
        {
            _minValuePanelID = 0;
            _maxValuePanelID = _panelsPos.Length - 1;
        }

        private void MoveToPreviousPanel()
        {
            if(_previousButton.interactable)
                _selectedPanelID.Value--;
        }

        private void MoveToNextPanel()
        {
            if (_nextButton.interactable)
                _selectedPanelID.Value++;
        }

        private void FixedUpdate()
        {
            if(!_isDragging)
            {
                _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _panelsPos[_selectedPanelID.Value].x, _snapSpeed * Time.fixedDeltaTime);
                _contentRect.anchoredPosition = _contentVector;
            }
        }

        private void InitializePanelsPosArray()
        {
            int lenght = _panels.Length;
            _panelsPos = new Vector2[lenght];

            for (int i = 0; i < lenght; i++)
            {
                _panelsPos[i] = -_panels[i].transform.localPosition;
            }

        }

        private void MovePanelsToDefaultPositions()
        {
            for (int i = 0; i < _panels.Length; i++)
            {
                if (i == 0) continue;

                float xPos = _panels[i - 1].transform.localPosition.x 
                    + _panels[i - 1].GetComponent<RectTransform>().sizeDelta.x
                    + _panOffset;
                float yPos = _panels[i].transform.localPosition.y;
                Vector2 pos = new Vector2(xPos, yPos);

                _panels[i].transform.localPosition = pos;
            }
        }

        private void InitializePanelsArray()
        {
            var childCount = _scrollRect.content.childCount;

            _panels = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                _panels[i] = _scrollRect.content.transform.GetChild(i).gameObject;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float nearstPos = float.MaxValue;

            for (int i = 0; i < _panelsPos.Length; i++)
            {
                float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _panelsPos[i].x);
                if (distance < nearstPos)
                {
                    nearstPos = distance;
                    _selectedPanelID.Value = i;
                }
            }

            _isDragging = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
        }
    }
}
