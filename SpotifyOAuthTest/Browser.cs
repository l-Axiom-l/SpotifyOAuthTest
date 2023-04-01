using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyOAuthTest
{
    public partial class Browser : Form
    {
        public Browser(bool newUser)
        {
            InitializeComponent();
            Start(newUser);
        }

        async void Start(bool newUser)
        {
            WebView2 view = new WebView2();
            FormClosed += (x,y) => view.Dispose();
            await view.EnsureCoreWebView2Async();

            if(newUser)
                view.CoreWebView2.CookieManager.DeleteAllCookies();

            while (Browser.ActiveForm == null) { await Task.Delay(10); };
            Debug.WriteLine("Test:" + Browser.ActiveForm);
            view.Size = this.ClientSize;
            this.Controls.Add(view);
            view.Show();
            view.CoreWebView2.Navigate("https://accounts.spotify.com/authorize?client_id=7790ce9e6c5a41f3bd39666898ede546&response_type=code&scope=user-modify-playback-state user-read-email user-read-private user-read-playback-state user-read-currently-playing&redirect_uri=http://localhost:8888/callback");
        }
    }
}
