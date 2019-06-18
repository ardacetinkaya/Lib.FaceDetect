namespace Lib.FaceDetect
{
    using System;
    using System.Linq.Expressions;

    public partial class FaceResult : IFaceDetectResult
    {
        public bool IsAngry(Expression<Func<double, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return FaceAttributes.Emotion.Anger > 0.8;
            }

            var compiled = predicate.Compile();
            var result = compiled.Invoke(FaceAttributes.Emotion.Anger);

            return result;
        }

        public bool IsHappy(Expression<Func<double, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return FaceAttributes.Emotion.Happiness > 0.8;
            }
            var compiled = predicate.Compile();
            var result = compiled.Invoke(FaceAttributes.Emotion.Happiness);

            return result;
        }
        public bool IsSad(Expression<Func<double, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return FaceAttributes.Emotion.Sadness > 0.8;
            }
            var compiled = predicate.Compile();
            var result = compiled.Invoke(FaceAttributes.Emotion.Sadness);

            return result;
        }
        public bool IsSurprise(Expression<Func<double, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return FaceAttributes.Emotion.Surprise > 0.8;
            }
            var compiled = predicate.Compile();
            var result = compiled.Invoke(FaceAttributes.Emotion.Surprise);

            return result;
        }
        public bool IsDisgust(Expression<Func<double, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return FaceAttributes.Emotion.Disgust > 0.8;
            }
            var compiled = predicate.Compile();
            var result = compiled.Invoke(FaceAttributes.Emotion.Disgust);

            return result;
        }

        public Mood GetMood()
        {
            return Mood.NoIdea;
        }

        public bool HasGlasses()
        {
            return !string.IsNullOrEmpty(FaceAttributes.Glasses);
        }

        public string GetGender()
        {
            return "You shouldn't matter";
        }

        public int GetAge()
        {
            return Convert.ToInt32(FaceAttributes.Age);
        }
    }
}
