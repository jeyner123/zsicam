using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zsi.Biometrics
{
    public partial class frmRegisterFP : Form
    {

        public FingersData FingersData { get; set; }
        public frmRegisterFP(FingersData Data)
        {
            InitializeComponent();
            this.FingersData= Data;	
            // Keep reference to the data   
            FingersData.SyncData(false, this.EnrollmentControl, Data);
 
        }
 
 
    // event handling
    public void EnrollmentControl_OnEnroll(Object Control, int Finger, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus Status) {
        if (FingersData.IsEventHandlerSucceeds)
        {
            MessageBox.Show((Finger - 1).ToString());
            this.FingersData.Templates[Finger - 1] = Template;		    // store a finger template
            FingersData.SyncData(true, this.EnrollmentControl, this.FingersData);

            ListEvents.Items.Insert(0, String.Format("OnEnroll: finger {0}", Finger));
      } else
            Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
    }

    public void EnrollmentControl_OnDelete(Object Control, int Finger, ref DPFP.Gui.EventHandlerStatus Status) {
        if (FingersData.IsEventHandlerSucceeds)
        {
            FingersData.Templates[Finger - 1] = null;			    // clear the finger template
            FingersData.SyncData(true, this.EnrollmentControl, this.FingersData);

            ListEvents.Items.Insert(0, String.Format("OnDelete: finger {0}", Finger));
        } else
        Status = DPFP.Gui.EventHandlerStatus.Failure;	// force a "failure" status
    }

    private void EnrollmentControl_OnCancelEnroll(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnFingerRemove(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger {1}", ReaderSerialNumber, Finger));
    }

    private void EnrollmentControl_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback) {
      ListEvents.Items.Insert(0, String.Format("OnSampleQuality: {0}, finger {1}, {2}", ReaderSerialNumber, Finger, CaptureFeedback));
    }

    private void EnrollmentControl_OnComplete(object Control, string ReaderSerialNumber, int Finger) {
      ListEvents.Items.Insert(0, String.Format("OnComplete: {0}, finger {1}", ReaderSerialNumber, Finger));
    }



    private void EnrollmentForm_Load(object sender, EventArgs e) {
      this.ListEvents.Items.Clear();
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    }
}
