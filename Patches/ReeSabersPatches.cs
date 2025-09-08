#if REESABERS
using ReeSabers;
using SiraUtil.Affinity;

namespace IzaTweaks.Patches
{
    public class ReeSabersPatches : IAffinity
    {
        [AffinityPrefix]
        [AffinityPatch(typeof(HsbTransform), "HsbTransform", AffinityMethodType.Constructor, null, typeof(ColorTransformType), typeof(float), typeof(float), typeof(float), typeof(float))]
        public void HsbTransformPatch(ref ColorTransformType type)
        {
            if (Plugin.Config.ReeSabersNotesColorShift && type == ColorTransformType.NotesColor)
                type = ColorTransformType.HueShift;
        }
    }
}
#endif
