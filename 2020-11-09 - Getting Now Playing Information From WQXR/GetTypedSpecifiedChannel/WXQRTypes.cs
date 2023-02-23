using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GetTypedSpecifiedChannel
{
    public partial class Current
    {
        [JsonPropertyName("has_playlists")]
        public bool HasPlaylists { get; set; }

        [JsonPropertyName("future")]
        public List<object> Future { get; set; }

        [JsonPropertyName("current_show")]
        public CurrentShow CurrentShow { get; set; }

        [JsonPropertyName("expires")]
        public DateTimeOffset Expires { get; set; }

        [JsonPropertyName("current_playlist_item")]
        public CurrentPlaylistItem CurrentPlaylistItem { get; set; }
    }

    public partial class CurrentPlaylistItem
    {
        [JsonPropertyName("start_time_ts")]
        public decimal StartTimeTs { get; set; }

        [JsonPropertyName("stream")]
        public string Stream { get; set; }

        [JsonPropertyName("playlist_entry_id")]
        public long PlaylistEntryId { get; set; }

        [JsonPropertyName("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonPropertyName("playlist_page_url")]
        public Uri PlaylistPageUrl { get; set; }

        [JsonPropertyName("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonPropertyName("iso_start_time")]
        public DateTimeOffset IsoStartTime { get; set; }

        [JsonPropertyName("catalog_entry")]
        public CatalogEntry CatalogEntry { get; set; }
    }

    public partial class CatalogEntry
    {
        [JsonPropertyName("reclabel")]
        public Reclabel Reclabel { get; set; }

        [JsonPropertyName("conductor")]
        public object Conductor { get; set; }

        [JsonPropertyName("catno")]
        public string Catno { get; set; }

        [JsonPropertyName("composer")]
        public Composer Composer { get; set; }

        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }

        [JsonPropertyName("soloists")]
        public List<Soloist> Soloists { get; set; }

        [JsonPropertyName("mm_uid")]
        public long MmUid { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("additional_composers")]
        public List<Composer> AdditionalComposers { get; set; }

        [JsonPropertyName("audio_may_download")]
        public bool AudioMayDownload { get; set; }

        [JsonPropertyName("length")]
        public long Length { get; set; }

        [JsonPropertyName("pk")]
        public long Pk { get; set; }

        [JsonPropertyName("arkiv_link")]
        public Uri ArkivLink { get; set; }

        [JsonPropertyName("audio")]
        public Uri Audio { get; set; }

        [JsonPropertyName("ensemble")]
        public Composer Ensemble { get; set; }

        [JsonPropertyName("additional_ensembles")]
        public List<object> AdditionalEnsembles { get; set; }
    }

    public partial class Composer
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("pk")]
        public long Pk { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public partial class Reclabel
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public partial class CurrentShow
    {
        [JsonPropertyName("iso_start")]
        public DateTimeOffset IsoStart { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("fullImage")]
        public Image FullImage { get; set; }

        [JsonPropertyName("site_id")]
        public long SiteId { get; set; }

        [JsonPropertyName("start_ts")]
        public decimal StartTs { get; set; }

        [JsonPropertyName("iso_end")]
        public DateTimeOffset IsoEnd { get; set; }

        [JsonPropertyName("listImage")]
        public Image ListImage { get; set; }

        [JsonPropertyName("pk")]
        public long Pk { get; set; }

        [JsonPropertyName("show_url")]
        public Uri ShowUrl { get; set; }

        [JsonPropertyName("end")]
        public string End { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("end_ts")]
        public decimal EndTs { get; set; }

        [JsonPropertyName("schedule_ref")]
        public string ScheduleRef { get; set; }

        [JsonPropertyName("group_slug")]
        public string GroupSlug { get; set; }

        [JsonPropertyName("detailImage")]
        public Image DetailImage { get; set; }

        [JsonPropertyName("start")]
        public string Start { get; set; }
    }
    public partial class Soloist
    {
        [JsonPropertyName("instruments")]
        public List<string> Instruments { get; set; }

        [JsonPropertyName("musician")]
        public Composer Musician { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

    public partial class Image
    {
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("caption")]
        public string Caption { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }
    }
}