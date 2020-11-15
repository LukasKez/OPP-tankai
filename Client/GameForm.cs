using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;

namespace Client
{
    public partial class GameForm : Form, IObserver
    {
        string originalText;

        public GameForm()
        {
            InitializeComponent();

            IpBox.Text = Networking.host;
            comboBox1.DataSource = Enum.GetValues(typeof(LevelType));
            comboBox2.DataSource = Enum.GetValues(typeof(TankType));

            SetMenuButtons(true, true, "Join Game", false);
            UpdatePlayerUI();

            Select();
            Focus();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            originalText = Text;

            GameState.Instance.Attach(this);
            Networking.OnLevelTypeChange += UpdateLevelTypeBox;
            Networking.OnRemotePlayersChange += UpdatePlayerListUI;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if (Options.smoothing)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (Options.pixelOffset)
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

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

        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameState.Instance.focused)
                return;

            GameState.Instance.mouseLocation = new Vector2(e.Location.X, e.Location.Y);
        }

        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!GameState.Instance.focused)
                return;

            GameState.Instance.MouseClicked(e.Button);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = Application.OpenForms["OptionsForm"] as OptionsForm;
            if (optionsForm != null)
            {
                optionsForm.Focus();
                return;
            }

            optionsForm = new OptionsForm();
            optionsForm.Show(this);
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
                    break;
                case ClientState.Playing:
                case ClientState.Died:
                    Networking.DisconnectAsync();
                    break;
                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Networking.SetLevelTypeAsync((LevelType)comboBox1.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TankType type = (TankType)comboBox2.SelectedItem;
            GameState.Instance.tankType = type;
            Networking.SetTankTypeAsync(type);
        }

        private void UpdateUIState(ClientState newState)
        {
            switch (newState)
            {
                case ClientState.Menu:
                    SetMenuButtons(true, true, "Join Game", false);
                    ClearPlayerListEntries();
                    break;
                case ClientState.Connecting:
                    SetMenuButtons(false, false, "Connecting...", false);
                    break;
                case ClientState.Connected:
                    SetMenuButtons(false, true, "Ready", true);
                    break;
                case ClientState.Ready:
                    SetMenuButtons(false, false, "Ready", true);
                    break;
                case ClientState.Playing:
                case ClientState.Died:
                    SetMenuButtons(false, true, "Leave Game", false);
                    break;
                default:
                    break;
            }

            UpdatePlayerUI();
        }

        private void SetMenuButtons(bool enableIpBox, bool enableStartBtn, string startBtnText, bool enablePreGameOptions)
        {
            IpBox.Enabled = enableIpBox;
            StartButton.Enabled = enableStartBtn;
            StartButton.Text = startBtnText;

            levelLabel.Visible = enablePreGameOptions;
            comboBox1.Visible = enablePreGameOptions;
            tankLabel.Visible = enablePreGameOptions;
            comboBox2.Visible = enablePreGameOptions;
        }

        public void OnSubjectUpdate()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    OnSubjectUpdate();
                }));
                return;
            }

            UpdateUIState(GameState.Instance.State);
        }

        private void UpdateLevelTypeBox(LevelType levelType)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdateLevelTypeBox(levelType);
                }));
                return;
            }

            comboBox1.SelectedItem = levelType;
        }

        public void UpdatePlayerUI()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdatePlayerUI();
                }));
                return;
            }

            label2.Text = GameState.Instance.State >= ClientState.Ready ? "✔" : "";
            label1.Text = Options.name;
        }

        private void UpdatePlayerListUI(int index, RemotePlayer player)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    UpdatePlayerListUI(index, player);
                }));
                return;
            }

            index -= -1;
            var controls = PlayerListPanel.Controls;

            if (player != null)
            {
                Control control;

                if (controls.Count <= index)
                {
                    control = CreatePlayerEntry();
                    control.Tag = index;
                    controls.Add(control);
                }
                else
                {
                    control = controls[index];
                }

                control.Controls[0].Text = player.isReady ? "✔" : "";
                control.Controls[1].Text = player.name;
            }
            else if (controls.Count > index)
            {
                controls.RemoveAt(index);
            }
        }

        private void ClearPlayerListEntries()
        {
            var controls = PlayerListPanel.Controls;
            for (int i = 1; i < controls.Count; i++)
            {
                controls.RemoveAt(i);
            }
        }

        private Control CreatePlayerEntry()
        {
            Panel nPanel = new Panel();
            Label nLabel1 = new Label();
            Label nLabel2 = new Label();

            nPanel.Controls.Add(nLabel1);
            nPanel.Controls.Add(nLabel2);

            nPanel.BorderStyle = BorderStyle.FixedSingle;
            nPanel.Padding = new Padding(2);
            nPanel.Size = new Size(190, 30);

            nLabel2.AutoEllipsis = true;
            nLabel2.Location = new Point(5, 2);
            nLabel2.Size = new Size(148, 24);
            nLabel2.TextAlign = ContentAlignment.MiddleLeft;

            nLabel1.Location = new Point(159, 2);
            nLabel1.Size = new Size(24, 24);
            nLabel1.TextAlign = ContentAlignment.MiddleCenter;

            return nPanel;
        }
    }
}
