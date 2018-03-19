using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class GetInitialTurnCommand : Command
{

  [Inject]
  public NetworkService networkService { get; set; }

  [Inject]
  public OptionsManager gameManager {get; set;}

  [Inject]
  public SpawnOptionsSignal spawnOptionsSignal { get; set; }

    [Inject]
  public ClearOptionsSignal clearOptionsSignal { get; set; }

  public override void Execute()
  {
    networkService.OptionsRecievedSignal.AddListener(SetInitialOptions);
    networkService.GetTypes();
  }

  void SetInitialOptions(Options options)
  {
    gameManager.allOptions = options;
    List<Option> parentOptions = options.data.FindAll(option => option.parent == null);
    clearOptionsSignal.Dispatch();
    spawnOptionsSignal.Dispatch(parentOptions);
  }
}
