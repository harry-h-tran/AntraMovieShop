namespace ApplicationCore.Model
{
    public class CastModel
    {
        public string Name { get; set; } = string.Empty;
        public string CharacterName { get; set; } = string.Empty;
        public int MovieId { get; set; }
        public int CastId { get; set; }
        public string ProfilePath { get; set; } = string.Empty;
    }
}
