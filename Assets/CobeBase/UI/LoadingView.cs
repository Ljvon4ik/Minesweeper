﻿using UnityEngine;
using System.Collections;

namespace CobeBase.UI
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup Curtain;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void Hide() => StartCoroutine(DoFadeIn());

        private IEnumerator DoFadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            Destroy(gameObject);
        }
    }
}
