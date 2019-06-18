namespace Lib.FaceDetect
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class FaceDetectService : IFaceDetectService
    {
        private HttpClient _client;
        private EmotionServiceResult _result;

        public FaceDetectService(HttpClient client)
        {
            _client = client;
        }

        public async Task<EmotionServiceResult> MakeAnalysis(string image, params Attribute[] parameters)
        {
            if (string.IsNullOrEmpty(image))
            {
                throw new System.ArgumentException(nameof(image));
            }

            var attributes = "emotion,age";
            if (parameters != null && parameters.Count()>0)
            {
                attributes = string.Join(",", parameters.Select(p => p.ToString().ToLower()).ToArray());
            }
            var requestParameters = $"returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes={attributes}";

            byte[] imageData = GetImage(image);

            using (ByteArrayContent content = new ByteArrayContent(imageData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                HttpResponseMessage response = await _client.PostAsync($"?{requestParameters}", content);

                if (response.IsSuccessStatusCode)
                {
                    string contentString = await response.Content.ReadAsStringAsync();
                    var analysisResult = JsonConvert.DeserializeObject<FaceResult[]>(contentString);

                    _result = new EmotionServiceResult();
                    _result.Faces = analysisResult;
                }
                else
                {
                    throw new System.InvalidOperationException(response.ReasonPhrase);
                }
            }

            return _result;
        }

        byte[] GetImage(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
    }
}
