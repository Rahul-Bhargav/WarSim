using System.Collections;
using System.Collections.Generic;
using SocketIO;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

public class WarSimContext : MVCSContext
{

  public WarSimContext(MonoBehaviour view) : base(view) { }

  protected override void mapBindings()
  {
    base.mapBindings();

    mediationBinder.Bind<StartButtonView>().To<StartButtonMediator>();
    mediationBinder.Bind<OptionView>().To<OptionMediator>();

    NetworkService networkService = GameObject.FindGameObjectWithTag("NetworkHelper").GetComponent<NetworkService>();
    injectionBinder.Bind<NetworkService>().ToValue(networkService);

    OptionsManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<OptionsManager>();
    injectionBinder.Bind<OptionsManager>().To(gameManager);

    commandBinder.Bind<StartSignal>().To<GetInitialTurnCommand>();
    commandBinder.Bind<SpawnOptionsSignal>().To<SpawnOptionsCommand>();
    commandBinder.Bind<GetChildrenSignal>().To<GetChildrenCommand>();
    commandBinder.Bind<OptionSelectedSignal>().To<SelectOptionCommand>();
  }

  public override void Launch()
  {
    base.Launch();
  }
}
