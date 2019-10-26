using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GraphProject
{
    public class ImportFromTextFile //: IImportData 
    {
        private List<DailyDataPoint> _dataPoints;
        
        public ImportFromTextFile()
        {
            _dataPoints = new List<DailyDataPoint>();
        }

        public List<DailyDataPoint> ImporteraData()                                                                         
        {                                                                                                              
            List<string> TextRows = new List<string>();                                                                               

            if (File.Exists("OMX data.txt"))
            {
                StreamReader reader = new StreamReader("OMX data.txt", Encoding.Default, true);
                string stringRow = "";

               
                try
                {
                    while ((stringRow = reader.ReadLine()) != null) { TextRows.Add(stringRow); }
                }
                catch 
                {

                    MessageBox.Show("Fel i while sats!");
                }


                try
                {
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

                            MessageBox.Show(ex.ToString(),"Fel i String manipulation");
                        }

                        
                    }

                    reader.Dispose();
                }
                catch (IndexOutOfRangeException e1)
                {
                    MessageBox.Show(e1.Message, "Det blev fel1 vid import av användaredata från textfil! " +
                        "Söker data utanför index i vektorn."); 
                }
                catch (ArgumentOutOfRangeException e2)
                {
                    MessageBox.Show(e2.Message, "Det blev fel2 vid import av användaredata från textfil! " +
                        "Söker data utanför index i listan."); 
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Det blev fel vid import av användaredata från textfil! " +
                        "Övriga fel."); 
                }
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
                    

                    /*
                    Open = double.Parse(days[i].Substring(7, 8), System.Globalization.CultureInfo.InvariantCulture),
                    High = double.Parse(days[i].Substring(23, 8), System.Globalization.CultureInfo.InvariantCulture),
                    Low = double.Parse(days[i].Substring(38, 8), System.Globalization.CultureInfo.InvariantCulture),
                    Close = double.Parse(days[i].Substring(54, 8), System.Globalization.CultureInfo.InvariantCulture),
                    MilliSeconds = double.Parse(days[i].Substring(81, 13), System.Globalization.CultureInfo.InvariantCulture) // Convert.ToInt32(days[i].Substring(81, 13))//int.Parse(days[i].Substring(81, 13)) // FUngerade ej med Int
                    */

                }); 
                //MessageBox.Show(string.Format("{0}", _dataPoints[0].MilliSeconds));//
                
                // Fungerar ej
                // _dataPoints[0].Open = double.Parse(days[i].Substring(7,8)));
                                  /*
                                  _dataPoints[i].High = double.Parse(days[i].Substring(7, 8));
                                  _dataPoints[i].Low = double.Parse(days[i].Substring(6, 8));
                                  _dataPoints[i].Close = double.Parse(days[i].Substring(7, 8));
                                  _dataPoints[i].Open = double.Parse(days[i].Substring(7, 8));
                                  _dataPoints[i].MilliSeconds = int.Parse(days[i].Substring(7, 13));*/
            }

        }

        private double TestValue(string[] days, int start, int stop, int loop)
        {
            double valueOut = -1;
            //days[loop].Replace('.', ',');
            double.TryParse(days[loop].Substring(start, stop), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out valueOut);
            return valueOut;
        }
    }
}
