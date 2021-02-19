using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proiect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int mHrană_umedăRoyal = 0;
        private int mHrană_umedăFelix = 0;
        private int mHrană_umedăWhiskas = 0;
        private int mHrană_uscatăSanabelle = 0;
        private int mHrană_uscatăApplaws = 0;
        private int mHrană_uscatăSmilla = 0;
        private int mRecompensaSticksuri = 0;
        private int mRecompensaTablete = 0;
        private int mRecompensaSnackuri = 0;
        private double Total = 0;
        MancareTip selectedMancare;

        private void RoyalMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_umedăRoyal++;
            txtRoyal.Text = mHrană_umedăRoyal.ToString();
        }

        private void FelixMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_umedăFelix++;
            txtFelix.Text = mHrană_umedăFelix.ToString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_umedăWhiskas++;
            txtWhiskas.Text = mHrană_umedăWhiskas.ToString();
        }

        private void SanabelleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_uscatăSanabelle++;
            txtSanabelle.Text = mHrană_uscatăSanabelle.ToString();
        }

        private void SmillaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_uscatăSmilla++;
            txtSmilla.Text = mHrană_uscatăSmilla.ToString();
        }

        private void ApplawsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mHrană_uscatăApplaws++;
            txtApplaws.Text = mHrană_uscatăApplaws.ToString();
        }

        private void SticksuriMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mRecompensaSticksuri++;
            txtSticksuri.Text = mRecompensaSticksuri.ToString();
        }

        private void TableteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mRecompensaTablete++;
            txtTablete.Text = mRecompensaTablete.ToString();
        }

        private void SnackuriMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mRecompensaSnackuri++;
            txtSnackuri.Text = mRecompensaSnackuri.ToString();
        }
        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " Comanda in progres!";
            this.Title = mesaj;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        KeyValuePair<MancareTip, double>[] PretList =
            {
            new KeyValuePair<MancareTip, double>(MancareTip.Royal, 15),
            new KeyValuePair<MancareTip, double>(MancareTip.Felix,12),
            new KeyValuePair<MancareTip, double>(MancareTip.Whiskas,18.5),
            new KeyValuePair<MancareTip, double>(MancareTip.Sanabelle,6.5),
            new KeyValuePair<MancareTip, double>(MancareTip.Applaws,13),
            new KeyValuePair<MancareTip, double>(MancareTip.Smilla,20),
            new KeyValuePair<MancareTip, double>(MancareTip.Sticksuri,2.5),
            new KeyValuePair<MancareTip, double>(MancareTip.Snackuri,7),
            new KeyValuePair<MancareTip, double>(MancareTip.Tablete,4)
            };

        private void cmbTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPret.Text = cmbTip.SelectedValue.ToString();
            KeyValuePair<MancareTip, double> selectedEntry = (KeyValuePair<MancareTip, double>)cmbTip.SelectedItem;
            selectedMancare = selectedEntry.Key;
        }
        private int ValidateCantitate(MancareTip selectedMancare)
        {
            int q = int.Parse(txtCantitate.Text);
            int r = 1;

            switch (selectedMancare)
            {
                case MancareTip.Royal:
                    if (q > mHrană_umedăRoyal)
                        r = 0;
                    break;
                case MancareTip.Felix:
                    if (q > mHrană_umedăFelix)
                        r = 0;
                    break;
                case MancareTip.Whiskas:
                    if (q > mHrană_umedăWhiskas)
                        r = 0;
                    break;
                case MancareTip.Sanabelle:
                    if (q > mHrană_uscatăSanabelle)
                        r = 0;
                    break;
                case MancareTip.Applaws:
                    if (q > mHrană_uscatăApplaws)
                        r = 0;
                    break;
                case MancareTip.Smilla:
                    if (q > mHrană_uscatăSmilla)
                        r = 0;
                    break;
                case MancareTip.Sticksuri:
                    if (q > mRecompensaSticksuri)
                        r = 0;
                    break;
                case MancareTip.Tablete:
                    if (q > mRecompensaTablete)
                        r = 0;
                    break;
                case MancareTip.Snackuri:
                    if (q > mRecompensaSnackuri)
                        r = 0;
                    break;
            }
            return r;
        }

        private void btnAdauga_Click(object sender, RoutedEventArgs e)
        {
            {
                if (ValidateCantitate(selectedMancare) > 0)
                {
                    lstSale.Items.Add(txtCantitate.Text + " " + selectedMancare.ToString() +
                   ":" + txtPret.Text + " " + double.Parse(txtCantitate.Text) *
                   double.Parse(txtPret.Text));
                }
                else
                {
                    MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
                }
            }
        }
        private void btnSterge_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnPlateste_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = (Total + double.Parse(txtCantitate.Text) *
                double.Parse(txtPret.Text)).ToString(); 

            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
1))
                {
                    case "Royal":
                        mHrană_umedăRoyal = mHrană_umedăRoyal - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtRoyal.Text = mHrană_umedăRoyal.ToString();
                        break;
                    case "Felix":
                        mHrană_umedăFelix = mHrană_umedăFelix - Int32.Parse(s.Substring(0,
                            s.IndexOf(" ")));
                        txtFelix.Text = mHrană_umedăFelix.ToString();
                        break;
                    case "Whiskas":
                        mHrană_umedăWhiskas = mHrană_umedăWhiskas - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtWhiskas.Text = mHrană_umedăWhiskas.ToString();
                        break;
                    case "Sanabelle":
                        mHrană_uscatăSanabelle = mHrană_uscatăSanabelle - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtSanabelle.Text = mHrană_uscatăSanabelle.ToString();
                        break;
                    case "Applaws":
                        mHrană_uscatăApplaws = mHrană_uscatăApplaws - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtApplaws.Text = mHrană_uscatăApplaws.ToString();
                        break;
                    case "Smilla":
                        mHrană_uscatăSmilla = mHrană_uscatăSmilla - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtSmilla.Text = mHrană_uscatăSmilla.ToString();
                        break;
                    case "Sticksuri":
                        mRecompensaSticksuri = mRecompensaSticksuri - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtSticksuri.Text = mRecompensaSticksuri.ToString();
                        break;
                    case "Tablete":
                        mRecompensaTablete = mRecompensaTablete - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtTablete.Text = mRecompensaTablete.ToString();
                        break;
                    case "Snackuri":
                        mRecompensaSnackuri = mRecompensaSnackuri - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtSnackuri.Text = mRecompensaSnackuri.ToString();
                        break;
                }
            }
        }
        private void txtCantitate_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void frmMain_Loaded_1(object sender, RoutedEventArgs e)
        {
            cmbTip.ItemsSource = PretList;
            cmbTip.DisplayMemberPath = "Key";
            cmbTip.SelectedValuePath = "Value";
        }
    }

}
