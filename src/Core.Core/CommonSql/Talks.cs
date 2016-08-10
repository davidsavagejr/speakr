namespace Core.CommonSql
{
    internal static class Talks
    {
        /// <summary>
        /// SingleOrDefault
        /// @0 = User
        /// @1 = TalkId
        /// </summary>
        public static string GetTalkForOwner => @"SELECT t.* 
                                                    FROM Talk t
                                                    INNER JOIN Presentation p On p.Id = t.PresentationId
                                                    WHERE p.[User] LIKE @0 AND t.Id = @1";
    }
}