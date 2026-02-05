using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SeaBattle
{
    public partial class MainForm : Form
    {
        private GameLogic game = new GameLogic();
        private GameStatus status = GameStatus.Placement;
        private TcpClient client;
        private NetworkStream stream;
        private const int CellSize = 30;

        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private async void btnHost_Click(object sender, EventArgs e)
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtPort.Text));
                listener.Start();
                lblStatus.Text = "Ожидание игрока...";
                client = await listener.AcceptTcpClientAsync();
                stream = client.GetStream();
                status = GameStatus.MyTurn;
                lblStatus.Text = "Ваш ход";
                StartReceiving();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(txtIP.Text, int.Parse(txtPort.Text));
                stream = client.GetStream();
                status = GameStatus.EnemyTurn;
                lblStatus.Text = "Ожидание соперника...";
                StartReceiving();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void StartReceiving()
        {
            byte[] buffer = new byte[1024];
            while (client != null && client.Connected)
            {
                try
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var msg = JsonSerializer.Deserialize<GameMessage>(json);

                    this.Invoke((MethodInvoker)(() => HandleIncomingMessage(msg)));
                }
                catch { break; }
            }
        }

        private void HandleIncomingMessage(GameMessage msg)
        {
            if (msg.Type == "Shot")
            {
                string result = game.ProcessEnemyShot(msg.X, msg.Y);
                Send(new GameMessage { Type = "Result", X = msg.X, Y = msg.Y, Status = result });
                if (result == "Miss") status = GameStatus.MyTurn;
            }
            else if (msg.Type == "Result")
            {
                game.EnemyField[msg.X, msg.Y] = (msg.Status == "Miss") ? CellState.Miss : CellState.Hit;
                if (msg.Status == "Miss") status = GameStatus.EnemyTurn;
            }
            RefreshUI();
        }

        private void Send(GameMessage msg)
        {
            string json = JsonSerializer.Serialize(msg);
            byte[] data = Encoding.UTF8.GetBytes(json);
            stream.Write(data, 0, data.Length);
        }

        private void pbxSelf_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pbxEnemy_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pbxEnemy_MouseDown(object sender, MouseEventArgs e)
        {
            if (status != GameStatus.MyTurn) return;

            int x = e.X / CellSize;
            int y = e.Y / CellSize;

            if (x >= 0 && x < 10 && y >= 0 && y < 10 && game.EnemyField[x, y] == CellState.Empty)
            {
                Send(new GameMessage { Type = "Shot", X = x, Y = y });
            }
        }

        private void RefreshUI()
        {
            pbxSelf.Invalidate();
            pbxEnemy.Invalidate();
            lblStatus.Text = (status == GameStatus.MyTurn) ? "Ваш ход" : "Ход противника";
        }
    }
}