namespace ApiStructure.Models
{
    public class AppSettingsModel
    {
        public ProjectSettings ProjectSettings { get; set; }
    }

    public class ProjectSettings
    {
        public string ProjectName { get; set; }
    }
}
