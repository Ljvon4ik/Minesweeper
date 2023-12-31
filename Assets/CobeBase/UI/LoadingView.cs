﻿using UnityEngine;
using System.Collections;

namespace CobeBase.UI
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _curtain;
        private void Awake()
        {
            if(gameObject.activeInHierarchy)
                gameObject.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
            _curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (_curtain.alpha > 0)
            {
                _curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }
    }
}
