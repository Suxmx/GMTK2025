//------------------------------------------------------------
// 此文件由工具自动生成
// 生成时间：2025-02-13 14:47:07
//------------------------------------------------------------


using MemoFramework;

namespace GMTK.EventArgs
{
    public class OnRequireRestartGame : MFEventArgs
    {
        public static OnRequireRestartGame Create()
        {
            OnRequireRestartGame args = MFRefPool.Acquire<OnRequireRestartGame>();
            return args;
        }


        public override void Clear()
        {
        }
    }
}