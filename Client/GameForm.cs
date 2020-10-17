using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class GameForm : Form
    {
        string originalText;

        public GameForm()
        {
            InitializeComponent();

            IpBox.Text = Networking.host;

            Select();
            Focus();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            originalText = Text;

            GameObserver.OnGameStateChange += UpdateUIState;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            GameLoop.Manage(e);
            Text = originalText + GameLoop.fps + " FPS";
            Application.DoEvents();
            Invalidate(false);
        }

        private void GameForm_Activated(object sender, EventArgs e)
        {
            GameState.Instance.focused = true;
        }

        private void GameForm_Deactivate(object sender, EventArgs e)
        {
            GameState.Instance.focused = false;
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm popup = new OptionsForm();
            popup.Show(this);
        }

        private void IpBox_TextChanged(object sender, EventArgs e)
        {
            Networking.host = (sender as TextBox).Text;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            switch (GameState.Instance.State)
            {
                case ClientState.Menu:
                    GameState.Instance.State = ClientState.Connecting;
                    Networking.ConnectAsync();
                    break;
                case ClientState.Connected:
                    GameState.Instance.State = ClientState.Ready;
                    Networking.SetIsReadyAsync(true);
                    break;
                case ClientState.Ready:
                    //gameLoop.StartGame();
                    break;
                case ClientState.Playing:
                case ClientState.Died:
                    Networking.DisconnectAsync();
                    break;
                default:
                    break;
            }
        }

        private void UpdateUIState(ClientState newState)
        {
            switch (newState)
            {
                case ClientState.Menu:
                    SetMenuButtons(true, true, "Join Game");
                    break;
                case ClientState.Connecting:
                    SetMenuButtons(false, false, "Connecting...");
                    break;
                case ClientState.Connected:
                    SetMenuButtons(false, true, "Ready");
                    break;
                case ClientState.Ready:
                    SetMenuButtons(false, false, "Ready");
                    break;
                case ClientState.Playing:
                case ClientState.Died:
                    SetMenuButtons(false, true, "Leave Game");
                    break;
                default:
                    break;
            }
        }

        private delegate void Delegate(bool bool1, bool bool2, string str);
        private void SetMenuButtons(bool enableIpBox, bool enableStartBtn, string startBtnText)
        {
            if (InvokeRequired)
            {
                Delegate d = SetMenuButtons;
                Invoke(d, new object[] { enableIpBox, enableStartBtn, startBtnText });
            }
            else
            {
                IpBox.Enabled = enableIpBox;
                StartButton.Enabled = enableStartBtn;
                StartButton.Text = startBtnText;
            }
        }
    }
}
