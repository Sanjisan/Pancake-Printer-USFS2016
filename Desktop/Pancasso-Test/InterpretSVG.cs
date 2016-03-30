using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;

/* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
NOTES:

    * Each path must contain a fill. If not it will either be ignored, or
    display improperly.
    
    * Any paths that share the same color shall be placed into the same timing
    priority list as other paths in the order that they appear in the file. The
    darker the color the longer the cooking time.

    * Cooking times are based on color. Using a function of time ranging from 
    #000000 to #FFFFFF. Where #000000 is the longest and #FFFFFF is the
    shortest.

    * SVG file must be in the Inkscape SVG format. Other formats may not be
    handled properly during printing.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

/// <summary>
/// A collection of methods that interpret/parse Inkscape SVG files, serially
/// outputs path information such as: color, curve functions, and other details 
/// for use in Pancasso.
/// </summary>
namespace Pancasso_Test
{
    class InterpretSVG
    {
        /// <summary>
        /// Holds path information based on color. Each path is read in to a list in value.
        /// </summary>
        private SortedDictionary<string, string[]> pathDetails = new SortedDictionary<string, string[]>();
        private string[] path;
        private static string _svgLocation;
        private string SvgLocation { get { return _svgLocation; } }

        /// <summary>
        /// Reads in and sets the location of SVG for parsing/interpreting.
        /// </summary>
        /// <param name="svgLocation">Full path location for SVG file.</param>
        public InterpretSVG (string svgLocation)
        {
            try
            {
                _svgLocation = svgLocation;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Parses the svg file sequentially looking only for everything 
        /// between path beginning and end. Returns the resulting dictionary
        /// </summary>
        public SortedDictionary<string, string[]> ParsePath ()
        {
            char[] delimiterChars = { ' ', '\n' };
            string[] fileText = System.IO.File.ReadAllLines(@_svgLocation);

            // Read all 'lines' from the file
            for (int i = 0; i < fileText.Length; i++)
            {   
                // Read in pathdetails
                if (fileText.ElementAt(i).Contains("<path"))
                {
                    int pathIterator = i;
                    string color = null;

                    if (fileText.ElementAt(i).Contains("style="))
                    {
                        string [] colorSplit = fileText.ElementAt(i).Split(':', ';');
                        color = colorSplit.ElementAt(1);
                    }

                    if (color != null) // Make sure there is a fill color
                    {
                        // Read until path has ended
                        do
                        {
                            string[] words = fileText.ElementAt(pathIterator).Split(delimiterChars, '"');

                            foreach (string s in words)
                            {
                                //if (!s.Contains("inkscape:connector-curvature=") || !!s.Contains("id=") || !s.Contains("stroke") || !s.Contains("fill"))
                                    //path.Add(s);
                            }

                            pathIterator++;
                        } while (fileText.ElementAt(pathIterator).Contains("/>"));

                        //pathDetails.Add(color, path);
                    }

                    // Continue from this line. End of path
                    i = pathIterator;
                }
            }

            //try
            //{
            //    _svgLocation.TextFieldType = FieldType.Delimited;
            //    _svgLocation.SetDelimiters(" ","\n");

            //    while (!_svgLocation.EndOfData)
            //    {
            //        if (line.Contains("<path"))
            //        {
            //            do
            //            {
            //                if (line.Contains("fill:"))


            //                fields = _svgLocation.ReadFields();
            //                pathDetails.Add("Yellow", fields);
            //            } while (line.Contains("/>") == false);
            //        }  
            //    }

            //    _svgLocation.Close();
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}

            return pathDetails;
        }
    }
}
