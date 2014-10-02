using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace zsi.Biometrics
{
	public delegate void OnChangeHandler();	

	public class FingersBiometrics
    {
        public event OnChangeHandler DataChanged; 		
        public const int MaxFingers = 10;
        public int RecordCount { get; set; }
        public ByteData Template { get; set; }
        public ByteData Sample { get; set; } 

        public void UpdateTemplates(int FingerPosition,DPFP.Template Template)
        {
            MemoryStream _MemoryStream = new MemoryStream();
            byte[] bTemplate = null;
            Template.Serialize(ref bTemplate);
            if (this.Template == null) this.Template = new ByteData();
            switch (FingerPosition) {
                case 0: this.Template.RTF = bTemplate; this.RecordCount++; break;
                case 1: this.Template.RIF = bTemplate; this.RecordCount++; break;
                case 2: this.Template.RMF = bTemplate; this.RecordCount++; break;
                case 3: this.Template.RRF = bTemplate; this.RecordCount++; break;
                case 4: this.Template.RSF = bTemplate; this.RecordCount++; break;
                case 5: this.Template.LTF = bTemplate; this.RecordCount++; break;
                case 6: this.Template.LIF = bTemplate; this.RecordCount++; break;
                case 7: this.Template.LMF = bTemplate; this.RecordCount++; break;
                case 8: this.Template.LRF = bTemplate; this.RecordCount++; break;
                case 9: this.Template.LSF = bTemplate; this.RecordCount++; break;
                default: break;
            }
            if (DataChanged != null)this.DataChanged();            
        }

          
	}
    public class ByteData
    {
        public byte[] RTF { get; set; }
        public byte[] RIF { get; set; }
        public byte[] RMF { get; set; }
        public byte[] RRF { get; set; }
        public byte[] RSF { get; set; }
        public byte[] LTF { get; set; }
        public byte[] LIF { get; set; }
        public byte[] LMF { get; set; }
        public byte[] LRF { get; set; }
        public byte[] LSF { get; set; }    
    }
}
