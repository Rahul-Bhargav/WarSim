using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

public class OptionsPanelMediator : Mediator
{

  [Inject]
  public OptionsPanelView optionsPanelView { get; set; }

  [Inject]
  public SpawnOptionsSignal spawnOptionsSignal { get; set; }

  [Inject]
  public ClearOptionsSignal clearOptionsSignal { get; set; }

  public override void OnRegister()
  {
    clearOptionsSignal.AddListener(optionsPanelView.ClearOptions);
    spawnOptionsSignal.AddListener(optionsPanelView.SpawnOptions);
  }
}
