using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class SpawnOptionsCommand : Command
{

  [Inject]
  public OptionsManager gameManager { get; set; }

  [Inject]
  public List<Option> options { get; set; }

  public override void Execute()
  {
    gameManager.SpawnOptions(options);
  }
}
