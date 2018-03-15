using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class OptionMediator : Mediator
{

  [Inject]
  public OptionView optionView { get; set; }

  [Inject]
  public OptionSelectedSignal optionSelectedSignal {get; set;}

  public override void OnRegister()
  {
    optionView.OptionClickedSignal.AddListener( (string type) => optionSelectedSignal.Dispatch(type));
  }
}
