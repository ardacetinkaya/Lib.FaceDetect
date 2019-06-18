namespace Lib.FaceDetect
{
    using System.Threading.Tasks;

    public interface IFaceDetectService
    {
        Task<EmotionServiceResult> MakeAnalysis(string image, params Attribute[] parameters);
    }
}
