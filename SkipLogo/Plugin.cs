using Dalamud.Game.Addon.Lifecycle;
using Dalamud.Game.Addon.Lifecycle.AddonArgTypes;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace SamplePlugin;

public sealed class Plugin : IDalamudPlugin
{
    private readonly IAddonLifecycle addonLifecycle;
    public Plugin(IAddonLifecycle AddonLifecycle)
    {
        addonLifecycle = AddonLifecycle;
        AddonLifecycle.RegisterListener(AddonEvent.PostSetup, "Logo", OnLogoPostSetup);
    }

    private unsafe void OnLogoPostSetup(AddonEvent type, AddonArgs args)
    {
        var addon = (AtkUnitBase*)args.Addon;
        var value = stackalloc AtkValue[1];
        value->Type = ValueType.Int;
        value->Int = 0;
        addon->FireCallback(1, value, (void*)1);
        addon->Hide(false, false, 1);
    }

    public void Dispose()
    {
        addonLifecycle.UnregisterListener(AddonEvent.PostSetup, "Logo", OnLogoPostSetup);
    }
}
