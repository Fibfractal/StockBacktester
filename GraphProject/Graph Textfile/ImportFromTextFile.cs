using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GraphProject
{
    public class ImportFromTextFile : IImportData 
    {
        private List<IDataPoint> _dataPoints;
        
        public ImportFromTextFile()
        {
            _dataPoints = new List<IDataPoint>();
        }

        public List<IDataPoint> ImportData()                                                                         
        {                                                                                                              
            List<string> TextRows = new List<string>();                                                                               

            if (File.Exists("OMX data.txt"))
            {
                StreamReader reader = new StreamReader("OMX data.txt", Encoding.Default, true);
                string stringRow = "";

                while ((stringRow = reader.ReadLine()) != null) { TextRows.Add(stringRow); }

                string[] days;

                foreach (string textRow in TextRows)
                {
                    days = textRow.Split(new string[] { "{" }, StringSplitOptions.None);

                    try
                    {
                        StringManipulation(days);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString(), "Error in string manipulation!");
                    }
                }

                reader.Dispose();
            }
            else { MessageBox.Show("Importen misslyckades, textfilen kundlista hittades inte."); }

            return _dataPoints;
        }

        private void StringManipulation(string [] days)
        {
            for (int i = 0; i < days.Length; i++)
            {
                _dataPoints.Add(new DailyDataPoint
                {
                    Open = TestValue(days, 7, 8, i),
                    High = TestValue(days, 23, 8, i),
                    Low = TestValue(days, 38, 8, i),
                    Close = TestValue(days, 54, 8, i),
                    MilliSeconds = TestValue(days, 81, 13, i)
                }); 
            }
        }

        private double TestValue(string[] days, int start, int stop, int loop)
        {
            double valueOut = -1;
            double.TryParse(days[loop].Substring(start, stop), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valueOut);
            return valueOut;
        }
    }
}
