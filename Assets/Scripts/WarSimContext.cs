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
    mediationBinder.Bind<OptionsPanelView>().To<OptionsPanelMediator>();

    NetworkService networkService = GameObject.FindGameObjectWithTag("NetworkHelper").GetComponent<NetworkService>();
    injectionBinder.Bind<NetworkService>().ToValue(networkService);

    OptionsManager optionsManager = GameObject.FindGameObjectWithTag("OptionsManager").GetComponent<OptionsManager>();
    injectionBinder.Bind<OptionsManager>().To(optionsManager);

    injectionBinder.Bind<SpawnOptionsSignal>().ToSingleton();
    injectionBinder.Bind<ClearOptionsSignal>().ToSingleton();

    commandBinder.Bind<StartSignal>().To<GetInitialTurnCommand>();
    commandBinder.Bind<GetChildrenSignal>().To<GetChildrenCommand>();
    commandBinder.Bind<OptionSelectedSignal>().To<SelectOptionCommand>();
  }
}
