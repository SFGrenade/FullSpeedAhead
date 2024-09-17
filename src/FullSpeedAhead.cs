using System.Reflection;
using Modding;
using SFCore.Utils;

namespace FullSpeedAhead;

public class FullSpeedAheadMod : Mod
{
    public FullSpeedAheadMod() : base("Full Speed Ahead")
    {
    }

    public override string GetVersion() => Util.GetVersion(Assembly.GetExecutingAssembly());

    public override void Initialize()
    {
        On.GameManager.FreezeMoment_int += (orig, self, type) =>
        {
            // type == 0 is `hero death anim` in `dream map zone`
            // type == 1 is gate clink? bridge/boss lever hit? dung death effect? kill freeze, hit by spikes/acid
            // type == 2 is ???
            // type == 3 is parry / nail_clash_tink
            // type == 4 is stun effect
            // type == 5 is ???
            if (type != 3)
            {
                orig(self, type);
            }
        };
    }
}