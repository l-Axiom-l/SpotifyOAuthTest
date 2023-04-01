using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyOAuth.Queue
{

    public class QueueModel
    {
        public Currently_Playing currently_playing { get; set; }
        public Queue[] queue { get; set; }
    }

    public class Currently_Playing
    {
        public Album album { get; set; }
        public Artist1[] artists { get; set; }
        public string[] available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public External_Ids external_ids { get; set; }
        public External_Urls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public bool is_local { get; set; }
    }

    public class Album
    {
        public string album_type { get; set; }
        public int total_tracks { get; set; }
        public string[] available_markets { get; set; }
        public External_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public Image[] images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string album_group { get; set; }
        public Artist[] artists { get; set; }
        public bool is_playable { get; set; }
    }

    public class External_Urls
    {
        public string spotify { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Artist
    {
        public External_Urls1 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls1
    {
        public string spotify { get; set; }
    }

    public class External_Ids
    {
        public string isrc { get; set; }
    }

    public class External_Urls2
    {
        public string spotify { get; set; }
    }

    public class Artist1
    {
        public External_Urls3 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls3
    {
        public string spotify { get; set; }
    }

    public class Queue
    {
        public Album1 album { get; set; }
        public Artist3[] artists { get; set; }
        public string[] available_markets { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public External_Ids1 external_ids { get; set; }
        public External_Urls6 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public bool is_local { get; set; }
    }

    public class Album1
    {
        public string album_type { get; set; }
        public int total_tracks { get; set; }
        public string[] available_markets { get; set; }
        public External_Urls4 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public Image1[] images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
        public string album_group { get; set; }
        public Artist2[] artists { get; set; }
        public bool is_playable { get; set; }
    }

    public class External_Urls4
    {
        public string spotify { get; set; }
    }

    public class Image1
    {
        public string url { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }

    public class Artist2
    {
        public External_Urls5 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls5
    {
        public string spotify { get; set; }
    }

    public class External_Ids1
    {
        public string isrc { get; set; }
    }

    public class External_Urls6
    {
        public string spotify { get; set; }
    }

    public class Artist3
    {
        public External_Urls7 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class External_Urls7
    {
        public string spotify { get; set; }
    }

}
