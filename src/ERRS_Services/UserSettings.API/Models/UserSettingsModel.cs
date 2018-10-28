namespace UserSettings.API.Models
{
    public class UserSettingsModel
    {
        public int Id { get; set; }
        // 0 Small, Medium, Large
        public int ColumnSize { get; set; }
        // 0 Day, Night
        public int Theme { get; set; }
        public bool Controls { get; set; }
    }
}
