using System;
using DG.Tweening;
using MemoFramework;
using UnityEngine;

namespace GMTK
{
    public class DefaultCutsceneAgent : CutsceneAgent
    {
        public override Transform CutsceneView => transform;
        [SerializeField] private CanvasGroup cg;

        public override void EnterCutscene(float duration,Action onEnd)
        {
            cg.alpha = 0;
            cg.DOFade(1, duration).OnComplete(() => onEnd?.Invoke());
        }

        public override void FadeCutscene(float duration,Action onEnd)
        {
            cg.alpha = 1;
            cg.DOFade(0, duration).OnComplete(() => onEnd?.Invoke());
        }
    }
}