namespace Lib.FaceDetect
{
    using System;
    using System.Linq.Expressions;

    public interface IFaceDetectResult
    {

        bool IsHappy(Expression<Func<double, bool>> predicate = null);
        bool IsAngry(Expression<Func<double, bool>> predicate);
        bool IsSad(Expression<Func<double, bool>> predicate = null);
        bool IsSurprise(Expression<Func<double, bool>> predicate = null);
        bool IsDisgust(Expression<Func<double, bool>> predicate = null);
        Mood GetMood();
        bool HasGlasses();
        string GetGender();
        int GetAge();

    }
}
