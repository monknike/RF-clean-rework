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

            var tackleok = 0;

            
            var attacker = Plugin.CurrentBattlefield.GetActor();
            var target = Plugin.CurrentBattlefield.GetTarget();
            var others = Plugin.CurrentBattlefield.Fighters.Where(x => x.Name != attacker.Name);
            var otherothers = Plugin.CurrentBattlefield.Fighters.Where(x => x.Name != target.Name);

            foreach (var other in others)
            { 
                foreach (var otherother in otherothers)
                { 
                    if ((!otherother.IsGrappling(target) && !target.IsGrappling(otherother) && !attacker.IsGrappling(other) && !other.IsGrappling(attacker) && !target.IsGrappling(attacker) && !attacker.IsGrappling(target) && (attacker.IsGrabbable != target.IsGrabbable) || (attacker.IsGrabbable == 0)))
                    {
                        tackleok += 1;
                    }
                    else
                    {
                        Plugin.FChatClient.SendMessageInChannel("You can't use Tackle when you already are in grappling range, or on someone that's being grappled by/grappling someone else.", Plugin.Channel);
                    }
                }
            }

            if (tackleok == 1)
            {
                base.ExecuteCommand(character, args, channel);
                tackleok = 0;
            }
        }
    }
}
