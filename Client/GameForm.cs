using Client.Assets.Levels;
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
        GameLoop gameLoop;
        string originalText;

        public GameForm()
        {
            InitializeComponent();
            Select();
            Focus();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            IpBox.Text = Networking.host;

            originalText = Text;
            gameLoop = new GameLoop();

            GameState state = GameState.Instance;
            state.gameLevel = GameLevelCreator.GetGameLevel(
                "forest", (float)state.mapSize.X, (float)state.mapSize.Y, 20, 20, 2);

            gameLoop.StartGame();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            gameLoop.Manage(e);
            Text = originalText + gameLoop.fps + " FPS";
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
    }
}
