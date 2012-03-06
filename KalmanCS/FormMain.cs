using System;
using System.Windows.Forms;


namespace KalmanCS
{
    /// <summary>
    /// Represents the back-end logic for our application's main form.
    /// </summary>
    public partial class FormMain : Form
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>The default constructor</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        public FormMain()
        {
            InitializeComponent();

            // Display an initial graph
            PopulateGraph();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Get the type of signal to generate based on which radio button has been
        /// selected by the user</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private KalmanFilter.TestSignalFormat GetSelectedFilterType()
        {
            if( radioButtonSineWave.Checked )
                return KalmanFilter.TestSignalFormat.SineWave;
            else if( radioButtonSquareWave.Checked )
                return KalmanFilter.TestSignalFormat.SquareWave;

            return KalmanFilter.TestSignalFormat.RandomWalk;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Run a test of the Kalman filter and display the results</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void PopulateGraph()
        {
            double sourceSigma;
            if( !double.TryParse( textBoxSourceSigma.Text, out sourceSigma ) )
                sourceSigma = 0.01;

            double measuredSigma;
            if( !double.TryParse( textBoxMeasuredSigma.Text, out measuredSigma ) )
                measuredSigma = 0.01;

            KalmanResults results = KalmanFilter.RunIt( sourceSigma, measuredSigma, GetSelectedFilterType() );

            chartMain.Series["Actual"].Points.DataBindY( results.ActualValues );

            chartMain.Series["Received"].Points.DataBindY( results.MeasuredValues );

            chartMain.Series["Filtered"].Points.DataBindY( results.FilteredValues );
        }


        ///////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>Occurs when the user presses the button to re-run a Kalman filter
        /// test</summary>
        ///////////////////////////////////////////////////////////////////////////////////////////
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            PopulateGraph();
        }
    }
}
