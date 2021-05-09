using System.Text.Json.Serialization;

namespace Sportradar.Service.Recruitment.Objects
{
    /// <summary>
    /// Match Class for Response from API Call
    /// </summary>
    public class Match
    {
        [JsonPropertyName("matchId")]
        public int MatchId { get; set; }

        [JsonPropertyName("sportradarMatchId")]
        public int? SportradarMatchId { get; set; }

        [JsonPropertyName("matchStatusId")]
        public int MatchStatusId { get; set; }

        [JsonPropertyName("matchTeamID")]
        public int MatchTeamId { get; set; }

        [JsonPropertyName("opponentMatchTeamID")]
        public int OpponentMatchTeamID { get; set; }

        [JsonPropertyName("matchStatus")]
        public string matchStatus { get; set; }

        [JsonPropertyName("kickOff")]
        public string KickOffTime { get; set; }

        [JsonPropertyName("kickOffGmt")]
        public string KickOffGmtTime { get; set; }

        [JsonPropertyName("displayOverDate")]
        public string displayOverDate { get; set; }

        [JsonPropertyName("opponentTeamId")]
        public int OpponentTeamId { get; set; }

        [JsonPropertyName("opponentName")]
        public string OpponentName { get; set; }

        [JsonPropertyName("opponentNameShort")]
        public string OpponentNameShort { get; set; }
        
        [JsonPropertyName("stadiumId")]
        public int? stadiumId { get; set; }
        
        [JsonPropertyName("stadiumName")]
        public string StadiumName { get; set; }

        [JsonPropertyName("placeId")]
        public int? PlaceId { get; set; }

        [JsonPropertyName("placeName")]
        public string PlaceName { get; set; }

        [JsonPropertyName("isTeam1")]
        public bool IsTeam1 { get; set; }

        [JsonPropertyName("isAtHome")]
        public bool IsAtHome { get; set; }

        [JsonPropertyName("isTest")]
        public bool IsTest { get; set; }
        
        [JsonPropertyName("isResult")]
        public bool IsResult { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("pointsFor")]
        public int PointsFor { get; set; }

        [JsonPropertyName("PointsAgainst")]
        public int PointsAgainst { get; set; }

        [JsonPropertyName("teamLogoFilename")]
        public string TeamLogoFileName { get; set; }

        [JsonPropertyName("oppenentTeamLogoFilename")]
        public string OppenentTeamLogoFilename { get; set; }

        [JsonPropertyName("teamLogoFilenameDark")]
        public string TeamLogoFilenameDark { get; set; }

        [JsonPropertyName("oppenentTeamLogoFilenameDark")]
        public string OppenentTeamLogoFilenameDark { get; set; }
        
        [JsonPropertyName("attendance")]
        public int? Attendance { get; set; }

        [JsonPropertyName("isInProgress")]
        public bool IsInProgress { get; set; }
        
        [JsonPropertyName("matchUpdated")]
        public string MatchUpdated { get; set; }
    }
}