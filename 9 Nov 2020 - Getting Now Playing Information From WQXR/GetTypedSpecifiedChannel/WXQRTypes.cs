using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetTypedSpecifiedChannel
{
    public partial class Current
    {
        [JsonProperty("has_playlists")]
        public bool HasPlaylists { get; set; }

        [JsonProperty("future")]
        public List<object> Future { get; set; }

        [JsonProperty("current_show")]
        public CurrentShow CurrentShow { get; set; }

        [JsonProperty("expires")]
        public DateTimeOffset Expires { get; set; }

        [JsonProperty("current_playlist_item")]
        public CurrentPlaylistItem CurrentPlaylistItem { get; set; }
    }

    public partial class CurrentPlaylistItem
    {
        [JsonProperty("start_time_ts")]
        public long StartTimeTs { get; set; }

        [JsonProperty("stream")]
        public string Stream { get; set; }

        [JsonProperty("playlist_entry_id")]
        public long PlaylistEntryId { get; set; }

        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("playlist_page_url")]
        public Uri PlaylistPageUrl { get; set; }

        [JsonProperty("comments_url")]
        public string CommentsUrl { get; set; }

        [JsonProperty("iso_start_time")]
        public DateTimeOffset IsoStartTime { get; set; }

        [JsonProperty("catalog_entry")]
        public CatalogEntry CatalogEntry { get; set; }
    }

    public partial class CatalogEntry
    {
        [JsonProperty("reclabel")]
        public Reclabel Reclabel { get; set; }

        [JsonProperty("conductor")]
        public object Conductor { get; set; }

        [JsonProperty("catno")]
        public string Catno { get; set; }

        [JsonProperty("composer")]
        public Composer Composer { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("soloists")]
        public List<object> Soloists { get; set; }

        [JsonProperty("mm_uid")]
        public long MmUid { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("additional_composers")]
        public List<Composer> AdditionalComposers { get; set; }

        [JsonProperty("audio_may_download")]
        public bool AudioMayDownload { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("arkiv_link")]
        public Uri ArkivLink { get; set; }

        [JsonProperty("audio")]
        public Uri Audio { get; set; }

        [JsonProperty("ensemble")]
        public Composer Ensemble { get; set; }

        [JsonProperty("additional_ensembles")]
        public List<object> AdditionalEnsembles { get; set; }
    }

    public partial class Composer
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Reclabel
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class CurrentShow
    {
        [JsonProperty("iso_start")]
        public DateTimeOffset IsoStart { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("fullImage")]
        public Image FullImage { get; set; }

        [JsonProperty("site_id")]
        public long SiteId { get; set; }

        [JsonProperty("start_ts")]
        public long StartTs { get; set; }

        [JsonProperty("iso_end")]
        public DateTimeOffset IsoEnd { get; set; }

        [JsonProperty("listImage")]
        public Image ListImage { get; set; }

        [JsonProperty("pk")]
        public long Pk { get; set; }

        [JsonProperty("show_url")]
        public Uri ShowUrl { get; set; }

        [JsonProperty("end")]
        public string End { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("end_ts")]
        public long EndTs { get; set; }

        [JsonProperty("schedule_ref")]
        public string ScheduleRef { get; set; }

        [JsonProperty("group_slug")]
        public string GroupSlug { get; set; }

        [JsonProperty("detailImage")]
        public Image DetailImage { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }
    }
    public partial class Soloist
    {
        [JsonProperty("instruments")]
        public List<string> Instruments { get; set; }

        [JsonProperty("musician")]
        public Composer Musician { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}