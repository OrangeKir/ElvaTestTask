namespace ElvaTestTask
{
    /// <summary>
    /// Загрузчик Open Street Map
    /// </summary>
    public class OpenStreetDownloader : Downloader
    {
        /// <inheritdoc />
        protected override string FilePath { get; } = @"C:\Somewhere";
        
        /// <inheritdoc />
        protected override string WebMask { get; } = @"https://nominatim.openstreetmap.org/search?q={0}&format=json&polygon_geojson={1}";
    }
}