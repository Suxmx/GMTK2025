//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2025-02-13 14:47:07
//------------------------------------------------------------


using MemoFramework;

namespace GMTK.EventArgs
{
    public class OnSeasonChanged : MFEventArgs
    {
        public static OnSeasonChanged Create(ESeason season)
        {
            OnSeasonChanged args = MFRefPool.Acquire<OnSeasonChanged>();
            args.Season = season;
            return args;
        }

        public ESeason Season;

        public override void Clear()
        {
        }
    }
}