using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class StartButtonMediator : Mediator
{

  [Inject]
  public StartButtonView view { get; set; }

  [Inject]
  public StartSignal startSignal { get; set; }

  public override void OnRegister() {
    view.startButtonClickedSignal.AddListener(() => startSignal.Dispatch());
  }

}
