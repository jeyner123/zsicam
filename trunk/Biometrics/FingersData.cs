using System;
using System.Collections.Generic;
using System.Text;

namespace zsi.Biometrics
{
	public delegate void OnChangeHandler();
    
	
	public class FingersData
    {
        public event OnChangeHandler DataChanged; 
		
        public const int MaxFingers = 10;
		// shared data
        public int EnrolledFingersMask = 0;
		public int MaxEnrollFingerCount = MaxFingers;
        public bool IsEventHandlerSucceeds = true;
        public bool IsFeatureSetMatched = false;
        public int FalseAcceptRate = 0;
		
        public DPFP.Template[] Templates = new DPFP.Template[MaxFingers];

		// data change notification
        public void Update()
        {
            if (DataChanged != null)
            {
                this.DataChanged();
            }
        }

        public static void SyncData(bool IsDataFromControl,DPFP.Gui.Enrollment.EnrollmentControl EnrollmentControl,FingersData Data)
        {
            if (IsDataFromControl)
            {
                Data.EnrolledFingersMask = EnrollmentControl.EnrolledFingerMask;
                Data.MaxEnrollFingerCount = EnrollmentControl.MaxEnrollFingerCount;
                Data.DataChanged();
            }
            else
            {
                EnrollmentControl.EnrolledFingerMask = Data.EnrolledFingersMask;
                EnrollmentControl.MaxEnrollFingerCount = Data.MaxEnrollFingerCount;
            }
        }
       
	}
}
