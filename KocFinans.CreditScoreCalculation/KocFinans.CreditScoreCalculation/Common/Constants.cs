using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KocFinans.CreditCalculation.Enum
{
    public static class Constants
    {
        public const string Negative = "Negative";
        public const string Positive = "Positive";

    }
    public static class LimitMultiplier
    {
        public const int LimitMultiplierValue = 4;
    }
    public static class RuleName
    {
        public const string CreditScoreLess500 = "CreditScoreLess500";
        public const string CreditScoreEqualOrAbove1000 = "CreditScoreEqualOrAbove1000";
        public const string CreditScoreBetween500and1000 = "CreditScoreBetween500and1000";
    }
    public static class ServiceName
    {
        public const string ScoreService = "ScoreService";
        public const string SmsService = "SmsService";
    }

    public static class NotificationType
    {
        public const string NotificationName= "SMS";
    }
}
