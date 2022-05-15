using System.Collections.Generic;

namespace RDVFSharp.Commands
{
    public class Tackle : Action
    {
        public override void ExecuteCommand(string character, IEnumerable<string> args, string channel)
        {
            var attacker = Plugin.CurrentBattlefield.GetActor();
            var target = Plugin.CurrentBattlefield.GetTarget();
            
            if ((attacker.IsRestrained == false && target.IsRestrained == false && attacker.IsRestraining == false && target.IsRestraining == false) && ((attacker.IsGrabbable == 0) || (attacker.IsGrabbable != target.IsGrabbable)))
            {
                base.ExecuteCommand(character, args, channel);
            }
            else
            {
                Plugin.FChatClient.SendMessageInChannel("You can't use Tackle when you already are in grappling range.", Plugin.Channel);
            }
        }
    }
}
