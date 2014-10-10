using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsi.dtrs
{
    using System.Drawing;
    using System.IO;
    public class Util
    {
        public static DPFP.Template ProcessDBTemplate(byte[] _data)
        {
            DPFP.Template _template = null;
            Stream _ms = new MemoryStream(_data);
            _template = new DPFP.Template();
            //deserialize
            _template.DeSerialize(_ms);
            return _template;
        }

        public static Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        public static DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Processing.Enrollment dd = new DPFP.Processing.Enrollment();

            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        public static bool Verify(DPFP.Sample _sample, DPFP.Template _template)
        {
            try
            {
                bool _result = false;
                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.FeatureSet features = zsi.dtrs.Util.ExtractFeatures(_sample, DPFP.Processing.DataPurpose.Verification);

                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, _template, ref result);

                    if (result.Verified)
                        _result = true;
                    else
                        _result = false;

                }
                return _result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static string GetFingerDesc(int FingNo)
        {
            string _Finger = "";
            switch (FingNo)
            {
                case 9: _Finger = "LSF"; break;
                case 8: _Finger = "LRF"; break;
                case 7: _Finger = "LMF"; break;
                case 6: _Finger = "LIF"; break;
                case 5: _Finger = "LTF"; break;
                case 4: _Finger = "RSF"; break;
                case 3: _Finger = "RRF"; break;
                case 2: _Finger = "RMF"; break;
                case 1: _Finger = "RIF"; break;
                case 0: _Finger = "RTF"; break;
                default: break;
            }
            return _Finger;
        }

    }
}

 