using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using Microsoft.Web.WebView2;
using Microsoft.Web.WebView2.WinForms;
using SpotifyOAuth.Queue;
using SpotifyOAuth.Search;
using SpotifyOAuth.Track;
using SpotifyOAuth.User;

namespace SpotifyOAuthTest
{
    public partial class Form1 : Form
    {
        string AccessToken;
        string RenewToken;
        bool isPlaying = false;
        bool stop = false;

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        async void Start()
        {
            Browser browser = new Browser(stop);
            browser.Show(this);
            browser.Activate();
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8888/callback/");
            listener.Start();
            HttpListenerContext context = await listener.GetContextAsync();
            listener.Stop();
            listener.Abort();
            browser.Close();
            browser.Dispose();
            string AuthCode = context.Request.QueryString.Get(0);
            string head = Base64Encode("7790ce9e6c5a41f3bd39666898ede546:4b20a8ae5d0044b8a636c6cee9c75e03");
            StringContent content = new StringContent($"grant_type=authorization_code&code={AuthCode}&redirect_uri=http://localhost:8888/callback", Encoding.UTF8, "application/x-www-form-urlencoded");
            string con;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + head);
                HttpResponseMessage m = await client.PostAsync("https://accounts.spotify.com/api/token", content);
                con = await m.Content.ReadAsStringAsync();
            };
            AccessToken = con.Split(',')[0].Split(':')[1].Trim('"').Trim('"');
            RenewToken = con.Split(',').Single(x => x.Contains("refresh_token")).Split(':')[1].Trim('"').Trim('"');

            stop = false;
            GetCurrentTrack();
            GetQueue();
            Username();
            addButton.Click += (s, e) => { AddToQueue(searchBox.Text); };
            nextButton.Click += (s, e) => { Next(); };
            playStateButton.Click += (s, e) => { ChangePlayState(); };
        }

        public async void GetCurrentTrack()
        {
            while(true)
            {
                if (stop)
                    break;

                try
                {
                    HttpResponseMessage response;
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                        response = await client.GetAsync("https://api.spotify.com/v1/me/player/currently-playing");
                    }
                    //File.WriteAllText(@"C:\\Programmieren\\Test\\Test.txt", await response.Content.ReadAsStringAsync());
                    TrackModel track = (TrackModel)await JsonSerializer.DeserializeAsync(response.Content.ReadAsStream(), typeof(TrackModel));
                    nameBox.Text = "Song: " + track.item.name;

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(new Uri(track.item.album.images[0].url), Environment.CurrentDirectory + @"\Test.png");
                    }

                    Debug.WriteLine(Environment.CurrentDirectory + @"\Test.png");
                    isPlaying = track.is_playing;

                    if (!isPlaying)
                        this.BackColor= Color.DarkRed;
                    else this.BackColor = Color.LightGray;

                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.ImageLocation = Environment.CurrentDirectory + @"\Test.png";
                    await Task.Delay(200);
                }
                catch (Exception ex)
                {
                    nameBox.Text = ex.Message;
                }
            }
        }

        public async void GetQueue()
        {
            while(true)
            {
                if (stop)
                    break;

                try
                {
                    HttpResponseMessage response;
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                        response = await client.GetAsync("https://api.spotify.com/v1/me/player/queue");
                    }
                    File.WriteAllText(@"C:\\Programmieren\\Test\\Test.txt", await response.Content.ReadAsStringAsync());
                    QueueModel queue = (QueueModel)await JsonSerializer.DeserializeAsync(response.Content.ReadAsStream(), typeof(QueueModel));
                    Debug.WriteLine(queue.queue.Select(x => x.name));
                    queueBox.Text = String.Join(Environment.NewLine, queue.queue.Select(x => x.name + " - " + x.artists[0].name).ToArray());
                    await Task.Delay(400);
                }
                catch(Exception ex)
                {
                    queueBox.Text = ex.Message;
                }
            }
        }

        public async void ChangePlayState()
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                if(isPlaying)
                    response = await client.PutAsync("https://api.spotify.com/v1/me/player/pause", null);
                else
                    response = await client.PutAsync("https://api.spotify.com/v1/me/player/play", null);
            }
        }

        public async void AddToQueue(string name)
        {
            HttpResponseMessage response;
            string songName = searchBox.Text.Split('-')[0].Trim();
            string artist = string.Empty;
            if(searchBox.Text.Split('-').Length > 1)
               artist = searchBox.Text.Split('-')[1].Trim();

            string query = $"track:{songName}{(artist.Length > 0 ? $"%20artist:{artist}" : "")}";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                response = await client.GetAsync($"https://api.spotify.com/v1/search?q={query}&type=track&limit=2");
            }
            SearchModel search = (SearchModel)await JsonSerializer.DeserializeAsync(await response.Content.ReadAsStreamAsync(), typeof(SearchModel));
            string songId = search.tracks.items[0].uri;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                response = await client.PostAsync("https://api.spotify.com/v1/me/player/queue?uri=" + songId, null);
            }
        }

        public async void Username()
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                response = await client.GetAsync("https://api.spotify.com/v1/me");
            }
            UserModel user = (UserModel)await JsonSerializer.DeserializeAsync(await response.Content.ReadAsStreamAsync(), typeof(UserModel));
            this.Text = this.Text + " - " + user.display_name;
        }

        public async void Next()
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                response = await client.PostAsync("https://api.spotify.com/v1/me/player/next", null);
            }
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private async void logOut_Click(object sender, EventArgs e)
        {
            stop = true;
            await Task.Delay(200);
            Start();
        }
    }
}