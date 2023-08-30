using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgetMeNot.Common
{
    public static class FmnModContent
    {
        public static Texture2D GetTexture( string path )
        {
            return ModContent.Request<Texture2D>( string.Concat( "ForgetMeNot/", path ), ReLogic.Content.AssetRequestMode.ImmediateLoad ).Value;
        }
    }
}