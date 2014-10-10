using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace zsi.Biometrics
{
	public delegate void OnChangeHandler();
   
   

	public class FingersBiometrics
    {
        public event OnChangeHandler DataChanged; 		
        public const int MaxFingers = 10; 
        public const int MaxSamples = 4;
        public int RecordCount { get; set; }
        public ByteTemplate ByteTemplate { get; set; }
        public DPFP.Template[] Templates = new DPFP.Template[FingersBiometrics.MaxFingers];
        public DPFP.Sample[,] Samples = new DPFP.Sample[FingersBiometrics.MaxFingers, MaxSamples];
        public string TSI { get; set; }
        private List<int> _TSI { get; set; }

        private void SetTSI(int pos)
        {
            if (this._TSI == null) this._TSI = new List<int>();
            if (!this._TSI.Exists(delegate(int p) { return p == pos; }) || this._TSI.Count == 0)
            {
                this._TSI.Add(pos);
            }
            this.TSI = "";
            foreach (int x in this._TSI)
            {
                this.TSI += "" + x; 
            }
        }
        private int CountRecord()
        {
            int result = 0;
            if (this.ByteTemplate.RTF != null) result++;
            if (this.ByteTemplate.RIF != null) result++;
            if (this.ByteTemplate.RMF != null) result++;
            if (this.ByteTemplate.RRF != null) result++;
            if (this.ByteTemplate.RSF != null) result++;
            if (this.ByteTemplate.LTF != null) result++;
            if (this.ByteTemplate.LIF != null) result++;
            if (this.ByteTemplate.LMF != null) result++;
            if (this.ByteTemplate.LRF != null) result++;
            if (this.ByteTemplate.LSF != null) result++;
            return result;
        }
          
        public void UpdateTemplates(int FingerPosition, DPFP.Template Template)
        {
            this.Templates[FingerPosition] = Template;
            MemoryStream _MemoryStream = new MemoryStream();
            byte[] bTemplate = null;
            if (Template!=null) Template.Serialize(ref bTemplate);
            if (this.ByteTemplate == null) this.ByteTemplate = new ByteTemplate();
            switch (FingerPosition) {
                case 0: this.ByteTemplate.RTF = bTemplate; break;
                case 1: this.ByteTemplate.RIF = bTemplate; break;
                case 2: this.ByteTemplate.RMF = bTemplate; break;
                case 3: this.ByteTemplate.RRF = bTemplate; break;
                case 4: this.ByteTemplate.RSF = bTemplate; break;
                case 5: this.ByteTemplate.LTF = bTemplate; break;
                case 6: this.ByteTemplate.LIF = bTemplate; break;
                case 7: this.ByteTemplate.LMF = bTemplate; break;
                case 8: this.ByteTemplate.LRF = bTemplate; break;
                case 9: this.ByteTemplate.LSF = bTemplate; break; 
                default: break;
            }
            this.RecordCount = CountRecord();
            SetTSI(FingerPosition);

            if (DataChanged != null)this.DataChanged();            
        }

        public void Clear() {
            this.ByteTemplate = new ByteTemplate();
            this.Samples = new DPFP.Sample[FingersBiometrics.MaxFingers, MaxSamples];
            this.Templates = new DPFP.Template[FingersBiometrics.MaxFingers];
            this.RecordCount = 0;
            this.TSI = "";
            this._TSI = null;
        }
      
	}

    public class ByteTemplate
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
