using System.ComponentModel;
using BusUH.Core.Models;
using BusUH.Core.Services;

namespace BusUH.Server;

public partial class Form1 : Form
{
    private readonly BusUhManager _manager = new();
    private readonly BindingList<TerminalInfo> _terminals;
    private readonly BindingList<Trip> _trips;
    private readonly BusUhSocketServer _socketServer;

    public Form1()
    {
        InitializeComponent();

        _terminals = new BindingList<TerminalInfo>(_manager.Terminals);
        _trips = new BindingList<Trip>(_manager.Trips);
        _socketServer = new BusUhSocketServer(_manager);

        _socketServer.LogGenerated += (_, message) => SafeUi(() => AppendLog(message));
        _socketServer.ClientCountChanged += (_, count) => SafeUi(() => lblConnectedClientsValue.Text = count.ToString());

        ConfigureGrids();
        BindData();
        LoadTerminalsIntoCombos();
        SelectDefaultRecords();
    }

    private void ConfigureGrids()
    {
        dgvTerminals.AutoGenerateColumns = true;
        dgvTrips.AutoGenerateColumns = true;
        dgvTerminals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTerminals.MultiSelect = false;
        dgvTrips.MultiSelect = false;
    }

    private void BindData()
    {
        dgvTerminals.DataSource = _terminals;
        dgvTrips.DataSource = _trips;
        ConfigureGridHeaders();
    }

    private void LoadTerminalsIntoCombos()
    {
        cmbDepartureTerminal.DataSource = _terminals.ToList();
        cmbDepartureTerminal.DisplayMember = nameof(TerminalInfo.Name);
        cmbArrivalTerminal.DataSource = _terminals.ToList();
        cmbArrivalTerminal.DisplayMember = nameof(TerminalInfo.Name);
    }

    private void SelectDefaultRecords()
    {
        if (_terminals.Count > 0)
        {
            dgvTerminals.Rows[0].Selected = true;
            LoadTerminalIntoEditor(_terminals[0]);
        }

        if (_trips.Count > 0)
        {
            dgvTrips.Rows[0].Selected = true;
            LoadTripIntoEditor(_trips[0]);
        }
    }

    private void btnSaveTerminal_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTerminalCode.Text) || string.IsNullOrWhiteSpace(txtTerminalName.Text))
        {
            MessageBox.Show("Digite el codigo y el nombre del terminal.", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _manager.SaveTerminal(new TerminalInfo
        {
            Code = txtTerminalCode.Text.Trim().ToUpperInvariant(),
            Name = txtTerminalName.Text.Trim()
        });

        RefreshTerminalBindings();
        AppendLog($"Terminal guardado: {txtTerminalCode.Text.Trim().ToUpperInvariant()} - {txtTerminalName.Text.Trim()}");
    }

    private void btnNewTerminal_Click(object sender, EventArgs e)
    {
        txtTerminalCode.Clear();
        txtTerminalName.Clear();
        txtTerminalCode.Focus();
    }

    private void btnSaveTrip_Click(object sender, EventArgs e)
    {
        if (cmbDepartureTerminal.SelectedItem is not TerminalInfo departure ||
            cmbArrivalTerminal.SelectedItem is not TerminalInfo arrival)
        {
            MessageBox.Show("Seleccione ambos terminales.", "Viajes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (departure.Code == arrival.Code)
        {
            MessageBox.Show("La salida y la llegada deben ser diferentes.", "Viajes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTripCode.Text))
        {
            MessageBox.Show("Digite el codigo del viaje.", "Viajes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var trip = _manager.CreateTrip(
            txtTripCode.Text.Trim().PadLeft(2, '0'),
            departure,
            arrival,
            (int)nudCapacity.Value,
            nudCost.Value);

        _manager.SaveTrip(trip);
        RefreshTripBindings();
        AppendLog($"Viaje guardado: {trip.Code} - {trip.DisplayRoute}");
    }

    private void btnNewTrip_Click(object sender, EventArgs e)
    {
        txtTripCode.Clear();
        nudCapacity.Value = 67;
        nudCost.Value = 3500;
        txtSeatSummary.Clear();
        txtTripCode.Focus();
    }

    private async void btnStartSocket_Click(object sender, EventArgs e)
    {
        try
        {
            await _socketServer.StartAsync((int)nudPort.Value);
            ToggleSocketButtons(isRunning: true);
            AppendLog($"Socket activo en el puerto {(int)nudPort.Value}.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Socket", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnStopSocket_Click(object sender, EventArgs e)
    {
        await _socketServer.StopAsync();
        ToggleSocketButtons(isRunning: false);
        AppendLog("Socket detenido.");
    }

    private void dgvTerminals_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTerminals.CurrentRow?.DataBoundItem is TerminalInfo terminal)
        {
            LoadTerminalIntoEditor(terminal);
        }
    }

    private void dgvTrips_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTrips.CurrentRow?.DataBoundItem is Trip trip)
        {
            LoadTripIntoEditor(trip);
        }
    }

    private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        await _socketServer.StopAsync();
    }

    private void LoadTerminalIntoEditor(TerminalInfo terminal)
    {
        txtTerminalCode.Text = terminal.Code;
        txtTerminalName.Text = terminal.Name;
    }

    private void LoadTripIntoEditor(Trip trip)
    {
        txtTripCode.Text = trip.Code;
        nudCapacity.Value = trip.Capacity;
        nudCost.Value = trip.Cost;
        txtSeatSummary.Text = trip.SeatAvailabilitySummary();

        SelectComboItem(cmbDepartureTerminal, trip.DepartureTerminalCode);
        SelectComboItem(cmbArrivalTerminal, trip.ArrivalTerminalCode);
    }

    private static void SelectComboItem(ComboBox combo, string terminalCode)
    {
        for (var index = 0; index < combo.Items.Count; index++)
        {
            if (combo.Items[index] is TerminalInfo terminal && terminal.Code == terminalCode)
            {
                combo.SelectedIndex = index;
                return;
            }
        }
    }

    private void RefreshTerminalBindings()
    {
        _terminals.ResetBindings();
        dgvTerminals.Refresh();
        LoadTerminalsIntoCombos();
        ConfigureGridHeaders();
    }

    private void RefreshTripBindings()
    {
        _trips.ResetBindings();
        dgvTrips.Refresh();
        ConfigureGridHeaders();
        if (dgvTrips.CurrentRow?.DataBoundItem is Trip trip)
        {
            txtSeatSummary.Text = trip.SeatAvailabilitySummary();
        }
    }

    private void ConfigureGridHeaders()
    {
        ConfigureTerminalHeaders();
        ConfigureTripHeaders();
    }

    private void ConfigureTerminalHeaders()
    {
        if (dgvTerminals.Columns.Count == 0)
        {
            return;
        }

        dgvTerminals.Columns[nameof(TerminalInfo.Code)]!.HeaderText = "Codigo";
        dgvTerminals.Columns[nameof(TerminalInfo.Name)]!.HeaderText = "Nombre";
    }

    private void ConfigureTripHeaders()
    {
        if (dgvTrips.Columns.Count == 0)
        {
            return;
        }

        dgvTrips.Columns[nameof(Trip.Code)]!.HeaderText = "Codigo";
        dgvTrips.Columns[nameof(Trip.DepartureTerminalCode)]!.HeaderText = "Codigo terminal salida";
        dgvTrips.Columns[nameof(Trip.DepartureTerminalName)]!.HeaderText = "Terminal salida";
        dgvTrips.Columns[nameof(Trip.ArrivalTerminalCode)]!.HeaderText = "Codigo terminal llegada";
        dgvTrips.Columns[nameof(Trip.ArrivalTerminalName)]!.HeaderText = "Terminal llegada";
        dgvTrips.Columns[nameof(Trip.Capacity)]!.HeaderText = "Capacidad";
        dgvTrips.Columns[nameof(Trip.Cost)]!.HeaderText = "Costo";
        dgvTrips.Columns[nameof(Trip.AvailableCapacity)]!.HeaderText = "Capacidad disponible";
        dgvTrips.Columns[nameof(Trip.DisplayRoute)]!.HeaderText = "Ruta";
    }

    private void ToggleSocketButtons(bool isRunning)
    {
        btnStartSocket.Enabled = !isRunning;
        btnStopSocket.Enabled = isRunning;
        nudPort.Enabled = !isRunning;
        lblSocketStatusValue.Text = isRunning ? "En linea" : "Detenido";
    }

    private void AppendLog(string message)
    {
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private void SafeUi(Action action)
    {
        if (IsDisposed)
        {
            return;
        }

        if (InvokeRequired)
        {
            BeginInvoke(action);
            return;
        }

        action();
        RefreshTripBindings();
    }
}
