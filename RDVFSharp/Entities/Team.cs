using RDVFSharp.Entities;
using RDVFSharp.FightingLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace RDVFSharp.Entities
{
    public class Team
    {
        public List<Fighter> Fighters { get; set; }
        public Fighter Fighter { get; set; }
        public Battlefield Battlefield { get; set; }
        public List<Fighter> TeamRed { get; set; }
        public List<Fighter> TeamBlue { get; set; }
        public List<Fighter> TeamYellow { get; set; }
        public List<Fighter> TeamPurple { get; set; }
        public string TeamColor { get; set; }


        public void SetTeamColors()

        {
            if (Fighter.TeamColor == "red") TeamColor= "red";
            if (Fighter.TeamColor == "blue") TeamColor = "blue";
            if (Fighter.TeamColor == "yellow") TeamColor = "yellow";
            if (Fighter.TeamColor == "purple") TeamColor = "purple";
        }
                    
        public void JoinTeamRed()
        {
            if (TeamColor == "red") TeamRed.Add(Fighter);
        }

        public void JoinTeamBlue()
        {
            if (TeamColor == "blue") TeamBlue.Add(Fighter);
        }

        public void JoinTeamYellow()
        {
            if (TeamColor == "yellow") TeamYellow.Add(Fighter);
        }

        public void JoinTeamPurple()
        {
            if (TeamColor == "purple") TeamPurple.Add(Fighter);
        }




    }
}