using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class SelectOptionCommand : Command
{
  [Inject]
  public OptionsManager gameManager { get; set; }

  [Inject]
  public string selectedOption { get; set; }

  public override void Execute()
  {
    Debug.Log(selectedOption);
    gameManager.OptionSelected(selectedOption);
  }
}
