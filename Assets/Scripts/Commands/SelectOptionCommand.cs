using System;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class SelectOptionCommand : Command
{
  [Inject]
  public OptionsManager optionsManager { get; set; }

  [Inject]
  public string selectedOption { get; set; }

  [Inject]
  public SpawnOptionsSignal spawnOptionsSignal { get; set; }

  [Inject]
  public ClearOptionsSignal clearOptionsSignal { get; set; }

  public override void Execute()
  {
    optionsManager.SpawnOptions.AddListener(SpawnOptions);
    optionsManager.ClearOptions.AddListener(ClearOptions);


    optionsManager.OptionSelected(selectedOption);
  }

  private void ClearOptions()
  {
    clearOptionsSignal.Dispatch();
  }

  private void SpawnOptions(List<Option> options)
  {
    spawnOptionsSignal.Dispatch(options);
  }
}
