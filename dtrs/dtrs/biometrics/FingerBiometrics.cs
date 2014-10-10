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
        public int RecordCount { get; set; }
        public TemplateData Template { get; set; }
        public DPFP.Sample[,] Samples = new DPFP.Sample[FingersBiometrics.MaxFingers, 4];
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
            if (this.Template.RTF != null) result++;
            if (this.Template.RIF != null) result++;
            if (this.Template.RMF != null) result++;
            if (this.Template.RRF != null) result++;
            if (this.Template.RSF != null) result++;
            if (this.Template.LTF != null) result++;
            if (this.Template.LIF != null) result++;
            if (this.Template.LMF != null) result++;
            if (this.Template.LRF != null) result++;
            if (this.Template.LSF != null) result++;
            return result;
        }
          
        public void UpdateTemplates(int FingerPosition, DPFP.Template Template)
        {
            MemoryStream _MemoryStream = new MemoryStream();
            byte[] bTemplate = null;
            if (Template!=null) Template.Serialize(ref bTemplate);
            if (this.Template == null) this.Template = new TemplateData();
            switch (FingerPosition) {
                case 0: this.Template.RTF =bTemplate; break;             
                case 1: this.Template.RIF = bTemplate; break;
                case 2: this.Template.RMF = bTemplate; break;
                case 3: this.Template.RRF = bTemplate; break;
                case 4: this.Template.RSF = bTemplate; break;
                case 5: this.Template.LTF = bTemplate; break;
                case 6: this.Template.LIF = bTemplate; break;
                case 7: this.Template.LMF = bTemplate; break;
                case 8: this.Template.LRF = bTemplate; break;
                case 9: this.Template.LSF = bTemplate; break; 
                default: break;
            }
            this.RecordCount = CountRecord();
            SetTSI(FingerPosition);

            if (DataChanged != null)this.DataChanged();            
        }

        public void Clear() {
            this.Template = new TemplateData();
            this.Samples = new DPFP.Sample[FingersBiometrics.MaxFingers, 4];
            this.RecordCount = 0;
            this.TSI = "";
            this._TSI = null;
        }
      
	}
   
    public class TemplateData
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
