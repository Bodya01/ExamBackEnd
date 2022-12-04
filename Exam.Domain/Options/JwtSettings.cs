using System;

namespace Exam.Domain.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public TimeSpan LifeTime { get; set; }
    }
}
