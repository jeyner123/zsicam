using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace zsi.Biometrics {

  // The main application form.
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
      Data = new FingersData();								// Create the application data object
       Data.DataChanged += delegate { ExchangeData(false); };	// Track data changes to keep the form synchronized

   


        Enroller = new EnrollmentForm(Data);
      Verifier = new VerificationForm(Data);
      ExchangeData(false);								// fill data with default values from controls
    }

    // Simple dialog data exchange (DDX) implementation.
    private void ExchangeData(bool read) {
      if (read) {	// read values from the form's controls to the data object
        Data.EnrolledFingersMask = Mask.Text.Length == 0 ? 0 : (int)Mask.Value;
        Data.MaxEnrollFingerCount = MaxFingers.Text.Length == 0 ? 0 : (int)MaxFingers.Value;
        Data.IsEventHandlerSucceeds = IsSuccess.Checked;
        Data.Update();
        
      } else {	// read valuse from the data object to the form's controls
        Mask.Value = Data.EnrolledFingersMask;
        MaxFingers.Value = Data.MaxEnrollFingerCount;
        IsSuccess.Checked = Data.IsEventHandlerSucceeds;
        IsFailure.Checked = !IsSuccess.Checked;
        IsFeatureSetMatched.Checked = Data.IsFeatureSetMatched;
        FalseAcceptRate.Text = Data.FalseAcceptRate.ToString();
        VerifyButton.Enabled = Data.EnrolledFingersMask > 0;
      }
    }

    private void EnrollButton_Click(object sender, EventArgs e) {
      ExchangeData(true);		// transfer values from the main form to the data object
    
      Enroller.ShowDialog();	// process enrollment
    }

    private void VerifyButton_Click(object sender, EventArgs e) {
      ExchangeData(true);		// transfer values from the main form to the data object
      Verifier.ShowDialog();	// process verification
       
    }



    private FingersData Data;					// keeps application-wide data

    private EnrollmentForm Enroller;
    private VerificationForm Verifier;
    public static byte[] ReadToEnd(System.IO.Stream stream)
    {
        long originalPosition = stream.Position;
        stream.Position = 0;

        try
        {
            byte[] readBuffer = new byte[4096];

            int totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;

                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        byte[] temp = new byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }

            byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }
        finally
        {
            stream.Position = originalPosition;
        }
    }


    private void btnUploadData_Click(object sender, EventArgs e)
    {
       
        //zsi.PhotoFingCapture.WebFileService.WebFileManager wf = new zsi.PhotoFingCapture.WebFileService.WebFileManager();
        //System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
        //Stream _stream = Data.Templates[9].Serialize(_MemoryStream);
        //byte[] _byte = zsi.PhotoFingCapture.Util.StreamToByte(_stream);

        //wf.UploadBiometricsData("18", "fingers-1.fpt", _byte);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }
 

  }
}