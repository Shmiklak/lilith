using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Lilith : StoryboardObjectGenerator
    {
        int beat = 49648 - 49048;
        public override void Generate()
        {
		    getRidOfBackground();
            angels(49648, 68848);

            angels(126448, 145648);

            var ice = GetLayer("ice").CreateSprite("sb/etc/ice.png", OsbOrigin.Centre);
            ice.Fade(120748,121048, 0, 1);
            ice.Fade(124048, 125848, 1, 0);
            ice.Scale(120748, 0.88);
            ice.Additive(120748, 125848);

            // var cloud = GetLayer("clouds").CreateSprite("sb/etc/cloud2.png", OsbOrigin.Centre);
            // cloud.Move(88048, 92848, new Vector2(110, 320), new Vector2(160, 320));
            // cloud.Fade(88048, 88048 + beat, 0, 0.6);
            // cloud.Fade(92848 - beat, 92848, 0.6, 0);
            // cloud.Additive(88048, 92848);

            // var cloud2 = GetLayer("clouds").CreateSprite("sb/etc/cloud1.png", OsbOrigin.Centre);
            // cloud2.Move(88048, 92848, new Vector2(370, 280), new Vector2(420, 280));
            // cloud2.Fade(88048, 88048 + beat, 0, 0.6);
            // cloud2.Fade(92848 - beat, 92848, 0.6, 0);
            // cloud2.Additive(88048, 92848);
            // cloud2.Scale(88048, 0.45);
            
        }

        public void getRidOfBackground() {
            var bitmap = GetMapsetBitmap(Beatmap.BackgroundPath);
            var bg = GetLayer("bg").CreateSprite(Beatmap.BackgroundPath, OsbOrigin.Centre);
            bg.Fade(0, 0);
        }

        public void angels(int startTime, int endTime) {
            var layer = GetLayer("kiai");

            Color4 bgColor = new Color4(20, 73, 139, 255);

            var bg = layer.CreateSprite("sb/etc/p.png", OsbOrigin.Centre);
            bg.Scale(startTime, 1000);
            bg.Fade(startTime, startTime + beat, 0, 1);
            bg.Color(startTime, endTime, bgColor, bgColor);
            bg.Fade(endTime - beat, endTime, 1, 0);

            var rayPosition = new Vector2(315, 0);

            var rayLayer = GetLayer("kiai_ray");
            var ray = rayLayer.CreateSprite("sb/etc/rays.png", OsbOrigin.Centre, rayPosition);
            ray.Fade(startTime, startTime + beat, 0, 0.4);
            ray.Rotate(startTime, endTime, 0, MathHelper.DegreesToRadians(180));
            ray.Additive(startTime, endTime);
            ray.Scale(startTime, 1);
            ray.Fade(endTime - beat, endTime, 0.4, 0);

            var ray2 = rayLayer.CreateSprite("sb/etc/rays.png", OsbOrigin.Centre, rayPosition);
            ray2.Fade(startTime, startTime + beat, 0, 0.4);
            ray2.Rotate(startTime, endTime, MathHelper.DegreesToRadians(-45), MathHelper.DegreesToRadians(45));
            ray2.Additive(startTime, endTime);
            ray2.Scale(startTime, 1);
            ray2.Fade(endTime - beat, endTime, 0.4, 0);

            var girlPosition = new Vector2(40, 240);

            var girl = GetLayer("kiai_girls").CreateSprite("sb/etc/girl.png", OsbOrigin.Centre, girlPosition);
            girl.Fade(startTime, startTime + beat, 0, 1);
            girl.Scale(startTime, 0.3);
            girl.Fade(endTime - beat, endTime, 1, 0);

            var girlPosition2 = new Vector2(600, 240);

            var girl2 = GetLayer("kiai_girls").CreateSprite("sb/etc/girl.png", OsbOrigin.Centre, girlPosition2);
            girl2.Fade(startTime, startTime + beat, 0, 1);
            girl2.Scale(startTime, 0.3);
            girl2.Fade(endTime - beat, endTime, 1, 0);
            girl2.FlipH(startTime, endTime);

        }
    }
}
