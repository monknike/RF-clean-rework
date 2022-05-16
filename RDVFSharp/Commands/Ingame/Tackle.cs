using System;
using RDVFSharp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDVFSharp.Commands
{
    public class Tackle : Action
    {
        public override void ExecuteCommand(string character, IEnumerable<string> args, string channel)
        {
            var attacker = Plugin.CurrentBattlefield.GetActor();
            var target = Plugin.CurrentBattlefield.GetTarget();
            var others = Plugin.CurrentBattlefield.Fighters.Where(x => x.Name != attacker.Name).OrderBy(x => new Random().Next()).ToList();
            var otherothers = Plugin.CurrentBattlefield.Fighters.Where(x => x.Name != target.Name).OrderBy(x => new Random().Next()).ToList();


            foreach (var otherother in otherothers)

            {
                foreach (var other in others)
                {
                    if ((!otherother.IsGrappling(target) && !target.IsGrappling(otherother) && !attacker.IsGrappling(other) && !other.IsGrappling(attacker) && !target.IsGrappling(attacker) && !attacker.IsGrappling(target) || (attacker.IsGrabbable != target.IsGrabbable)))
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
    }
}
