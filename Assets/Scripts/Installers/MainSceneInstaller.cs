using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainSceneInstaller : MonoInstaller<MainSceneInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        UiStyleDefinition uiStyle = Resources.Load<UiStyleDefinition>("UI/ScriptableObjects/SparvisUiStyle");
        Container.Bind<UiStyleDefinition>().FromInstance(uiStyle);

        //Logic Bindings
        Container.BindInterfacesAndSelfTo<UserService>().AsSingle();
        Container.BindInterfacesAndSelfTo<LocalizationService>().AsSingle();
        Container.BindInterfacesAndSelfTo<IAPService>().AsSingle();
        Container.BindInterfacesAndSelfTo<ContentService>().AsSingle();
        Container.BindInterfacesAndSelfTo<DownloadService>().AsSingle();
        Container.BindInterfacesAndSelfTo<GamesService>().AsSingle();

        //Games Bindings
        //Container.BindInterfacesAndSelfTo<GameManager>().FromComponentInNewPrefab(uiStyle.games).AsSingle();
        //Container.BindInterfacesAndSelfTo<GameManager>().FromComponentInNewPrefab(uiStyle.atwGame).AsSingle();

        //Signals Bindings
        Container.DeclareSignal<NewPlayerSignal>();
        //Container.DeclareSignal<UsernameUpdateSignal>();
        //Container.DeclareSignal<UserAvatareUpdateSignal>();
        Container.DeclareSignal<VolumeChangeSignal>();
        //Container.DeclareSignal<MarketplaceItemSelectionSignal>();

        //Ui Bindings
        Container.Bind<Canvas>().FromComponentInNewPrefabResource("UI/Prefabs/Canvas").AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UiOrganizer>().AsSingle();
        Container.BindInterfacesAndSelfTo<Screen1>().FromComponentInNewPrefab(uiStyle.screen1).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Screen2>().FromComponentInNewPrefab(uiStyle.screen2).AsSingle();
        //Container.BindInterfacesAndSelfTo<HomeScreen>().FromComponentInNewPrefab(uiStyle.homeScreen).AsSingle();
    }
}