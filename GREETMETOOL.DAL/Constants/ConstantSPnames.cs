using System;
namespace GREETMETOOL.DAL.Constants
{
    /// <summary>
    /// To keep SQL sp names
    /// </summary>
	public static class ConstantSPnames
	{
        public const string POSTGREETING = "[PRIVATEFLIGHT].[usp_GREETINGSInsert]";
        public const string GETGREETING = "[PRIVATEFLIGHT].[usp_GREETINGTEXTSelect]";
        public const string DELETEGREETING = "[PRIVATEFLIGHT].[usp_GREETINGTEXTDelete]";
        public const string UPDATEGREETING = "[PRIVATEFLIGHT].[usp_GREETINGSUpdate]";
    }
}

