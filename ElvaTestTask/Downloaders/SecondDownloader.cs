namespace ElvaTestTask
{
    /// <summary>
    /// Двойник OpenStreetDownloader, просто чтобы показать работу хелпера
    /// </summary>
    public class SecondDownloader : Downloader
    {
        /// <inheritdoc />
        protected override string FilePath { get; } = @"C:\Somewhere Else";
        
        /// <inheritdoc />
        protected override string WebMask { get; } = @"https://nominatim.openstreetmap.org/search?q={0}&format=json&polygon_geojson={1}";
    }
}