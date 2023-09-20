using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetMeNot.Common.Utils
{
    public static class NpcClassify
    {
        public static List<int> Birds = new List<int>( )
        {
            NPCID.Bird,
            NPCID.BirdBlue,
            NPCID.BirdRed
        };

        public static List<int> Slimes = new List<int>( )
        {
            NPCID.RedSlime,
            NPCID.BlackSlime,
            NPCID.GreenSlime,
            NPCID.YellowSlime,
            NPCID.BabySlime,
            NPCID.Slimeling,
            NPCID.Pinky,
            NPCID.BlueSlime,

        };

        /// <summary>
        /// 判断 Npc 是否属于鸟类.
        /// </summary>
        /// <param name="npc">进行判断的 Npc.</param>
        /// <returns></returns>
        public static bool IsBird( this NPC npc ) => Birds.Contains( npc.type );
        
        public static bool IsSlime( this NPC npc ) => Slimes.Contains( npc.type );


    }
    public class NpcClassify_ModCall : ModSystem
    {
    }
}